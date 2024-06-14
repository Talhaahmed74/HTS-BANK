using System;
using System.Globalization;
using System.Threading;
using System.Collections.Generic;
using BusinessLogicLayer;

namespace WebApplication12
{
    public partial class TransHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Set culture to Pakistani Rupees (PKR)
            CultureInfo pakistaniCulture = new CultureInfo("en-PK");
            Thread.CurrentThread.CurrentCulture = pakistaniCulture;
            Thread.CurrentThread.CurrentUICulture = pakistaniCulture;

            if (Session["LoggedIn"] == null || (bool)Session["LoggedIn"] == false)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                BindTransactionHistory();
            }
        }

        private void BindTransactionHistory()
        {
            int accountNo = (int)Session["AccountNo"];
            TransactionHistoryBL transactionHistoryBL = new TransactionHistoryBL();
            var transactions = transactionHistoryBL.GetTransactionHistory(accountNo);

            GridView1.DataSource = transactions;
            GridView1.DataBind();
        }
    }
}
