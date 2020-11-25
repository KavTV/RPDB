using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SKPDB_Library;
using System.Configuration;

namespace SKPpDB
{
    public partial class Reset : System.Web.UI.Page
    {
        private Manager manager = new Manager(ConfigurationManager.ConnectionStrings["default"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Request.QueryString["tkn"]))
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void ResetBTN_Click(object sender, EventArgs e)
        {
            //Get the token from url and find the user with the token.
            string username = manager.GetResetTokenUsername(Request.QueryString["tkn"]);
            
            //Sets the password, and returns true if password reset was successful.
            if (manager.SetPwd(username, PasswordBox.Text))
            {
                Response.Redirect("DefaultV2.aspx");
            }
            else
            {
                ErrorLabel.Text = "Unable to change password";
            }

        }
    }
}