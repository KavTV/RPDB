import { ProjectManager } from './Project.js';
import config from './config.js';

const Projects = new ProjectManager(config['Project']);
Projects.Update();