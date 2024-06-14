using System;
using System.Web.UI.WebControls;
using BusinessLogicLayer;
using DataAccessLayer;

namespace WebApplication12
{
    public partial class BillPayment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                errorMessage.Visible = false;
            }
        }

        protected void PayButton_Click(object sender, EventArgs e)
        {
            int accountNo;
            decimal billAmount;
            if (int.TryParse(Convert.ToString(Session["AccountNo"]), out accountNo) && decimal.TryParse(billAmountLabel.Text, out billAmount))
            {
                string billType = billTypeLabel.Text;
                string billPaymentId = billNumberTextBox.Text;
                BillPaymentBL billPaymentBL = new BillPaymentBL();
                bool isPaid = billPaymentBL.PayBill(accountNo, billType, billAmount, billPaymentId);

                if (isPaid)
                {
                    errorMessage.Text = "Payment successful!";
                    errorMessage.Visible = true;
                    ClearForm();
                }
                else
                {
                    errorMessage.Text = "Payment failed. Insufficient funds.";
                    errorMessage.Visible = true;
                    ClearForm();
                }
            }
            else
            {
                errorMessage.Text = "Invalid input.";
                errorMessage.Visible = true;
                ClearForm();
            }
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            ClearForm();
        }
        private void ClearForm()
        {
            billNumberTextBox.Text = "";
            billAmountLabel.Text = "";
            billTypeLabel.Text = "";
        }


        protected void billNumberTextBox_TextChanged(object sender, EventArgs e)
        {
            errorMessage.Text = "";
            errorMessage.Visible = false;

            BillPaymentBL billPaymentBL = new BillPaymentBL();
            string billPaymentId = Convert.ToString(billNumberTextBox.Text);
            (string billType, string billAmount) = billPaymentBL.GetBillDetails(billPaymentId, Convert.ToString(Session["AccountNo"]));

            billAmountLabel.Text = billAmount;
            billTypeLabel.Text = billType;

            if (billType is null || billAmount is null)
            {
                errorMessage.Text = "Invalid Bill Id";
                errorMessage.Visible = true;
            }

        }
    }
}
