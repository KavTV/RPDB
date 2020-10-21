export function ProjectObject(id = Int32Array, headline = String, description = String, documentation = String, students = Array) {

    this.ID = id;
    this.Headline = headline;
    this.Description = description;
    this.Documentation = documentation;
    this.Students = students;

    this.Edit = function () {

    }
}

export function ProjectManager(settings = Object) {

    let Projects = Array;
    let Settings = settings;

    this.Update = function () {
        BoxLoading();
        $.getJSON("https://api.projektdatabase.skprg.dk/projects", function (result) {
            Projects = [];

            result.forEach(project => {
                let students = [];
                project['Students'].forEach(student => {
                    students.push(student['Username']);
                });

                Projects.push(new ProjectObject(project['Id'], project['Headline'], project['Description'], project['Documentation'], students));
            });
            Box();
            console.log(Projects);
        });
    }

    const Box = function () {
        if (Projects) {

            let element = document.getElementById(Settings['BoxID']);
            element.innerHTML = "";

            Projects.forEach(project => {
                let text = Settings['HTMLelement'].toString();
                text = text.replace('%ID%', project.ID)
                    .replace('%Headline%', project.Headline)
                    .replace('%Description%', project.Description)
                    .replace('%Documentation%', project.Documentation)
                    .replace('%Students%', project.Students);
                element.innerHTML += text;
            });
        }
    }

    const BoxLoading = function () {

        let element = document.getElementById(Settings['BoxID']);
        element.innerHTML = Settings['BoxLoadingElement'];

    }

    //EventListner
    try {
        document.getElementById(Settings['UpdateID']).addEventListener("click", func => { this.Update(); });
    } catch (e) {

    }
}