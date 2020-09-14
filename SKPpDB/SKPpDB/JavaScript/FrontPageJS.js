var TableList = document.getElementById("TableList");
var Project = FetchJson("https://localhost:44369/api/projects").done(function () {
    LoadTable();
}).fail(function () {
    AddError("Kunne ikke få fat i databasen");
});

function TableAddRow(Id, Headline, Description, Documentation, Students) {
    TableList.innerHTML += '<article class="TableBody row">' +
        '<a href="Project.aspx?projectid=' + Id + '" class="col-md-2">' +
        '<header class="ScrollLook">' + Headline + '</header>' + '</a>' +
        '<header class="col-md-6 ScrollLook">' + Description + '</header>' +
        '<header class="col-md-2 ScrollLook">' + Documentation + '</header>' +
        '<header class="col-md-2 ScrollLook">' + Students + '</header>' +
        '</article">';
}

function LoadTable() {
    console.log(Project);
    Project.responseJSON.forEach(element => {
        var students = element["Students"];
        var studentsString = "";

        students.forEach(student => {
            studentsString += student["Name"] + '<br>';
        });

        TableAddRow(element["Id"],element["Headline"], element["Description"], element["Documentation"], studentsString);
    });
}


function AddError(error) {
    TableList.innerHTML = '<article class="TableBody row">' +
        '<header class="col-md-12">' + error + '</header>' +
        '</article>';
}