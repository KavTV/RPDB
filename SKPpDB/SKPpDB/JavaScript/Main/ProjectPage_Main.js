import { ProjectObject } from '../Util/Project.js';
import { getParams } from '../Util/Tool.js';

var params = getParams(window.location.href);
const Project = new ProjectObject();

//HTML Element Variables
var toptitle = document.getElementById("top-title");
var title = document.getElementById("title");


//Void Main
async function Main() {

    await Project.Api_Setup(params['projectid']);
    console.log(Project);

    toptitle.innerText = Project.Headline;
    title.innerText = Project.Headline;
}

Main();