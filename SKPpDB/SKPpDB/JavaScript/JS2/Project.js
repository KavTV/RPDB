class ProjectObject {
    constructor(id = Int32Array, headline = String, description = String, documentation = String, students = Array) {
        this.ID = id;
        this.Headline = headline;
        this.Description = description;
        this.Documentation = documentation;
        this.Students = students;
    }

    Edit() {

    }
}

class Student {
    constructor(Username = String, Name = String) {
        this.Username = Username;
        this.Name = Name;
    }
}

export function ProjectManager(settings = Object) {

    let Projects = Array;
    let Settings = settings;
    let Search;

    this.Update = function () {
        BoxLoading();
        let Url = "https://api.projektdatabase.skprg.dk/projects";

        if (Search) {
            Url = `https://api.projektdatabase.skprg.dk/searchprojects?search=${Search} `;
        }

        $.getJSON(Url, function (result) {
            Projects = [];
            result.forEach(project => {
                let students = [];
                project['Students'].forEach(student => {
                    students.push(new Student(student['Username'], student['Name']));
                });

                Projects.push(new ProjectObject(project['Id'], project['Headline'], project['Description'], project['Documentation'], students));
            });
            Box();
        }).fail(function () {
            BoxError("Error");
        });
    }

    const Box = function () {
        if (Projects) {

            let element = document.getElementById(Settings['BoxID']);
            element.innerHTML = "";

            Projects.forEach(project => {
                let StudentArray = [];
                project.Students.forEach(student => {
                    StudentArray.push(student['Name']);
                });

                let text = Settings['BoxTableDataElement'].toString();
                text = text.replace('%ID%', project.ID)
                    .replace('%Headline%', project.Headline)
                    .replace('%Description%', project.Description)
                    .replace('%Documentation%', project.Documentation)
                    .replace('%Students%', StudentArray.join(", "));
                element.innerHTML += text;
            });
        }
    }

    const BoxLoading = function () {

        let element = document.getElementById(Settings['BoxID']);
        element.innerHTML = Settings['BoxLoadingElement'];
    }

    const BoxError = function (error = String) {

        let element = document.getElementById(Settings['BoxID']);
        element.innerHTML = Settings['BoxErrorElement'].replace("%Error%", error);

    }

    //EventListner
    try {
        document.getElementById(Settings['UpdateID']).addEventListener("click", func => { this.Update(); });
        document.getElementById(Settings['SearchID']).addEventListener("change", func => {
            Search = func.path[0].value;
            this.Update();
        });
    } catch (e) {

    }
}