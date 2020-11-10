using System;
using System.Collections.Generic;
using System.Text;

namespace SKPDB_Library
{
    public class Project
    {
        public int Id { get { return id;} }
        public int Statusid { get { return statusid; } }
        public string Projectmanager { get { return projectmanager; } }
        public string Headline { get { return headline; } }
        public string Documentation { get { return documentation; } }
        public string Description{ get { return description; } }
        public DateTime Startdate { get { return startdate; } }
        public DateTime Enddate { get { return enddate; } }

        public List<MiniStudent> Students { get { return studentList; } }

        private int id;
        private int statusid;
        private string projectmanager;
        private string headline;
        private string documentation;
        private string description;
        private DateTime startdate;
        private DateTime enddate;
        private List<MiniStudent> studentList;


        public Project(int id,int statusid, string projectmanager, string headline, string documentation, string description, DateTime startdate, DateTime enddate, List<MiniStudent> studentList)
        {
            this.id = id;
            this.statusid = statusid;
            this.projectmanager = projectmanager;
            this.headline = headline;
            this.documentation = documentation;
            this.description = description;
            this.startdate = startdate;
            this.enddate = enddate;
            this.studentList = studentList;
        }

    }
}
