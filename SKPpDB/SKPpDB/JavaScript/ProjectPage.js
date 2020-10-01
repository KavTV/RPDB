var TableList = document.getElementById("TableList");
var Project;

if (getParams(window.location.href)['projectid'] == undefined) {
    window.location.href = "../";
}

window.addEventListener('load', function () {
    UpdateTable();
})

async function UpdateTable() {
    var params = getParams(window.location.href);
    Project = await FetchJson("project?projectid=" + params['projectid']);

    var students = Project["Students"];
    var studentsString = "";

    students.forEach(student => {
        studentsString += student["Name"] + ',<br>';
    });

    TableAddRow(Project["Headline"], Project["Description"], Project["Documentation"], studentsString);
}

function TableAddRow(Headline, Description, Documentation, Students) {
    TableList.innerHTML += '<article class="TableBody row">' +
        '<header class="col-md-2 ScrollLook">' + Headline + '</header>' +
        '<header class="col-md-6 ScrollLook">' + Description + '</header>' +
        '<header class="col-md-2 ScrollLook">' + Documentation + '</header>' +
        '<header class="col-md-2 ScrollLook">' + Students + '</header>' +
        '</article">';
}