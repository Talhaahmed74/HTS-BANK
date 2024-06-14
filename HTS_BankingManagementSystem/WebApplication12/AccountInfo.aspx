<%@ Page Title="Account Information" Language="C#" MasterPageFile="~/UserDashboard.Master" AutoEventWireup="true" CodeBehind="AccountInfo.aspx.cs" Inherits="WebApplication12.AccountInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .container {
            background-color: #fff;
            padding: 20px;
            border-radius: 8px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            width: 100%;
            max-width: 800px;
            margin: 0 auto;
            margin-top: 20px;
            margin-bottom: 25px;
        }

        .heading {
            text-align: center;
            margin-bottom: 20px;
            font-size: 30px;
            color: #082560;
        }

        .form-group {
            display: flex;
            align-items: center;
            margin-bottom: 10px;
        }

            .form-group label {
                width: 150px;
                margin-right: 10px;
                font-weight: bold;
            }

            .form-group input,
            .form-group select {
                flex: 1;
                padding: 5px;
                font-size: 14px;
            }

            .form-group .update-button {
                padding: 5px 10px;
                margin-left: 10px;
                border: none;
                border-radius: 4px;
                cursor: pointer;
                font-size: 14px;
                background-color: #3AAFA9;
                color: white;
                transition: background-color 0.3s;
                width: auto;
            }

                .form-group .update-button:hover {
                    background-color: #2a7a6d;
                }

        .buttons {
            text-align: center;
            margin-top: 20px;
        }

        .single-line {
            display: flex;
            align-items: center;
            margin-bottom: 10px;
        }
    </style>
    <script>
        function showPhoneUpdateMessage() {
            alert('Phone number updated successfully.');
        }
        function showAdminRequestMessage() {
            var requestDescription = document.getElementById('<%= updateRequestDescription.ClientID %>').value;
            if (requestDescription.trim() === "") {
                alert('Please provide a description for your update request.');
                return false;
            }
            var confirmed = confirm('Do you want to send the update request to the admin?');
            if (confirmed) {
                alert('Your request has been sent to the admin for approval.');
            }
        } --

            window.onload = function () {
                alert('You can update your phone number directly. To update your address or branch, please write your request and new data in the request description.');
            };
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h1 class="heading">Account Information</h1>
        <div class="form-group">
            <label for="firstName">First Name:</label>
            <asp:TextBox ID="firstName" runat="server" ReadOnly="true"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="lastName">Last Name:</label>
            <asp:TextBox ID="lastName" runat="server" ReadOnly="true"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="fatherName">Father's Name:</label>
            <asp:TextBox ID="fatherName" runat="server" ReadOnly="true"></asp:TextBox>
        </div>
        <div class="form-group single-line">
            <label for="age">Age:</label>
            <asp:TextBox ID="age" runat="server" ReadOnly="true"></asp:TextBox>
            <label for="gender" style="margin-left: 20px;">Gender:</label>
            <asp:TextBox ID="gender" runat="server" ReadOnly="true"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="email">Email:</label>
            <asp:TextBox ID="email" runat="server" ReadOnly="true"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="balance">Account Balance:</label>
            <asp:TextBox ID="balance" runat="server" ReadOnly="true"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="phoneNumber">Phone Number:</label>
            <asp:TextBox ID="phoneNumber" runat="server"></asp:TextBox>
            <asp:Button ID="updatePhoneBtn" runat="server" Text="Update" CssClass="update-button" OnClick="updatePhoneBtn_Click1" />
        </div>
        <div class="form-group single-line">
            <label for="address">Address:</label>
            <asp:TextBox ID="address" runat="server" ReadOnly="true"></asp:TextBox>
        </div>
        <div class="form-group single-line">
            <label for="branch">Branch:</label>
            <asp:TextBox ID="branch" runat="server" ReadOnly="true"></asp:TextBox>
        </div>
        <div class="form-group single-line">
            <label for="cnic">CNIC:</label>
            <asp:TextBox ID="cnic" runat="server" ReadOnly="true"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="accountType">Account Type:</label>
            <asp:TextBox ID="accountType" runat="server" ReadOnly="true"></asp:TextBox>
        </div>
        <div class="form-group single-line">
            <label for="updateRequestDescription">Update Request Description:</label>
            <asp:TextBox ID="updateRequestDescription" runat="server" TextMode="MultiLine" Rows="3" Width="318px"></asp:TextBox>
<%--            <asp:Button ID="sendRequestBtn" runat="server" Text="Send Request" CssClass="update-button" OnClientClick="showAdminRequestMessage(); return false;" />--%>
            <asp:Button ID="sendRequest" runat="server" Text="Send Request" CssClass="update-button" OnClick="sendRequest_Click"  />
        </div>
    </div>
</asp:Content>
