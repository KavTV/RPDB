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

        if (Search && Search != " ") {
            Url = `https://api.projektdatabase.skprg.dk/searchprojects?search=${Search} `;
        }

        $.getJSON(Url, function (result) {
            Projects = [];
            try {
                result.forEach(project => {
                    let students = [];
                    project['Students'].forEach(student => {
                        students.push(new Student(student['Username'], student['Name']));
                    });
                    Projects.push(new ProjectObject(project['Id'], project['Headline'], project['Description'], project['Documentation'], students));
                });
                Box();
            } catch (e) {
                BoxError(e);
            }
        }).fail(function () {
            BoxError("Error");
        });
    }

    const Box = function () {
        if (Projects) {

            if (Settings['BoxID']) {
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
    }

    const BoxLoading = function () {

        if (Settings['BoxID'] && Settings['BoxLoadingElement']) {
            let element = document.getElementById(Settings['BoxID']);
            element.innerHTML = Settings['BoxLoadingElement'];
        }
    }

    const BoxError = function (error = String) {

        if (Settings['BoxID'] && Settings['BoxErrorElement']) {
            let element = document.getElementById(Settings['BoxID']);
            element.innerHTML = Settings['BoxErrorElement'].replace("%Error%", error);
        }

    }

    //EventListner
    try {
        if (Settings['UpdateID']) {
            document.getElementById(Settings['UpdateID']).addEventListener("click", func => { this.Update(); });
        }
        if (Settings['SearchID']) {
            document.getElementById(Settings['SearchID']).addEventListener("change", func => {
                Search = func.path[0].value;
                this.Update();
            });
        }
    } catch (e) {

    }
}