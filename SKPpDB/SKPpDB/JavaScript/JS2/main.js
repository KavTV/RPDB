import { ProjectManager } from './Project.js';
import config from './config.js';
import { Student } from './Student.js';

const student = new Student();

const Projects = new ProjectManager(config['Project']);
Projects.Update();