using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication12.UI
{
    public partial class AdminSideBar : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //protected void btCustAccountInfo_Click(object sender, EventArgs e)
        //{
        //    // Handle Account Info button click
        //}

        //protected void btnAuthorizeTransaction_Click(object sender, EventArgs e)
        //{
        //    // Handle Authorize Transaction button click
        //}

        //protected void btnAuthorizeDeposit_Click(object sender, EventArgs e)
        //{
        //    // Handle Authorize Deposit button click
        //}

        //protected void btnAuthorizeMoneyOrder_Click(object sender, EventArgs e)
        //{
        //    // Handle Authorize Money Order button click
        //}

        //protected void btnSignOut_Click(object sender, EventArgs e)
        //{
         
        //}

        protected void SignOutBtn_Click(object sender, EventArgs e)
        {
            // Clear the session
            Session.Clear();
            Session.Abandon();

            // Redirect to the login or front page
            Response.Redirect("~/FrontPage.aspx");
        }
    }
}