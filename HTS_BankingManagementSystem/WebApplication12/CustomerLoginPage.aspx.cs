using System;
using System.Web.UI;
using BusinessLogicLayer;

namespace WebApplication12.UI
{
    public partial class CustomerLoginPage : Page
    {
        CustomerLoginBL lp = new CustomerLoginBL();

        protected void Page_Load(object sender, EventArgs e)
        {
            // Check if the user is already logged in
            if (Session["LoggedIn"] != null && (bool)Session["LoggedIn"] == true && string.IsNullOrEmpty(Convert.ToString(Session["AccountNo"])))
            {
                Response.Redirect("Dashboard.aspx"); // Redirect to Dashboard if already logged in
            }
            if(Session["PageVisited"] != null)
            {
                
                string script = "The acccount is already siugned in";
                ClientScript.RegisterStartupScript(this.GetType() , "alert" , script , true);
                return;

            }
            else
            {
                Session["PageVisited"] = true;
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            int accountNo = int.Parse(txtAccountNumber.Text);
            string password = txtPassword.Text;

            bool loginResult = lp.verifyCustomerLogin(accountNo, password);

            if (loginResult)
            {
                // Set session variables upon successful login
                Session["LoggedIn"] = true;
                Session["AccountNo"] = accountNo;

                Response.Redirect("Dashboard.aspx");
            }
            else
            {
                lblText.Visible = true;
                lblText.Text = "Invalid username or password";
            }
        }

        protected void btnSignup_Click(object sender, EventArgs e)
        {
            Session["PageVisited"] = null;
            Response.Redirect("SIGNUP.aspx");
        }
    }
}