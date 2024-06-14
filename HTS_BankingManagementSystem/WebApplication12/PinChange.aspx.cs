using System;
using BusinessLogicLayer;

namespace WebApplication12
{
    public partial class PinChange : System.Web.UI.Page
    {
        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            // Retrieve account number from session
            int accountNo = (int)Session["AccountNo"];

            // Retrieve current password, new password, and confirm password from textboxes
            string currentPass = currentPassword.Text;
            string newPass = newPassword.Text;
            string confirmPass = confirmPassword.Text;

            // Create an instance of PasswordChangeBL from the business logic layer
            PasswordChangeBL passwordChangeBL = new PasswordChangeBL();

            // Call the ChangePassword method to update the password
            string resultMessage = passwordChangeBL.ChangePassword(accountNo, currentPass, newPass, confirmPass);

            // Display the result message
            resultLabel.Visible = true;
            resultLabel.Text = resultMessage;
        }


        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Dashboard.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}
