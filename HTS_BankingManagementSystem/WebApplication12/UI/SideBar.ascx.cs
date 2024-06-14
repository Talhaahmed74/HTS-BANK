using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication12.UI
{
    public partial class SideBar : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAccountInfo_Click(object sender, EventArgs e)
        {

        }

        protected void btnTransaction_Click(object sender, EventArgs e)
        {

        }

        protected void btnBillPayment_Click(object sender, EventArgs e)
        {

        }

        protected void btnTransactionHistory_Click(object sender, EventArgs e)
        {

        }

        protected void btnPinChange_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnCashWithdrawal_Click(object sender, EventArgs e)
        {

        }

        protected void btnCashDeposit_Click(object sender, EventArgs e)
        {

        }

        protected void btnSignOut_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("FrontPage.aspx");
        }

        protected void btnMobileRecharge_Click(object sender, EventArgs e)
        {
            Response.Redirect("MobileRecharge,aspx");
        }
    }
}