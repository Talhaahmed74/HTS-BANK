using System;
using System.Web.UI;

namespace WebApplication12.UI
{
    public partial class FrontPage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnAdmin_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminLogin.aspx");
        }

        protected void btnCustomer_Click(object sender, EventArgs e)
        {
            Response.Redirect("CustomerLoginPage.aspx");
        }

    }
}
