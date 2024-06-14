using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using BuisnessLogicLayer;
using DataAccessLayer;

namespace WebApplication12
{
    public partial class ViewStatistics : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Set initial state if necessary
            }
        }

        protected void btnViewTransactionStats_Click(object sender, EventArgs e)
        {
            ShowStats("Transaction");
        }

        protected void btnViewBillPaymentStats_Click(object sender, EventArgs e)
        {
            ShowStats("BillPayment");
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            panelStats.Visible = false;
            btnViewTransactionStats.Visible = true;
            btnViewBillPaymentStats.Visible = true;
        }

        private void ShowStats(string statsType)
        {
            panelStats.Visible = true;
            btnViewTransactionStats.Visible = false;
            btnViewBillPaymentStats.Visible = false;

            switch (statsType)
            {
                case "Transaction":
                    lblNumOfTransactions.Text = "No. of Transactions:";
                    LoadTransactionStats();
                    break;

                case "BillPayment":
                    lblNumOfTransactions.Text = "No. of Bill Payments:";
                    LoadBillPaymentStats();
                    break;
            }

            btnBack.Visible = true;
        }

        private void LoadTransactionStats()
        {
            var adminStatsBL = new AdminStatsTransactionBL();
            int adminId = int.Parse(Session["Admin_Id"].ToString());
            int count = 0;

            string viewType = ddlTimeFrame.SelectedValue;
            List<AdminStatsTransactionData.DepositHistory> deposits = null;

            switch (viewType)
            {
                case "Weekly":
                    (deposits, count) = adminStatsBL.ViewWeeklyTransactions(adminId);
                    break;
                case "Monthly":
                    (deposits, count) = adminStatsBL.ViewMonthlyTransactions(adminId);
                    break;
                case "Yearly":
                    (deposits, count) = adminStatsBL.ViewYearlyTransactions(adminId);
                    break;
                default:
                    deposits = new List<AdminStatsTransactionData.DepositHistory>();
                    break;
            }

            gridViewStats.DataSource = deposits;
            gridViewStats.DataBind();
            txtNumOfTransactions.Text = count.ToString();
        }

        private void LoadBillPaymentStats()
        {
            var adminStatsBL = new AdminStatsBillPaymentBL();
            int adminId = int.Parse(Session["Admin_Id"].ToString());

            string viewType = ddlTimeFrame.SelectedValue;
            List<AdminStatsBillPaymentData.BillPayment> bills = null;
            int count = 0;

            switch (viewType)
            {
                case "Weekly":
                    (bills, count) = adminStatsBL.ViewWeeklyBillPayment(adminId);
                    break;
                case "Monthly":
                    (bills, count) = adminStatsBL.ViewMonthlyBillPayment(adminId);
                    break;
                case "Yearly":
                    (bills, count) = adminStatsBL.ViewYearlyBillPayment(adminId);
                    break;
                default:
                    bills = new List<AdminStatsBillPaymentData.BillPayment>();
                    break;
            }

            gridViewStats.DataSource = bills;
            gridViewStats.DataBind();
            txtNumOfTransactions.Text = count.ToString();
        }
    }
}
