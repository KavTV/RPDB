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
        public bool CreateProject(string headline, string documentation, string description, string[] usernames)
        {
            return dal.CreateProject(headline, documentation, description, usernames);
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
        public bool EditProject(int projectid, string headline, string documentation, string description, string[] usernames)
        {
            return dal.EditProject(projectid, headline, documentation, description, usernames);
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
    }
}
