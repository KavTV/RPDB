var TableList = document.getElementById("TableList");
var RefeshPause = false;

var Project = FetchJson("students").done(function () {
    UpdateTable();
}).fail(function () {
    AddError("Kunne ikke få fat i databasen");
})

function UpdateTable() {
    TableList.innerHTML = '<img src="Style/Image/loadingIcon.png" class="loading" alt="Loading ..."/><h6 style = "text-align:center;">Loading ...</h6>'

    if (Project.responseJSON != null) {
        TableList.innerHTML = '';
        Project.responseJSON.forEach(element => {
            var projects = element["ProjectList"];
            var projectstring = "";

            projects.forEach(project => {
                projectstring += project["Headline"] + '<br>';
            });

            TableAddRow(element["Name"], projectstring, element["Education"], element["Username"]);
        });
    }
    else {
        Project = FetchJson("students").done(function () {
            UpdateTable();
            RefeshPause = false;
        }).fail(function () {
            AddError("Kunne ik finde elever, prøv igen senere");
            RefeshPause = false;
        });
    }
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

function SearchStudents() {
    console.log(searchbar.value);
    if (!RefeshPause) {
        console.log("refeshing");
        RefeshPause = true;

        TableList.innerHTML = '<img src="Style/Image/loadingIcon.png" class="loading" alt="Loading ..."/><h6 style = "text-align:center;">Loading ...</h6>'

        const searchbar = document.getElementById("searchbar").value;
        Project = FetchJson("searchstudents?search=" + searchbar).done(function () {
            UpdateTable();
            RefeshPause = false;
        }).fail(function () {
            AddError("Kunne ik finde elever, prøv igen senere");
            RefeshPause = false;
        });
    }
}