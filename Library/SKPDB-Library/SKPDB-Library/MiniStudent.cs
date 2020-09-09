using System;
using System.Collections.Generic;
using System.Text;

namespace SKPDB_Library
{
    public class MiniStudent
    {
        public string Username { get { return username; } }
        public string Education { get { return education; } }
        public string Name { get { return name; } }

        string username;
        string education;
        string name;


        public MiniStudent(string username, string education, string name)
        {
            this.username = username;
            this.education = education;
            this.name = name;
        }
    }
}
