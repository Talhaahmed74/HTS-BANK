using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using BuisnessLogicLayer;
using System.Web.UI.WebControls;

namespace WebApplication12
{
    public partial class ModifyAccInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Load data into GridView on initial page load
            if (!IsPostBack)
            {
                LoadGridViewData();
            }
        }

        protected void LoadGridViewData()
        {
            int accountNo = int.Parse(Convert.ToString(Session["Admin_Id"]));
            ModifyInfoBL modifyInfoBl = new ModifyInfoBL();
            var requests = modifyInfoBl.GetRequests(accountNo);

            if (requests == null )
            {
                // Show an alert if no records are found
                ScriptManager.RegisterStartupScript(this, GetType(), "noRecordsAlert", "alert('No records found.');", true);
                gvRequests.Visible = false;
            }
            else
            {
                gvRequests.DataSource = requests;
                gvRequests.DataBind();
                gvRequests.Visible = true;
            }
        }


        protected void btnViewRequests_Click(object sender, EventArgs e)
        {
            gvRequests.Visible = true;
            modifyContainer.Visible = true;
        }

        static int accountNo;
        protected void gvRequests_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get selected row data
            GridViewRow row = gvRequests.SelectedRow;
            txtAccountNumber.Text = row.Cells[0].Text;
            accountNo = int.Parse(row.Cells[0].Text);
            txtName.Text = row.Cells[1].Text;
            txtAddress.Text = row.Cells[2].Text;
            txtAccountType.Text = row.Cells[3].Text;
            txtPhoneNumber.Text = row.Cells[4].Text;
            txtRequestDescription.Text = row.Cells[5].Text;

            // Show record details and hide grid view
            recordDetails.Visible = true;
            gvRequests.Visible = false;

            // Call JavaScript function to show record details
            ScriptManager.RegisterStartupScript(this, GetType(), "showRecordDetails", "showRecordDetails();", true);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            // Handle the event when "Cancel" button is clicked
            // Hide the details of the selected record and show the GridView again
            recordDetails.Visible = false;
            gvRequests.Visible = true;

            // Call JavaScript function to hide record details
            ScriptManager.RegisterStartupScript(this, GetType(), "hideRecordDetails", "hideRecordDetails();", true);
        }

        protected void btnModify_Click(object sender, EventArgs e)
        {
            int accountNo = int.Parse(txtAccountNumber.Text);
            string newAddress = txtAddress.Text;

            ModifyAccountInfoBL modifyBL = new ModifyAccountInfoBL();
            int updateResult = modifyBL.UpdateAddress(accountNo, newAddress);

            if (updateResult > 0)
            {
                LoadGridViewData();
                ScriptManager.RegisterStartupScript(this, GetType(), "updateSuccess", "alert('Address updated successfully.');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "updateFail", "alert('Failed to update address.');", true);
            }
        }
    }
}
