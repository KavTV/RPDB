export function ProjectObject(id = Int32Array, headline = String, description = String, documentation = String, students = Array) {

    this.ID = id;
    this.Headline = headline;
    this.Description = description;
    this.Documentation = documentation;
    this.Students = students;

    this.Edit = function () {

    }
}

export function ProjectManager() {

    this.Projects = [];
    
    this.Update = function () {
        $.getJSON("https://api.projektdatabase.skprg.dk/projects", function (result) {
            this.Projects = [];

            result.forEach(project => {
                let students = [];
                project['Students'].forEach(student => {
                    students.push(student['Username']);
                });

                this.Projects.push(new ProjectObject(project['Id'], project['Headline'], project['Description'], project['Documentation'], students));
            });
            console.log(this.Projects);
        });
    }
}