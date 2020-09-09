using System;
using System.Collections.Generic;
using System.Text;

namespace SKPDB_Library
{
    public class Project
    {
        public int Id { get { return id;} }
        public string Headline { get { return headline; } }
        public string Documentation { get { return documentation; } }
        public string Description{ get { return description; } }
        public List<MiniStudent> Students { get { return studentList; } }

        private int id;
        private string headline;
        private string documentation;
        private string description;
        private List<MiniStudent> studentList;


        public Project(int id,string headline, string documentation, string description, List<MiniStudent> studentList)
        {
            this.id = id;
            this.headline = headline;
            this.documentation = documentation;
            this.description = description;
            this.studentList = studentList;
        }

    }
}
