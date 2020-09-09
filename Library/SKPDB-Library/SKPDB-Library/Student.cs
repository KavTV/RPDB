using System;
using System.Collections.Generic;
using System.Text;

namespace SKPDB_Library
{
    public class Student
    {
        public string Username { get { return username; } }
        public string Education { get { return education; } }
        public string Name { get { return name; } }
        public List<MiniProject> ProjectList{ get { return projectList; } }

        string username;
        string education;
        string name;
        List<MiniProject> projectList;

        public Student(string username, string education, string name, List<MiniProject> projectList)
        {
            this.username = username;
            this.education = education;
            this.name = name;
            this.projectList = projectList;
        }
    }
}
