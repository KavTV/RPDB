LoadingScreen(true);

var projectNameElement = document.getElementById("HeadlineText");
var projectDescriptionElement = document.getElementById("DescriptionText");
var projectDocumentationElement = document.getElementById("DocumentationText");
var createButtonElement = document.getElementById("EditButton");
var statusElement = document.getElementById("StatusId");
var startDateElement = document.getElementById("StartDate");
var endDateElement = document.getElementById("EndDate");
var projectManagerElement= document.getElementById("ProjectManager");

var students = FetchJson("students").done(function () {
    if (students.responseJSON != null) {
        LoadSelect();
        var Project = FetchJson("project?projectid=" + getParams(window.location.href)['projectid']).done(function () {
            projectNameElement.value = Project.responseJSON["Headline"];
            projectDescriptionElement.value = Project.responseJSON["Description"];
            projectDocumentationElement.value = Project.responseJSON["Documentation"];
            statusElement.value = Project.responseJSON["Statusid"];
            startDateElement.value = `${new Date(Project.responseJSON["Startdate"]).getFullYear()}-${("0" + (new Date(Project.responseJSON["Startdate"]).getMonth() + 1)).slice(-2)}-${("0" + new Date(Project.responseJSON["Startdate"]).getDate()).slice(-2)}`;
            endDateElement.value = `${new Date(Project.responseJSON["Enddate"]).getFullYear()}-${("0" + (new Date(Project.responseJSON["Enddate"]).getMonth() + 1)).slice(-2)}-${("0" + new Date(Project.responseJSON["Enddate"]).getDate()).slice(-2)}`;
            projectManagerElement.value = Project.responseJSON["Projectmanager"];
            var students = Project.responseJSON["Students"];
            students.forEach(student => { FillStudents(student) });
            LoadingScreen(false);
        }).fail(function () {
            MainError();
        });
    }
}).fail(function () {
    MainError();
});

//#region STUDENT SYSTEM

//Student System elements
var SelectElement = document.getElementById("Students");
var studentBox = document.getElementById("studentBox");
var StudentListBox = document.getElementById("SelectedStudents");

//Student system variable
var StudentIndexList = [];

function LoadSelect() {
    students.responseJSON.forEach(element => {
        SelectAddOption(element["Username"], element["Name"] + " (" + element["Education"] + ")");
    });
}

function SelectAddOption(Value, InnerText) {
    SelectElement.innerHTML += '<option value="' + Value + '">' + InnerText + '</option>';
    projectManagerElement.innerHTML += '<option value="' + Value + '">' + InnerText + '</option>';
}

function AddSelectedStudent() {
    var student = students.responseJSON[SelectElement.selectedIndex];
    var optionElement = SelectElement.selectedOptions[0];

    if (StudentIndexList.find(element => element == SelectElement.selectedIndex) != SelectElement.selectedIndex && SelectElement.selectedIndex != -1) {
        var newOption = document.createElement("option");
        newOption.text = student["Name"] + ' (' + student["Education"] + ')';
        newOption.value = student["Username"];

        StudentIndexList.push(SelectElement.selectedIndex);
        optionElement.disabled = true;
        SelectElement.selectedIndex++;
        StudentListBox.options.add(newOption);
    }
}

function RemoveSelectedStudent() {
    if (StudentListBox.selectedOptions[0]) {
        SelectElement.options[StudentIndexList[StudentListBox.selectedIndex]].disabled = false;
        StudentIndexList.splice(StudentListBox.selectedIndex, 1);
        StudentListBox.selectedOptions[0].remove();
    }
}

function GetSelectedStudents() {
    var student = [];
    for (var i = 0; i < StudentListBox.options.length; i++) {
        student.push(StudentListBox.options[i].value);
    }
    return student;
}
//#endregion

function FillStudents(student) {
    //Add students to studentbox
    //var student = students.responseJSON[SelectElement.selectedIndex];
    var optionElement = [];
    for (var i = 0; i < SelectElement.options.length; i++) {
        optionElement.push(SelectElement.options[i]);
    }

    var studentIndex = optionElement.findIndex(element => element.value == student["Username"]);

    if (StudentIndexList.find(element => element == SelectElement.selectedIndex) != SelectElement.selectedIndex && SelectElement.selectedIndex != -1) {
        var newOption = document.createElement("option");
        newOption.text = student["Name"] + ' (' + student["Education"] + ')';
        newOption.value = student["Username"];

        StudentIndexList.push(studentIndex);
        SelectElement.options[studentIndex].disabled = true;
        StudentListBox.options.add(newOption);
    }
}

//Edit Project
function EditProject() {
    if (projectNameElement.value && projectDescriptionElement.value && projectDocumentationElement.value && StudentIndexList.length > 0) {
        var projectLeader = GetSelectedStudents();
        var params = getParams(window.location.href);
        var projectName = projectNameElement.value;
        var projectDescription = projectDescriptionElement.value;
        var projectDocumentation = projectDocumentationElement.value;

        var studentString = "";
        studentString += projectLeader + ",";
        studentString = studentString.substring(0, studentString.length - 1);

        PostData("editproject?projectid=" + params['projectid'] + "&statusid=" + statusElement.value + "&projectmanager=" + projectManagerElement.value + "&headline=" + projectName + "&documentation=" + projectDocumentation + "&description=" + projectDescription + "&startdate=" + startDateElement.value + "&enddate=" + endDateElement.value + "&usernames=" + studentString);
        window.location.href = "../";
    }
    else {
        console.log("not all forfillment is required yet");
    }
}

function FillmentRequire() {
    if (projectNameElement.value && projectDescriptionElement.value && projectDocumentationElement.value && StudentIndexList.length > 0) {
        createButtonElement.disabled = false;
    }
    else {
        createButtonElement.disabled = true;
    }
}