var TableList = document.getElementById("TableList");
var Project;

var RefeshPause = false;
RefeshProjects();

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
    
    //console.log(Project.responseJSON.filter(a => a.Students[3] == "Programmering"));
    TableList.innerHTML = "";
    Project.responseJSON.forEach(element => {
        var students = element["Students"];
        var studentsString = "";

        students.forEach(student => {
            studentsString += student["Name"] + ',<br>';
        });

        TableAddRow(element["Id"],element["Headline"], element["Description"], element["Documentation"], studentsString);
    });
}


function AddError(error) {
    TableList.innerHTML = '<h6 style="color: red; text-align: center;">' + error + '</h6>';
}

function Projectfind(string) {
    string = "skp";
    for (var i = 0; i < Project.responseJSON.length; i++) {
        var searchProjects = Project.responseJSON.find(element => {
            

        });
    }
}

function RefeshProjects() {
    if (!RefeshPause) {
        console.log("refeshing");
        RefeshPause = true;

        TableList.innerHTML = '<img src="Style/Image/loadingIcon.png" class="loading" alt="Loading ..."/><h6 style = "text-align:center;">Loading ...</h6>'

        Project = FetchJson("projects").done(function () {
            LoadTable();
            RefeshPause = false;
        }).fail(function () {
            AddError("Kunne ik finde projekterne, prøv igen senere");
            RefeshPause = false;
        });
    }
}

function SearchProjects() {
    
    console.log(searchbar.value);
    if (!RefeshPause) {
        console.log("refeshing");
        RefeshPause = true;

        TableList.innerHTML = '<img src="Style/Image/loadingIcon.png" class="loading" alt="Loading ..."/><h6 style = "text-align:center;">Loading ...</h6>'

        const searchbar = document.getElementById("searchbar").value;
        Project = FetchJson("searchprojects?search=" + searchbar).done(function () {
            LoadTable();
            RefeshPause = false;
        }).fail(function () {
            AddError("Kunne ik finde projekterne, prøv igen senere");
            RefeshPause = false;
        });
    }
}