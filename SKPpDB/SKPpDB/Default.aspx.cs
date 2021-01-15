using System;

namespace SKPpDB
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (Session["admin"].Equals(true))
            {
                CreateStudentBTN.Visible = true;
            }
        }

        protected void CreateStudent_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateStudent.aspx");
        }

        protected void CreateProject_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateProject.aspx");
        }
    }
}