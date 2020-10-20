import { ProjectManager } from './Project.js';

const Projects = new ProjectManager();
Projects.Update();

document.getElementById('Update').addEventListener("click", function () { Projects.Update();});

