using System;
using System.Collections.Generic;

namespace SKPDB_Library
{
    public class Manager
    {
        Dal dal;


        public Manager(string connectionString)
        {
            dal = new Dal(connectionString);

        }

        /// <summary>
        /// Returns a list with all students and their projects
        /// </summary>
        /// <returns></returns>
        public List<Student> GetStudents()
        {
            return dal.GetStudents();
        }
        /// <summary>
        /// Returns a list with all projects, and all students in the project
        /// </summary>
        /// <returns></returns>
        public List<Project> GetProjects()
        {
            return dal.GetProjects();
        }
        /// <summary>
        /// Creates a project
        /// </summary>
        /// <returns>True if completed</returns>
        public bool CreateProject(int status, string projectmanager, string headline, string documentation, string description, DateTime startdate, DateTime enddate, string[] usernames)
        {
            return dal.CreateProject(status, projectmanager, headline, documentation, description, startdate, enddate, usernames);
        }
        /// <summary>
        /// Deletes the project
        /// </summary>
        /// <param name="projectid">Id of project</param>
        /// <returns>True if completed</returns>
        public bool DeleteProject(int id)
        {
            return dal.DeleteProject(id);
        }
        /// <summary>
        /// Edits the whole project
        /// </summary>
        /// <returns>True if completed</returns>
        public bool EditProject(int projectid, int status, string projectmanager, string headline, string documentation, string description, DateTime startdate, DateTime enddate, string[] usernames)
        {
            return dal.EditProject(projectid, status, projectmanager, headline, documentation, description, startdate, enddate, usernames);
        }
        /// <summary>
        /// Returns a list with all students in the project
        /// </summary>
        /// <param name="projectId">Id of project</param>
        public List<MiniStudent> GetProjectStudents(int projectId)
        {
            return dal.GetProjectStudents(projectId);
        }
        /// <summary>
        /// Returns a single Student object
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public Student GetStudent(string username)
        {
            return dal.GetStudent(username);
        }
        /// <summary>
        /// Returns a single project object
        /// </summary>
        /// <param name="projectId">Id of the project</param>
        public Project GetProject(int projectId)
        {
            return dal.GetProject(projectId);
        }

        /// <summary>
        /// Adds a user to a project
        /// </summary>
        /// <returns>True if completed</returns>
        public bool AddToProject(int projectid, string username)
        {
            return dal.AddToProject(projectid, username);
        }
        /// <summary>
        /// Removes a user from project
        /// </summary>
        /// <returns>True if completed</returns>
        public bool RemoveFromProject(int projectid, string username)
        {
            return dal.RemoveFromProject(projectid, username);
        }

        /// <summary>
        /// Returns a list with all projects, and all students in the project that the user searched for
        /// </summary>
        /// <returns></returns>
        public List<Project> SearchProjects(string search)
        {
            return dal.SearchProjects(search);
        }

        /// <summary>
        /// Returns a list with all students and their projects that the user searched for
        /// </summary>
        /// <returns></returns>
        public List<Student> SearchStudents(string search)
        {
            return dal.SearchStudents(search);
        }
        public bool CreateComment(int projectid, string username, string msg)
        {
            return dal.CreateComment(projectid, username, msg);
        }

        public List<Comment> GetProjectComments(int projectid)
        {
            return dal.Getprojectcomments(projectid);
        }
        /// <summary>
        /// Checks the password is correct
        /// </summary>
        /// <returns>True if password matches.</returns>
        public bool VerifyPwd(string username, string pwd)
        {
            string hash = dal.GetUserPwd(username);
            if (hash != null)
            {
                //Returns true if the password matches
                return BCrypt.Net.BCrypt.Verify(pwd, hash);
            }
            return false;
        }
        public bool SetPwd(string username, string pwd)
        {
            string hashed = BCrypt.Net.BCrypt.HashPassword(pwd, 10, BCrypt.Net.SaltRevision.Revision2B);
            //Save the hashed password
            return dal.SetPwd(username, hashed);
        }
        public string GetAuthToken(string username)
        {
            return dal.GetAuthToken(username);
        }
        public string GetResetTokenUsername(string token)
        {
            return dal.GetResetTokenUsername(token);
        }
        public bool MakeResetToken(string username)
        {
            string token = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
            string hashed = BCrypt.Net.BCrypt.HashPassword(token);

            if (dal.SetToken(username, hashed))
            {
                //send email with the token


                return true;
            }
            return false;
        }
        public int GetUserEducation(string username)
        {
            return dal.GetUserEducation(username);
        }

        /// <summary>
        /// Changes the status of a project
        /// </summary>
        /// <param name="projectid"></param>
        /// <param name="statusid"> 1 = Færdig, 2 = Aktiv, 3 = Mangler folk, 4 = standby, 5 = ikke startet</param>
        /// <returns>True if changed successfully</returns>
        public bool SetProjectStatus(int projectid, int statusid)
        {
            return dal.SetProjectStatus(projectid, statusid);
        }
    }
}
