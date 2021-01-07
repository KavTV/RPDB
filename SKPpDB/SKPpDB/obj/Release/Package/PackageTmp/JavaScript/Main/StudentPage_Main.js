﻿import { StudentObject } from '../Util/Student.js';
import { getParams } from '../Util/Tool.js';

var params = getParams(window.location.href);
var Student = new StudentObject();

//Element Variables
var topName = document.getElementById("top-name");
var mail = document.getElementById("mail");
var education = document.getElementById("education");
var username = document.getElementById("username");
var projects = document.getElementById("projects");


async function Main() {
    try {
        await Student.Api_Setup(params["username"]);
        console.log(Student);
    } catch (e) {
        console.error(e);
    }

    topName.innerText = Student.Name;
    mail.innerText = `${Student.Username}@zbc.dk`
    education.innerText = Student.Education;
    username.innerText = Student.Username;

    Student.Projects.forEach(project => {
        projects.innerHTML += `<a href="Project.aspx?projectid=${project.ID}">${project.Headline}</a><br>`;
    });
}

Main();