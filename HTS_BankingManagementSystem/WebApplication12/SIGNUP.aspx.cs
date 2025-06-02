    using System;
    using System.Linq;
    using System.Web.UI;
    using BusinessLogicLayer;

    namespace WebApplication12.UI
    {
        public partial class SIGNUP : Page
        {
            private SignUpBL signup = new SignUpBL();

            protected void Page_Load(object sender, EventArgs e)
            {
            }

            protected void submitBtn_Click(object sender, EventArgs e)
            {
                HideErrorMessages();

                bool isValid = true;

                // Get values from the form fields
                string fName = firstName.Text;
                string lName = lastName.Text;
                string fNameFather = fatherName.Text;
                int userAge;
                if (!int.TryParse(age.Text, out userAge) || userAge < 18)
                {
                    ageError.Visible = true;
                    isValid = false;
                }
                string phone = phoneNumber.Text;
                string addr = address.Text;
                string cnicNumber = cnic.Text;
                string passwordValue = password.Text;
                string acc_gender = gender.SelectedValue;
                string confirmPasswordValue = confirmPassword.Text;
                string accType = accountType.SelectedValue;
                string user_email = email.Text;
                int branch = 3000;
                int admin = 9003;

                // Validate form fields
                if (string.IsNullOrWhiteSpace(fName))
                {
                    firstNameError.Visible = true;
                    isValid = false;
                }
                if (string.IsNullOrWhiteSpace(lName))
                {
                    lastNameError.Visible = true;
                    isValid = false;
                }
                if (string.IsNullOrWhiteSpace(fNameFather))
                {
                    fatherNameError.Visible = true;
                    isValid = false;
                }
                if (string.IsNullOrWhiteSpace(phone))
                {
                    phoneNumberError.Visible = true;
                    isValid = false;
                }
                if (string.IsNullOrWhiteSpace(addr))
                {
                    addressError.Visible = true;
                    isValid = false;
                }
                if (!string.IsNullOrWhiteSpace(cnicNumber) && (cnicNumber.Length != 13 || !IsValidCnic(cnicNumber)))
                {
                    cnicError.Visible = true;
                    isValid = false;
                }
                if (string.IsNullOrWhiteSpace(accType))
                {
                    accountTypeError.Visible = true;
                    isValid = false;
                }
                if (string.IsNullOrWhiteSpace(acc_gender))
                {
                    genderError.Visible = true;
                    isValid = false;
                }
                if (string.IsNullOrWhiteSpace(passwordValue))
                {
                    passwordError.Visible = true;
                    isValid = false;
                }
                if (passwordValue != confirmPasswordValue)
                {
                    confirmPasswordError.Visible = true;
                    isValid = false;
                }

                if (!isValid)
                {
                    return;
                }

                // Call the Signup method to add the user to the database
                string resultMessage = signup.SetupAccount(fName, lName, fNameFather, userAge, acc_gender, phone, addr, cnicNumber, user_email, accType, passwordValue, branch, admin);

                // Check the result message
                if (resultMessage.StartsWith("Error:"))
                {
                    ShowSpecificErrorMessages(resultMessage);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showSuccessMessage", "showSuccessMessage();", true);
                    ClearFormFields();
                }
            }

            private void HideErrorMessages()
            {
                firstNameError.Visible = false;
                lastNameError.Visible = false;
                fatherNameError.Visible = false;
                ageError.Visible = false;
                phoneNumberError.Visible = false;
                addressError.Visible = false;
                cnicError.Visible = false;
                accountTypeError.Visible = false;
                passwordError.Visible = false;
                confirmPasswordError.Visible = false;
                genderError.Visible = false;
            }

            private bool IsValidCnic(string cnic)
            {
                return cnic.All(char.IsDigit) && !cnic.Any(char.IsLetter);
            }

            private void ShowSpecificErrorMessages(string resultMessage)
            {
                if (resultMessage.Contains("First name"))
                {
                    firstNameError.Visible = true;
                }
                else if (resultMessage.Contains("Last name"))
                {
                    lastNameError.Visible = true;
                }
                else if (resultMessage.Contains("Father's name"))
                {
                    fatherNameError.Visible = true;
                }
                else if (resultMessage.Contains("Age"))
                {
                    ageError.Visible = true;
                }
                else if (resultMessage.Contains("Phone number"))
                {
                    phoneNumberError.Visible = true;
                }
                else if (resultMessage.Contains("Address"))
                {
                    addressError.Visible = true;
                }
                else if (resultMessage.Contains("CNIC"))
                {
                    cnicError.Visible = true;
                }
                else if (resultMessage.Contains("Account type"))
                {
                    accountTypeError.Visible = true;
                }
            }

            private void ClearFormFields()
            {
                firstName.Text = string.Empty;
                lastName.Text = string.Empty;
                fatherName.Text = string.Empty;
                age.Text = string.Empty;
                phoneNumber.Text = string.Empty;
                address.Text = string.Empty;
                cnic.Text = string.Empty;
                accountType.SelectedIndex = 0;
                gender.SelectedIndex = 0;
                password.Text = string.Empty;
                confirmPassword.Text = string.Empty;
                email.Text = string.Empty;
            }

            protected void cancelBtn_Click(object sender, EventArgs e)
            {
                Response.Redirect("CustomerLoginPage.aspx");
            }
        }
    }
