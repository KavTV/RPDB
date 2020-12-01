export class ProjectObject {
    ID;
    StatusId;
    ProjectManager;
    Headline;
    Description;
    Documentation;
    StartDate;
    EndDate;
    Students;

    //Set the object manual up.
    Manual_Setup(ID = Int32Array, Headline = String, Description = String, Documentation = String, Students = Array) {
        this.ID = ID;
        this.Headline = Headline;
        this.Description = Description;
        this.Documentation = Documentation;
        this.Students = Students;
    }

    //Make an Api Search and let it do it by an ID.
    async Api_Setup(ID = Int32Array) {
        let URL = `https://api.projektdatabase.skprg.dk/project?projectid=${ID} `;
        let resulta;

        await $.getJSON(URL, function (result) {
            resulta = result;
        }).fail(function (e) {
            console.error(e);
        });
        this.ID = resulta["Id"];
        this.StatusId = resulta["Statusid"];
        this.ProjectManager = resulta["Projectmanager"];
        this.Headline = resulta["Headline"];
        this.Description = resulta["Description"];
        this.Documentation = resulta["Documentation"];
        this.StartDate = new Date(resulta["Startdate"]);
        this.EndDate = new Date(resulta["Enddate"]);
        this.Students = [];

        resulta["Students"].forEach(student => {
            this.Students.push(new Student(student['Username'], student['Name']));
        });
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
                    let Project = new ProjectObject();
                    project['Students'].forEach(student => {
                        students.push(new Student(student['Username'], student['Name']));
                    });
                    Project.Manual_Setup(project['Id'], project['Headline'], project['Description'], project['Documentation'], students);
                    Projects.push(Project);
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