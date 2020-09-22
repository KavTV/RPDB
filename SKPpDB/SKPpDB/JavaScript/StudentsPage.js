var TableList = document.getElementById("TableList");

var Project = FetchJson("students").done(function () {
    UpdateTable();
}).fail(function () {
    AddError("Kunne ikke få fat i databasen");
})

function UpdateTable() {


    Project.responseJSON.forEach(element => {
        var projects = element["ProjectList"];
        var projectstring = "";

        projects.forEach(project => {
            projectstring += project["Headline"] + '<br>';
        });

        TableAddRow(element["Name"], projectstring, element["Education"], element["Username"]);
    });

}

function TableAddRow(Name, Projects, Education, username) {
    TableList.innerHTML += '<article class="TableBody row">' +
        '<a href="Student.aspx?username=' + username + '" class="col-md-3">' +
        '<header class="ScrollLook">' + Name + '</header>' + '</a>' +
        '<header class="col-md-6 ScrollLook">' + Projects + '</header>' +
        '<header class="col-md-3 ScrollLook">' + Education + '</header>' +
        '</article"> ';
}

function AddError(error) {
    TableList.innerHTML = '<article class="TableBody row">' +
        '<header class="col-md-12">' + error + '</header>' +
        '</article>';
}

