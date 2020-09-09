using System;
using System.Collections.Generic;
using System.Text;

namespace SKPDB_Library
{
    public class MiniProject
    {
        public int Id { get { return id; } }
        public string Headline { get { return headline; } }
        public string Documentation { get { return documentation; } }
        public string Description { get { return description; } }

        private int id;
        private string headline;
        private string documentation;
        private string description;


        public MiniProject(int id, string headline, string documentation, string description)
        {
            this.id = id;
            this.headline = headline;
            this.documentation = documentation;
            this.description = description;
        }
    }
}
