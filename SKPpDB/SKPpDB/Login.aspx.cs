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

        }

        protected void SubmitBTN_Click(object sender, EventArgs e)
        {
            string username = UsernameBox.Text;
            string pwd = PasswordBox.Text;

            if (manager.AuthenticatePwd(username, pwd))
            {
                //Do some fancy session stuff.
                Label1.Text = "Du har adgang";
            }
            else
            {
                Label1.Text = "Fuck dig";
            }
            
        }
    }
}