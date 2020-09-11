var TableList = document.getElementById("TableList");

var Project;

window.addEventListener('load', function () {

    console.log(Project);
    UpdateTable();
})

async function UpdateTable() {
    var params = getParams(window.location.href);
    Project = await FetchJson("https://localhost:44369/api/project?projectid=" + params['projectid']);
    console.log(Project);
    

    var students = Project["Students"];
    var studentsString = "";

    students.forEach(student => {
        studentsString += student["Name"] + '<br>';
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

var getParams = function (url) {
    var params = {};
    var parser = document.createElement('a');
    parser.href = url;
    var query = parser.search.substring(1);
    var vars = query.split('&');
    for (var i = 0; i < vars.length; i++) {
        var pair = vars[i].split('=');
        params[pair[0]] = decodeURIComponent(pair[1]);
    }
    return params;
};