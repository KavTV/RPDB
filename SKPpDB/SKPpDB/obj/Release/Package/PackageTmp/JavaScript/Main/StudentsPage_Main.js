import { StudentManager } from '../Util/Student.js';
import config from '../Util/config.js';

const Students = new StudentManager(config['StudentTable']);
Students.Update();