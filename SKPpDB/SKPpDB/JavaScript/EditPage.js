
var projectNameElement = document.getElementById("HeadlineText");
var projectDescriptionElement = document.getElementById("DescriptionText");
var projectDocumentationElement = document.getElementById("DocumentationText");
var createButtonElement = document.getElementById("EditButton");

window.addEventListener('load', function () {

    FillInput();
})

//Fill forms with the project information.
async function FillInput() {
    var params = getParams(window.location.href);
    var Project = await FetchJson("https://localhost:44369/api/project?projectid=" + params['projectid']);
    
    
    projectNameElement.value = Project["Headline"];
    projectDescriptionElement.value = Project["Description"];
    projectDocumentationElement.value = Project["Documentation"];
    var students = Project["Students"];
    students.forEach(student => { FillStudents(student) })
    
}

function FillStudents(student) {
    //Add students to studentbox
    //var student = students.responseJSON[SelectElement.selectedIndex];
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

//#region STUDENT SYSTEM

//Student System elements
var SelectElement = document.getElementById("Students");
var studentBox = document.getElementById("studentBox");
var StudentListBox = document.getElementById("SelectedStudents");

//Student system variable
var StudentIndexList = [];
var students = FetchJson("https://localhost:44369/api/students").done(function () {
    if (students.responseJSON != null) {
        LoadSelect();
    }
}).fail(function () {
    studentBox.innerHTML = "<h6 style='color: red;'>Connection Fail</h6>"
});

function LoadSelect() {
    students.responseJSON.forEach(element => {
        SelectAddOption(element["Username"], element["Name"] + " (" + element["Education"] + ")");
    });
}

function SelectAddOption(Value, InnerText) {
    SelectElement.innerHTML += '<option value="' + Value + '">' + InnerText + '</option>';
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

        PostData("https://localhost:44369/api/editproject?projectid=" + params['projectid'] + "&headline=" + projectName + "&documentation=" + projectDocumentation + "&description=" + projectDescription + "&usernames=" + studentString);
        window.location.href = "https://localhost:44334/";
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