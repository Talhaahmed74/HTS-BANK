using System;
using System.Web.UI;

namespace WebApplication12
{
    public partial class TrackMoneyDraft : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void trackButton_Click(object sender, EventArgs e)
        {
            // Check if the money draft name is provided
            if (!string.IsNullOrEmpty(NameTextBox.Text))
            {
                // Simulate the scenario where the admin has not taken any action yet
                // In a real scenario, you would query the database to check the status
                statusLabel.Text = "Request In Process";
            }
            else
            {
                // If the money draft name is not provided, show an error message
                statusLabel.Text = "Please enter the name of the money draft.";
            }
        }

        protected void downloadButton_Click(object sender, EventArgs e)
        {
            // Simulate the scenario where the money draft is available for download
            // In a real scenario, you would provide a link to download the money draft file
            ClientScript.RegisterStartupScript(this.GetType(), "downloadScript", "alert('Money draft downloaded successfully.');", true);
        }
    }
}
