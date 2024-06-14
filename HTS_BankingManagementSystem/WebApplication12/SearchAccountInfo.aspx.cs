using System;
using System.Web.UI;

namespace WebApplication12
{
    public partial class SearchAccountInfo : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Initialization logic if needed
            }
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            int accountNo;
            if (int.TryParse(accountNumberTextBox.Text, out accountNo))
            {
                // Check if the admin ID is stored in the session
                if (Session["Admin_Id"] != null && Session["Admin_Id"] is int)
                {
                    int adminId = (int)Session["Admin_Id"];
                    accountNo = int.Parse(accountNumberTextBox.Text);
                    BusinessLogicLayer.SearchAccountInfoBL searchAccountInfoBL = new BusinessLogicLayer.SearchAccountInfoBL();
                    DataAccessLayer.AccountInfo accountInfo = searchAccountInfoBL.GetAccountInfo(accountNo, adminId);

                    if (accountInfo != null)
                    {
                        // Display retrieved account information
                        firstName.Text = accountInfo.FirstName;
                        lastName.Text = accountInfo.LastName;
                        fatherName.Text = accountInfo.FatherName;
                        age.Text = accountInfo.Age.ToString();
                        gender.Text = accountInfo.Gender;
                        email.Text = accountInfo.Email;
                        balance.Text = accountInfo.Balance.ToString();
                        phoneNumber.Text = accountInfo.PhoneNumber;
                        address.Text = accountInfo.Address;
                        branch.Text = accountInfo.Branch;
                        cnic.Text = accountInfo.CNIC;
                        accountType.Text = accountInfo.AccountType;

                        // Show account info container and hide search container
                        ClientScript.RegisterStartupScript(this.GetType(), "showAccountInfo", "showAccountInfo();", true);
                    }
                    else
                    {
                        // Handle invalid account number
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Account not found');", true);
                    }
                }
                else
                {
                    // Handle missing or invalid admin ID in session
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Admin ID not found in session');", true);
                }
            }
            else
            {
                // Handle invalid input (non-numeric account number)
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Invalid account number');", true);
            }
        }
    }
}
