﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SKPDB_Library;

namespace SKPpDB
{
    public partial class EditProject : System.Web.UI.Page
    {
        Manager manager = new Manager(Constants.ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void EditButton_Click(object sender, EventArgs e)
        {
            string query = Request.QueryString["projectid"];
            if (string.IsNullOrWhiteSpace(query))
            {
                return;
            }
            try
            {
                int queryint = int.Parse(query);

                manager.EditProject(queryint, HeadlineText.Value, DocumentationText.Value, DescriptionText.Value);

            }
            catch (Exception)
            {

            }


        }
    }
}