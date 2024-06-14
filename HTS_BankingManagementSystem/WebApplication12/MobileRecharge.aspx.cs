using System;
using System.Text.RegularExpressions;
using System.Web.UI;
using BusinessLogicLayer;

namespace WebApplication12
{
    public partial class MobileRecharge : Page
    {
        private readonly MobileRechargeBL _mobileRechargeBL;

        public MobileRecharge()
        {
            _mobileRechargeBL = new MobileRechargeBL();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Check if the user is logged in
                if (Session["AccountNo"] == null)
                {
                    // Redirect to login page if not logged in
                    Response.Redirect("~/CustomerLoginPage.aspx");
                }
            }
        }

        protected void ProceedButton_Click(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                string mNetwork = mobileNetwork.SelectedValue;
                string mNumber = mobileNumber.Text;

                // Ensure the 'amount' control is not null
                if (amount != null)
                {
                    string amountText = amount.Text;

                    if (string.IsNullOrEmpty(mNetwork) || string.IsNullOrEmpty(mNumber) || string.IsNullOrEmpty(amountText))
                    {
                        // Show a message to fill all fields
                        ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Please fill out all fields.');", true);
                        return;
                    }

                    if (!int.TryParse(amountText, out int amountValue) || !IsPhoneNumberValid(mNumber))
                    {
                        // Show a message for invalid input
                        ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Please enter valid numerical values.');", true);
                        return;
                    }

                    if (Session["AccountNo"] != null)
                    {
                        int senderAccountNo = (int)Session["AccountNo"];

                        // Retrieve the receiver account number from the business logic layer
                        string result = _mobileRechargeBL.Recharge(senderAccountNo, amountValue, mNetwork, mNumber);
                        ScriptManager.RegisterStartupScript(this, GetType(), "alert", $"alert('{result}');", true);
                        ClearForm();
                    }
                    else
                    {
                        // Show a message for session expiry
                        //2 ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Session expired. Please log in again.');", true);
                        //Response.Redirect("~/CustomerLogin.aspx");
                    }
                }
                else
                {
                    // Handle the case where 'amount' control is null
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Amount field is not initialized properly.');", true);
                }
            }
        }

        private bool IsPhoneNumberValid(string mNumber)
        {
            // Define a regular expression pattern to match 11 numeric characters
            string pattern = @"^\d{11}$";

            // Check if the phone number matches the pattern
            return Regex.IsMatch(mNumber, pattern);
        }
        private void ClearForm()
        {
            amount.Text = "";
            mobileNumber.Text = "";
        }
    }
}

