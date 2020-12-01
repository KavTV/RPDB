using System;
using System.Configuration;
using SKPDB_Library;

namespace SKPpDB
{
    public partial class EditProject : System.Web.UI.Page
    {
        private Manager manager = new Manager(ConfigurationManager.ConnectionStrings["default"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            //Get url parameter
            int projectid = 0;
            int.TryParse(Request.QueryString["projectid"], out projectid);
            //Check if the project exists, and a user is logged in
            if (projectid != 0 && Session["username"] != null && manager.ProjectExists(projectid))
            {
                if (manager.GetProject(projectid).Projectmanager != Session["username"].ToString())
                {
                    Response.Redirect("Default.aspx");
                }
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void EditButton_Click(object sender, EventArgs e)
        {
        }
    }
}