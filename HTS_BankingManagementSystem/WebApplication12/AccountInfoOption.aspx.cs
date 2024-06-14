using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication12
{
    public partial class AccountInfoOption : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnViewCustomer_Click(object sender, EventArgs e)
        {
            Response.Redirect("SearchAccountInfo.aspx");
        }

        protected void btnModifyCustomer_Click(object sender, EventArgs e)
        {
            Response.Redirect("ModifyAccInfo.aspx");
        }
    }
}
