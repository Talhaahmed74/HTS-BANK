<%@ Page Title="SIGN UP Page" Language="C#" AutoEventWireup="true" CodeBehind="SIGNUP.aspx.cs" Inherits="WebApplication12.UI.SIGNUP" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script>
        function showSuccessMessage() {
            alert('Account created successfully!');
        }
    </script>
<style>
  body {
    margin: 0;
    padding: 0;
    font-family: Arial, sans-serif;
    display: flex;
    flex-direction: column;
    height: 100vh;
  }

  .top-panel {
    height: 15% ; 
    flex: 30% ;
    background-color: #3AAFA9;
    display: flex;
    justify-content: center;
    align-items: center;
  }

  .bottom-panel {
    height: 85% ; 
    flex: 70%;
    background-color: #081818;
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
    padding: 20px;
  }

  .form-group {
    display: flex;
    width: 100%;
    max-width: 800px;
    margin-bottom: 15px;
    flex-wrap: wrap;
  }

  .form-group label {
    width: 150px;
    margin-top: 5px;
    margin-right: 5px;
    align-self: center;
    font-weight: bold;
    color: #99BDBD; 
  }

  .form-group input,
  .form-group select {
    flex: 1;
    padding: 10px;
    font-size: 16px;
    margin-bottom: 5px;
    margin-left: 10px;
    border: 1px solid #ccc;
    border-radius: 4px;
    transition: border-color 0.3s ease;
  }

  .form-group input:focus,
  .form-group select:focus {
    outline: none;
    border-color: #3AAFA9;
  }

  .form-group .error-message {
    color: red;
    width: 100%;
    margin-top: 5px;

  }

  .form-group.double-line {
    display: flex;
    justify-content: space-between;
    width: 100%;
    max-width: 800px;
    margin-bottom: 15px;
  }

  .form-group.double-line .form-group {
    width: calc(50% - 10px); 
    margin-right: 10px;
  }

  .form-group.single-line {
    display: flex;
    width: 100%;
    max-width: 800px;
    margin-bottom: 12px;
  }

  .form-group.single-line label {
    width: 150px;
    margin-right: 5px;
    align-self: center;
    font-weight: bold;
    color: #88B0B0; /* Adjusted label color */
  }

  .form-group.single-line .form-group {
    flex: 1;
    margin-left: 10px;
  }

  .buttons {
    margin-top: 20px;
    display: flex;
    justify-content: center;
    width: 100%;
    max-width: 800px;
  }

  .buttons .submit,
  .buttons .cancel {
    padding: 15px 30px;
    margin: 0 10px;
    border: none;
    border-radius: 4px;
    cursor: pointer;
    font-size: 16px;
    background-color: #5C8A71;
    color: white;
    transition: background-color 0.3s;
  }

  .buttons .submit:hover,
  .buttons .cancel:hover {
    background-color: #3AAFA9;
  }

  .heading {
    font-size: 36px;
    color: white;
    margin: 0;
  }

  @media (max-width: 600px) {
    .form-group label {
      width: 100%;
      margin-bottom: 5px;
    }

    .form-group input,
    .form-group select {
      width: 100%;
      margin-left: 0;
    }

    .buttons .submit,
    .buttons .cancel {
      width: 100%;
      margin: 10px 0;
    }
  }
</style>

</head>
<body>
    <form id="form1" runat="server">
        <div class="top-panel">
            <h1 class="heading">SIGN UP&nbsp;</h1>
        </div>
        <div class="bottom-panel">
            <div class="form-group double-line">
                <div class="form-group">
                    <label for="firstName">First Name:</label>
                    <asp:TextBox ID="firstName" runat="server"></asp:TextBox>
                    <asp:Label ID="firstNameError" runat="server" CssClass="error-message" Text="First name is required." Visible="false"></asp:Label>
                </div>
                <div class="form-group">
                    <label for="lastName">Last Name:</label>
                    <asp:TextBox ID="lastName" runat="server"></asp:TextBox>
                    <asp:Label ID="lastNameError" runat="server" CssClass="error-message" Text="Last name is required." Visible="false"></asp:Label>
                </div>
            </div>
            <div class="form-group double-line">
                <div class="form-group">
                    <label for="fatherName">Father's Name:</label>
                    <asp:TextBox ID="fatherName" runat="server"></asp:TextBox>
                    <asp:Label ID="fatherNameError" runat="server" CssClass="error-message" Text="Father's name is required." Visible="false"></asp:Label>
                </div>
                <div class="form-group">
                    <label for="email">Email:</label>
                    <asp:TextBox ID="email" runat="server"></asp:TextBox>
                    <asp:Label ID="emailError" runat="server" CssClass="error-message" Text="Email is required." Visible="false"></asp:Label>
                </div>
            </div>
            <div class="form-group double-line">
                <div class="form-group">
                    <label for="age">Age:</label>
                    <asp:TextBox ID="age" runat="server"></asp:TextBox>
                    <asp:Label ID="ageError" runat="server" CssClass="error-message" Text="Age must be 18 or above." Visible="false"></asp:Label>
                </div>
                <div class="form-group">
                    <label for="phoneNumber">Phone Number:</label>
                    <asp:TextBox ID="phoneNumber" runat="server"></asp:TextBox>
                    <asp:Label ID="phoneNumberError" runat="server" CssClass="error-message" Text="Phone number is required." Visible="false"></asp:Label>
                </div>
            </div>
            <div class="form-group single-line">
                <label for="address">Address:</label>
                <asp:TextBox ID="address" runat="server"></asp:TextBox>
                <asp:Label ID="addressError" runat="server" CssClass="error-message" Text="Address is required." Visible="false"></asp:Label>
            </div>
            <div class="form-group double-line">
                <div class="form-group">
                    <label for="gender">Gender:</label>
                    <asp:DropDownList ID="gender" runat="server">
                        <asp:ListItem Value="male">Male</asp:ListItem>
                        <asp:ListItem Value="female">Female</asp:ListItem>
                    </asp:DropDownList>
                    <asp:Label ID="genderError" runat="server" CssClass="error-message" Text="Gender is required." Visible="false"></asp:Label>
                </div>
                <div class="form-group">
                    <label for="cnic">CNIC:</label>
                    <asp:TextBox ID="cnic" runat="server" placeholder="Enter without Dashes -"></asp:TextBox>
                    <asp:Label ID="cnicError" runat="server" CssClass="error-message" Text="Invalid CNIC format." Visible="false"></asp:Label>
                </div>
            </div>
            <div class="form-group double-line">
                <div class="form-group">
                    <label for="password">Password:</label>
                    <asp:TextBox ID="password" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:Label ID="passwordError" runat="server" CssClass="error-message" Text="Password is required." Visible="false"></asp:Label>
                </div>
                <div class="form-group">
                    <label for="confirmPassword">Confirm Password:</label>
                    <asp:TextBox ID="confirmPassword" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:Label ID="confirmPasswordError" runat="server" CssClass="error-message" Text="Passwords do not match." Visible="false"></asp:Label>
                </div>
            </div>
            <div class="form-group single-line">
                <label for="accountType">Account Type:</label>
                <asp:DropDownList ID="accountType" runat="server">
                    <asp:ListItem Value="saving">Saving</asp:ListItem>
                    <asp:ListItem Value="current">Current</asp:ListItem>
                </asp:DropDownList>
                <asp:Label ID="accountTypeError" runat="server" CssClass="error-message" Text="Please select an account type." Visible="false"></asp:Label>
            </div>
            <div class="buttons">
                <strong>
                <asp:Button ID="submitBtn" runat="server" Text="Submit" CssClass="submit" OnClick="submitBtn_Click" style="font-weight: bold" Width="165px" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="cancelBtn" runat="server" Text="Cancel" CssClass="cancel" OnClick="cancelBtn_Click" style="font-weight: bold" Width="165px" />
                </strong>
            </div>
        </div>
    </form>
</body>
</html>
