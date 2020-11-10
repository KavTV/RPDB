import { ProjectManager } from '../Util/Project.js';
import config from '../Util/config.js';

const Projects = new ProjectManager(config['ProjectTable']);
Projects.Update();