using SKPDB_Library;
using System;
using System.Configuration;

namespace SKPpDB
{
    public partial class WatchProject : System.Web.UI.Page
    {
        private Manager manager = new Manager(ConfigurationManager.ConnectionStrings["default"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {

            ////Get the id from query, and 
            //int projectid = 0;
            //int.TryParse(Request.QueryString["projectid"], out projectid);
            //if (projectid != 0)
            //{
            //    StatusList.SelectedValue = manager.GetProject(projectid).Statusid.ToString();
            //}
        }

        protected void DeleteBTN_Click(object sender, EventArgs e)
        {
            string query = Request.QueryString["projectid"];
            if (string.IsNullOrWhiteSpace(query))
            {
                return;
            }
            try
            {
                int queryint = int.Parse(query);
                manager.DeleteProject(queryint);
            }
            catch (Exception)
            {
            }
        }

        protected void Redirect_Click(object sender, EventArgs e)
        {
            string query = Request.QueryString["projectid"];
            Response.Redirect($"EditProject.aspx?projectid={query}");
        }
    }
}