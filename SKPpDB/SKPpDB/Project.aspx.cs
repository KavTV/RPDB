using SKPDB_Library;
using System;
using System.Configuration;

namespace SKPpDB
{
    public partial class WatchProject : System.Web.UI.Page
    {
        private Manager manager = new Manager(ConfigurationManager.ConnectionStrings["default"].ConnectionString);
        int projectid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            //Get the projectid parameter from url
            
            int.TryParse(Request.QueryString["projectid"], out projectid);
            if (manager.ProjectExists(projectid))
            {
                if (Session["username"] != null)
                {
                    if (Session["admin"].Equals(true))
                    {
                        EditBTN.Visible = true;
                        DeleteBTN.Visible = true;
                    }
                    else if (Session["username"].ToString() == manager.GetProject(projectid).Projectmanager)
                    {
                        EditBTN.Visible = true;
                    }
                }
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
            //Load comments
            commentList.DataSource = manager.GetProjectComments(projectid);
            commentList.DataBind();

            
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

        protected void CreateComment(object sender, EventArgs e)
        {
            //Ignore if nothing is written in comment field.
            if (string.IsNullOrWhiteSpace(createCommentBox.Text))
            {
                return;
            }
            //Create the comment in database
            if (manager.CreateComment(projectid, Session["username"].ToString(), createCommentBox.Text))
            {
                //created successfully
                errorLabel.Text = "Kommentar er oprettet!";
                createCommentBox.Text = "";
            }
            else
            {
                errorLabel.Text = "Der skete en fejl";
            }
        }
    }
}