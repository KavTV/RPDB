var SelectElement = document.getElementById("Students");
var studentBox = document.getElementById("studentBox");
var StudentListBox = document.getElementById("SelectedStudents");
var StudentIndexList = [];
var students = FetchJson("https://localhost:44369/api/students").done(function() {
    if (students.responseJSON != null) {
        LoadSelect();
    }
}).fail(function() {
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

    if (StudentIndexList.find(element => element == SelectElement.selectedIndex) != SelectElement.selectedIndex) {        
        StudentIndexList.push(SelectElement.selectedIndex);
        optionElement.disabled = true;
        SelectElement.selectedIndex++;
        StudentListBox.innerHTML += '<option value="' + student["Username"] + '">' + student["Name"] + ' (' + student["Education"] + ')' + '</option>';
    }
}

function RemoveSelectedStudent() {
    SelectElement.options[StudentIndexList[StudentListBox.selectedIndex]].disabled = false;
    StudentIndexList.splice(StudentListBox.selectedIndex, 1);
    StudentListBox.selectedOptions[0].remove();
}