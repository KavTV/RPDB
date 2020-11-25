using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SKPDB_Library;


namespace SKPpDB
{
    public partial class Login : System.Web.UI.Page
    {
        private Manager manager = new Manager(ConfigurationManager.ConnectionStrings["default"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = "";
            //If user is already logged in, then redirect to default page.
            if (Session["username"] != null)
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void SubmitBTN_Click(object sender, EventArgs e)
        {
            string username = UsernameBox.Text;
            string pwd = PasswordBox.Text;
            //if the username and password is verified, start a session.
            if (manager.VerifyPwd(username, pwd))
            {
                //Save the username to the session
                Session["username"] = username;

                //If the user is instruktør, give admin access
                if (manager.GetUserEducation(username) == 3)
                {
                    Session["admin"] = true;
                }
                else
                {
                    Session["admin"] = false;
                }
                //redirect user to the default page.
                Response.Redirect("Default.aspx");

            }
            else
            {
                Label1.Text = "Adgang nægtet";
            }

        }

        protected void ResetBTN_Click(object sender, EventArgs e)
        {
            Response.Redirect("ResetPage.aspx");
        }
    }
}