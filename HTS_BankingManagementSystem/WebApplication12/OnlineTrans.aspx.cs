using System;
using BusinessLogicLayer;

namespace WebApplication12
{
    public partial class OnlineTrans : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ProceedButton_Click(object sender, EventArgs e)
        {
            if (Session["AccountNo"] == null)
            {
                Response.Redirect("~/CustomerLoginPage.aspx");
                return;
            }

            int currentAccountNumber = (int)Session["AccountNo"];
            int receiverAccountNumber;
            decimal amount;

            if (int.TryParse(txtAccountNumber.Text, out receiverAccountNumber) && decimal.TryParse(txtAmount.Text, out amount))
            {
                // Create an instance of TransactionBLL from the business logic layer
                TransactionBLL bll = new TransactionBLL();

                // Call the PerformTransaction method to perform the transaction
                string message = bll.PerformTransaction(receiverAccountNumber, amount, currentAccountNumber);

                // Display the result message
                ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('{message}');", true);
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Invalid input. Please enter valid account number and amount.');", true);
            }
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Dashboard.aspx");
        }
    }
}
