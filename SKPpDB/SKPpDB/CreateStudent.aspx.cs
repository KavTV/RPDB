using SKPDB_Library;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SKPpDB
{
    public partial class CreateStudent : System.Web.UI.Page
    {
        private Manager manager = new Manager(ConfigurationManager.ConnectionStrings["default"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            //Make sure only admins access this page
            if (Session["admin"].Equals(false))
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void CreateStudent_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(usernameBox.Text) || string.IsNullOrWhiteSpace(fullnameBox.Text))
            {
                errorLabel.Text = "Du har ikke udfyldt alle felter";
                return;
            }
            if (manager.CreateStudent(usernameBox.Text, int.Parse(educationList.SelectedValue), fullnameBox.Text))
            {
                errorLabel.Text = usernameBox.Text + " er nu oprettet!";
            }
            else
            {
                errorLabel.Text = "Noget gik galt!";
            }
        }
    }
}