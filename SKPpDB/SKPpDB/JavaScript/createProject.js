LoadingScreen(true);

var projectNameElement = document.getElementById("ProjectName");
var projectDescriptionElement = document.getElementById("ProjectDesription");
var projectDocumentationElement = document.getElementById("ProjectDocumentation");
var createButtonElement = document.getElementById("CreateButton");

//#region STUDENT SYSTEM

//Student System elements
var SelectElement = document.getElementById("Students");
var SelectProjectmanager = document.getElementById("ProjectManager");
var studentBox = document.getElementById("studentBox");
var StudentListBox = document.getElementById("SelectedStudents");
var SelectStatusId = document.getElementById("StatusId");
var StartDate = document.getElementById("StartDate");
var EndDate = document.getElementById("EndDate");

//Student system variable
var StudentIndexList = [];
var students = FetchJson("students").done(function () {
    if (students.responseJSON != null) {
        LoadSelect();
    }
    LoadingScreen(false);
}).fail(function () {
    MainError();
});

function LoadSelect() {
    students.responseJSON.forEach(element => {
        SelectAddOption(element["Username"], element["Name"] + " (" + element["Education"] + ")");
    });
}

function SelectAddOption(Value, InnerText) {
    SelectElement.innerHTML += '<option value="' + Value + '">' + InnerText + '</option>';
    SelectProjectmanager.innerHTML += '<option value="' + Value + '">' + InnerText + '</option>';
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
    console.log(student);
}
//#endregion

//Create Project
function createProject() {
    if (projectNameElement.value && projectDescriptionElement.value && projectDocumentationElement.value && StudentIndexList.length > 0) {
        LoadingScreen(true);
        var projectLeader = GetSelectedStudents();
        var projectName = projectNameElement.value;
        var projectDescription = projectDescriptionElement.value;
        var projectDocumentation = projectDocumentationElement.value;

        var studentString = "";
        studentString += projectLeader + ",";
        studentString = studentString.substring(0, studentString.length - 1);

        PostData("createproject?statusid=" + SelectStatusId.value + "&projectmanager=" + SelectProjectmanager.value + "&headline=" + projectName + "&documentation=" + projectDocumentation + "&description=" + projectDescription + "&startdate=" + StartDate.value + "&enddate=" + EndDate.value + "&username=" + studentString)
            .done(function () {
                LoadingScreen(false);
                window.location.href = "../";
            }).fail(function () {
                LoadingScreen(false);
                document.getElementById("Mainbox").innerHTML += '<h6 style="text-align: center; color: red;">Kunne ikke oprettes</h6>';
            });
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