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
            // Retrieve account number from session
            if (Session["AccountNo"] == null)
            {
                Response.Redirect("~/CustomerLoginPage.aspx");
                return;
            }

            int currentAccountNumber = (int)Session["AccountNo"];
            int receiverAccountNumber;
            decimal amount;

            // Validate receiver account number and amount input
            if (int.TryParse(txtAccountNumber.Text, out receiverAccountNumber) && decimal.TryParse(txtAmount.Text, out amount))
            {
                // Create an instance of TransactionBLL from the business logic layer
                TransactionBLL bll = new TransactionBLL();

                // Call the PerformTransaction method to perform the transaction
                string message = bll.PerformTransaction(receiverAccountNumber, amount, currentAccountNumber);

                // Display the result message
                Response.Write($"<script>alert('{message}');</script>");
            }
            else
            {
                Response.Write("<script>alert('Invalid input. Please enter valid account number and amount.');</script>");
            }
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Dashboard.aspx");
        }
    }
}
