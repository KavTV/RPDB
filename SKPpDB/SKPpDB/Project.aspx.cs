using SKPDB_Library;
using System;

namespace SKPpDB
{
    public partial class WatchProject : System.Web.UI.Page
    {
        private Manager manager = new Manager("Server = 10.108.48.80; Port=5432; User Id = postgres; Password=Kode123; Database=SKPDB;");

        protected void Page_Load(object sender, EventArgs e)
        {
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