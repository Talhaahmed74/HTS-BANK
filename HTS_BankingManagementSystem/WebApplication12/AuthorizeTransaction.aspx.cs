using BuisnessLogicLayer;
using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static DataAccessLayer.TransactionHistoryData;

namespace WebApplication12
{
    public partial class AuthorizeTransaction : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CultureInfo pakistaniCulture = new CultureInfo("en-PK");
            Thread.CurrentThread.CurrentCulture = pakistaniCulture;
            Thread.CurrentThread.CurrentUICulture = pakistaniCulture;
            if (!IsPostBack)
            {
                ShowSearchControls();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            List<Transaction> transactions = GetTransactions(txtAccountNumber.Text);
            GridView1.DataSource = transactions;
            GridView1.DataBind();
             
            ShowGridView();
        }

        private List<Transaction> GetTransactions(string accountNumber)
        {
            int accountNo = int.Parse(txtAccountNumber.Text);
            TransactionHistoryBL transactionHistoryBL = new TransactionHistoryBL();
            return transactionHistoryBL.GetTransactionHistory(accountNo);
        }

        private void ShowSearchControls()
        {
            txtAccountNumber.Visible = true;
            btnSearch.Visible = true;
            GridView1.Visible = false;
        }

        private void ShowGridView()
        {
            txtAccountNumber.Visible = false;
            lblAccountNumber.Visible = false;
            btnSearch.Visible = false;
            GridView1.Visible = true;
        }
    }
}
