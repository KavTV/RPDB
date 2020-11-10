import { ProjectManager } from './Project.js';
import { Student } from './Student.js';
import config from './config.js';

const Projects = new ProjectManager(config['ProjectTable']);
Projects.Update();