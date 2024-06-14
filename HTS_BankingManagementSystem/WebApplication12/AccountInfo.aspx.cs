using System;
using BusinessLogicLayer;

namespace WebApplication12
{
    public partial class AccountInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int accountNo = (int)Session["AccountNo"];
                LoadAccountInfo(accountNo);
            }
        }

        private void LoadAccountInfo(int accountNo)
        {
            AccountInfoBL accountInfoBL = new AccountInfoBL();
            var account = accountInfoBL.GetAccountInfo(accountNo);

            if (account != null)
            {
                firstName.Text = account.FirstName;
                lastName.Text = account.LastName;
                age.Text = account.Age.ToString();
                balance.Text = account.Balance.ToString();
                fatherName.Text = account.FatherName;
                phoneNumber.Text = account.PhoneNumber;
                email.Text = account.Email;
                gender.Text = account.Gender;
                address.Text = account.Address;
                cnic.Text = account.CNIC;
                accountType.Text = account.AccountType;
                branch.Text = account.BranchAddress;
            }
        }

        protected void updatePhoneBtn_Click1(object sender, EventArgs e)
        {
            string msg = "";
            AccountInfoBL accountInfoBL = new AccountInfoBL();
            if (Convert.ToString(phoneNumber.Text).Length == 11)
            {
                bool result = accountInfoBL.UpdatePhoneNumber(Convert.ToString(phoneNumber.Text), Convert.ToString(Session["AccountNo"]));
                
                if (result)
                {
                    msg = "Number has been updated successfully";
                }
                else
                {
                    msg = "An error occured while updating phone number";
                }

                

            }
            
            else
            {
                msg = "Invalid phone number";
            }

            Response.Write($"<script>alert('{msg}');</script>");

        }

        protected void sendRequestBtn_Click(object sender, EventArgs e)
        {
            string requestDescription = updateRequestDescription.Text;

            if (string.IsNullOrWhiteSpace(requestDescription))
            {
                Response.Write("<script>alert('Please provide a description for your update request.');</script>");
                return;
            }

            int accountNo = (int)Session["AccountNo"];

            // Here you would send the request to the admin, e.g., by saving it in a database or sending an email
            AccountInfoBL accountInfoBL = new AccountInfoBL();
            //bool isRequestSent = accountInfoBL.SendUpdateRequestToAdmin(accountNo, requestDescription);

            //if (isRequestSent)
            //{
            //    Response.Write("<script>alert('Your request has been sent to the admin for approval.');</script>");
            //}
            //else
            //{
            //    Response.Write("<script>alert('Error sending request to the admin.');</script>");
            //}
        }

        protected void sendRequest_Click(object sender, EventArgs e)
        {
            string description = updateRequestDescription.Text;
            int accountNo = int.Parse(Convert.ToString(Session["AccountNo"]));

            int req =new  AccountInfoBL().SendInfoUpdateRequest(description , accountNo);
            Response.Write("<script>alert('Request sent to the admin.');</script>");
            updateRequestDescription.Text = "";
            
        }
    }
}
