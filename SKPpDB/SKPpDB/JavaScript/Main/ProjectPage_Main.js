import { ProjectObject } from '../Util/Project.js';
import { getParams, SimpleDate } from '../Util/Tool.js';

var params = getParams(window.location.href);
const Project = new ProjectObject();

//HTML Element Variables
var toptitle = document.getElementById("top-title");
var status = document.getElementById("status");
var description = document.getElementById("description");
var Projectmanager = document.getElementById("Projectmanager");
var startDate = document.getElementById("startdate");
var endDate = document.getElementById("enddate");
var students = document.getElementById("students");

//Void Main
async function Main() {

    try {
        await Project.Api_Setup(params['projectid']);
    } catch (e) {
        console.error(e);
    }
    console.log(Project);

    if (Project.Headline) {

        toptitle.innerText = Project.Headline;
        Projectmanager.innerText = Project.ProjectManager;
        description.innerText = Project.Description;
        startDate.innerText = SimpleDate(Project.StartDate);
        endDate.innerText = SimpleDate(Project.EndDate);
        status.innerText = Project.StatusId;

        Project.Students.forEach(student => {
            console.log(student);
            students.innerHTML += `<a href="https://localhost:44334/Student.aspx?username=${student.Username}">${student.Name}</a><br>`;
        });
    }
    else {
        document.getElementById("Box").innerHTML = "<h2 class=\"MiddleBox\">Der Skete en fejl prøv igen senere</h2>";
    }
}

Main();