var TableList = document.getElementById("TableList");
var params = getParams(window.location.href);

var Project = FetchJson("student?username=" + params['username']).done(function () {
    UpdateTable();
}).fail(function () {
    AddError("Kunne ikke få fat i databasen");
})

function UpdateTable() {
    var response = Project.responseJSON;
    var projects = Project.responseJSON["ProjectList"];
    var projectstring = "";
    console.log(projects);
    projects.forEach(project => {
        projectstring += '<a href="Project.aspx?projectid=' + project["Id"] + '">' + project["Headline"] + '</a>';
    });

    TableAddRow(response["Name"], projectstring, response["Education"], response["Username"]);
}

function TableAddRow(Name, Projects, Education, username) {
    TableList.innerHTML += '<article class="TableBody row">' +
        '<header class="col-md-3 ScrollLook">' + Name + '</header>' +
        '<header class="col-md-6 ScrollLook">' + Projects + '</header>' +
        '<header class="col-md-3 ScrollLook">' + Education + '</header>' +
        '</article"> ';
}

function AddError(error) {
    TableList.innerHTML = '<article class="TableBody row">' +
        '<header class="col-md-12">' + error + '</header>' +
        '</article>';
}