using System;
using System.Web.UI;
using BusinessLogicLayer; // Correct namespace

namespace WebApplication12.UI
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        private AdminLoginBL adminLoginBL = new AdminLoginBL();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnSignIn_Click(object sender, EventArgs e)
        {
            int adminID;
            if (!int.TryParse(txtAdminID.Text, out adminID))
            {
                checkLbl.Text = "Please enter a valid account number.";
                return;
            }

            bool loginResult = adminLoginBL.VerifyAdminLogin(adminID, txtPassword.Text);

            if (loginResult)
            {
                // Set session variables
                Session["AdminLoggedIn"] = true;
                Session["Admin_Id"] = adminID; // Save admin's account number

                checkLbl.Text = "Valid account number or password.";
                Response.Redirect("AdminDefaultDash.aspx");
            }
            else
            {
                checkLbl.Text = "Invalid account number or password.";
            }
        }
    }
}
