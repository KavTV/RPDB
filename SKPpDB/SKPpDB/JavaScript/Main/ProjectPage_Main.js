import { ProjectObject } from '../Util/Project.js';
import { getParams } from '../Util/Tool.js';

var params = getParams(window.location.href);

const Project = new ProjectObject();

//async () => {

//    await Project.Api_Setup(params['projectid']);

//}

async function kage() {

    await Project.Api_Setup(params['projectid']);
    console.log(Project);
}

kage();