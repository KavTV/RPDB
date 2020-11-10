export class Student {
    Username = String;
    Education = String;
    Name = String;
    Project = Array;

    constructor(Username = String, Education = String, Name = String, Project = Array) {
        this.Username = Username;
        this.Education = Education;
        this.Name = Name;
        this.Project = Project;
    }
}

class Project {
    constructor(id = Int32Array, headline = String, description = String, documentation = String) {
        this.ID = id;
        this.Headline = headline;
        this.Description = description;
        this.Documentation = documentation;
    }
}

export function StudentManager(settings = Array) {

    let Students = Array;
    let Settings = settings;
    let Search;

    console.log(Settings);

    this.Update = function () {
        let Url = "https://api.projektdatabase.skprg.dk/students";

        if (Search && Search != " ") {
            Url = `https://api.projektdatabase.skprg.dk/searchstudents?search=${Search} `;
        }

        $.getJSON(Url, function (result) {
            console.log(result);

            Students = [];

                result.forEach(student => {
                    let projects = [];
                    student['ProjectList'].forEach(project => {
                        projects.push(new Project(project['Id'], project['Headline'], project['Description'], project['Documentation']));
                    });
                    Students.push(new Student(student['Username'], student['Education'], student['Name'], projects));
                });
                Box();
            try {
            } catch (e) {
                BoxError(e);
            }
        }).fail(function () {
            BoxError("Error");
        });
    }
    const Box = function () {
        if (Students) {

            if (Settings['BoxID']) {
                let element = document.getElementById(Settings['BoxID']);
                element.innerHTML = "";

                Students.forEach(project => {
                    let projectArray = [];
                    project.Project.forEach(project => {
                        projectArray.push(project.Headline);
                    });
                    console.log(project);
                    let text = Settings['BoxTableDataElement'].toString();
                    text = text.replace('%ID%', project.ID)
                        .replace('%Username%', project.Username)
                        .replace('%Education%', project.Education)
                        .replace('%Name%', project.Name)
                        .replace('%Projects%', projectArray.join(", "));
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
        if (Settings['UpdateID'] && document.getElementById(Settings['UpdateID'])) {
            document.getElementById(Settings['UpdateID']).addEventListener("click", func => { this.Update(); });
        }
        if (Settings['SearchID'] && document.getElementById(Settings['SearchID'])) {
            document.getElementById(Settings['SearchID']).addEventListener("change", func => {
                Search = func.path[0].value;
                this.Update();
            });
        }
    } catch (e) {
        console.log(e);
    }
}