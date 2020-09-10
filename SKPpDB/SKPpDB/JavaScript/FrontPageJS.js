var TableList = document.getElementById("TableList");
var Projects = FetchJson("https://localhost:44369/api/projects");

window.addEventListener('load', function () {
    LoadTable();
})

function TableAddRow(Headline, Description, Documentation, Students) {
    TableList.innerHTML += '<article class="TableBody row">' +
    '<header class="col-md-2 ScrollLook">' + Headline + '</header>' + 
    '<header class="col-md-6 ScrollLook">' + Description + '</header>' +
    '<header class="col-md-2 ScrollLook">' + Documentation + '</header>' +
    '<header class="col-md-2 ScrollLook">' + Students + '</header>' +
    '</article">';
}

function LoadTable() {
    Projects.responseJSON.forEach(element => {
        var students = element["Students"];
        var studentsString = "";

        students.forEach(student => {
            studentsString += student["Name"] + '<br>';
        });

        TableAddRow(element["Headline"], element["Description"], element["Documentation"], studentsString);
    });
}

function LoadJson() {
    Projects = FetchJson("https://localhost:44369/api/projects");
}