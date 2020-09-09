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

        public List<Student> GetStudents()
        {
            return dal.GetStudents();
        }

        public List<Project> GetProjects()
        {
            return dal.GetProjects();
        }

        public void CreateProject(string headline, string documentation, string description, string username)
        {
            dal.CreateProject(headline, documentation, description, username);
        }

        public void DeleteProject(int id)
        {
            dal.DeleteProject(id);
        }
        public void EditProject(int projectid, string headline, string documentation, string description)
        {
            dal.EditProject(projectid, headline, documentation, description);
        }

        public List<MiniStudent> GetProjectStudents(int projectId)
        {
            return dal.GetProjectStudents(projectId);
        }
    }
}
