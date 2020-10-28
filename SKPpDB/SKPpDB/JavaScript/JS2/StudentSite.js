import { StudentManager } from './Student.js';
import config from './config.js';

const Students = new StudentManager(config['StudentTable']);
Students.Update();