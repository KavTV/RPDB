using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Cryptography;
using System.Text;

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
        /// <summary>
        /// Get the comments on 1 project
        /// </summary>
        /// <param name="projectid"></param>
        /// <returns></returns>
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
                try
                {
                    return BCrypt.Net.BCrypt.Verify(pwd, hash);
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return false;
        }
        /// <summary>
        /// Sets and hashes the users password
        /// </summary>
        /// <returns>True if password set</returns>
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
        /// <summary>
        /// Get the username of the user with the token
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public string GetResetTokenUsername(string token)
        {
            //Using sha to hash token and tries to find match i database.
            SHA256 sha = SHA256.Create();
            token = sha.ComputeHash(Encoding.UTF8.GetBytes(token)).ToString();
            sha.Dispose();
            return dal.GetResetTokenUsername(token);
        }
        /// <summary>
        /// Creates a token and sends it to the users email if user exists.
        /// </summary>
        /// <param name="username"></param>
        /// <returns>True if token is created and email sent</returns>
        public bool CreateResetToken(string username)
        {
            //Checks if username exists
            if (dal.GetStudent(username) != null)
            {
                //make random string 

                string token = WebUtility.UrlEncode(Convert.ToBase64String(Guid.NewGuid().ToByteArray()));
                SHA256 sha = SHA256.Create();
                string hashed = sha.ComputeHash(Encoding.UTF8.GetBytes(token)).ToString();

                if (dal.SetToken(username, hashed))
                {
                    sha.Dispose();
                    //send email with the token
                    try
                    {

                        Email email = new Email();

                        string mail = username + "@zbc.dk";
                        string message = "Brug dette link til at reset dit password: https://projektdatabase.skprg.dk/Reset.aspx?tkn=" + token;
                        email.SendEmail(mail, "Reset Password, SKP PDB", message);

                        return true;
                    }
                    catch (Exception)
                    {

                        return false;
                    }
                }
                sha.Dispose();
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
        /// <summary>
        /// Checks if the project exists
        /// </summary>
        /// <param name="projectid"></param>
        /// <returns>True if project exists</returns>
        public bool ProjectExists(int projectid)
        {
            return dal.ProjectExist(projectid);
        }
    }
}
