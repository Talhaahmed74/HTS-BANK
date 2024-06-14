using System;
using BusinessLogicLayer;

namespace WebApplication12
{
    public partial class AuthorizeDeposit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ProceedButton_Click(object sender, EventArgs e)
        {
            int accountNumberValue;
            decimal amountValue;

            // Access the Text property from the TextBox controls
            string accountNumberText = accountNumber.Text;
            string amountText = amount.Text;

            if (int.TryParse(accountNumberText, out accountNumberValue) && decimal.TryParse(amountText, out amountValue))
            {
                AuthorizeDepositBL authorizeDepositBL = new AuthorizeDepositBL();
                bool success = authorizeDepositBL.DepositAmount(accountNumberValue, amountValue);

                if (success)
                {
                    // After processing, clear the text fields
                    accountNumber.Text = "";
                    amount.Text = "";

                    // Display a message indicating that the deposit is done
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Deposit done!');", true);
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Failed to process deposit.');", true);
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Invalid input.');", true);
            }
        }
    }
}
