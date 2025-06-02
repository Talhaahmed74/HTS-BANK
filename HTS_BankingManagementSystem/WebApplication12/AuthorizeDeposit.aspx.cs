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
            string accountNumberText = accountNumber.Text;
            string amountText = amount.Text;

            if (int.TryParse(accountNumberText, out accountNumberValue) && decimal.TryParse(amountText, out amountValue))
            {
                if (amountValue < 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Amount cannot be less than zero.');", true);
                    return; 
                }

                AuthorizeDepositBL authorizeDepositBL = new AuthorizeDepositBL();
                bool success = authorizeDepositBL.DepositAmount(accountNumberValue, amountValue);

                if (success)
                {
                    accountNumber.Text = "";
                    amount.Text = "";

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
