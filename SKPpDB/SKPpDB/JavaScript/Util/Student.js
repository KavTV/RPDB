export class StudentObject {
    Username = String;
    Education = String;
    Name = String;
    Projects = Array;

    Manual_Setup(Username = String, Education = String, Name = String, Project = Array) {
        this.Username = Username;
        this.Education = Education;
        this.Name = Name;
        this.Projects = Project;
    }

    async Api_Setup(Username = String) {
        let URL = `https://api.skprgopg.zbc.dk/student?username=${Username} `;
        let resulta;

        await $.getJSON(URL, function (result) {
            resulta = result;
        }).fail(function (e) {
            console.error(e);
        });

        this.Username = resulta["Username"];
        this.Education = resulta["Education"];
        this.Name = resulta["Name"];
        this.Projects = [];

        resulta["ProjectList"].forEach(project => {
            this.Projects.push(new Project(project['Id'], project['Headline'], project['Description'], project['Documentation']));
        });
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
        let Url = "https://api.skprgopg.zbc.dk/students";
        BoxLoading();

        if (Search && Search != " ") {
            Url = `https://api.skprgopg.zbc.dk/searchstudents?search=${Search} `;
        }

        $.getJSON(Url, function (result) {
            Students = [];

                result.forEach(student => {
                    let projects = [];
                    student['ProjectList'].forEach(project => {
                        projects.push(new Project(project['Id'], project['Headline'], project['Description'], project['Documentation']));
                    });
                    var studentO = new StudentObject();
                    studentO.Manual_Setup(student['Username'], student['Education'], student['Name'], projects);
                    Students.push(studentO);
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
                    project.Projects.forEach(project => {
                        projectArray.push(project.Headline);
                    });
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