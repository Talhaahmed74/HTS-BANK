<%@ Page Title="Pin Change" Language="C#" MasterPageFile="~/UserDashboard.Master" AutoEventWireup="true" CodeBehind="PinChange.aspx.cs" Inherits="WebApplication12.PinChange" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .pin-change-panel {
            background-color: #1a73e8; /* Dark blue background */
            padding: 20px;
            width: 400px;
            margin: 0 auto; /* Center align */
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            color: #fff;
            text-align: center;
        }
        .pin-change-panel h2 {
            margin-bottom: 20px;
        }
        .pin-change-panel label {
            display: block;
            margin-bottom: 10px;
            text-align: left;
        }
        .pin-change-panel input[type="password"] {
            width: calc(100% - 22px);
            padding: 10px;
            margin-bottom: 20px;
            border: none;
            border-radius: 5px;
        }
        .pin-change-panel .button-group {
            display: flex;
            justify-content: space-between;
        }
        .pin-change-panel button {
            padding: 10px 20px;
            border: none;
            border-radius: 5px;
            cursor: pointer;
        }
        .pin-change-panel .submit-btn {
            background-color: #34a853; /* Green background */
            color: #fff;
        }
        .pin-change-panel .cancel-btn {
            background-color: #fbbc05; /* Yellow background */
            color: #000;
        }
        .result-label {
            margin-top: 20px;
            color: #ff0000; /* Red color for error messages */
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="pin-change-panel">
        <h2>Change PIN</h2>
        <label for="currentPassword">Current Password:</label>
        <asp:TextBox ID="currentPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
        <label for="newPassword">New Password:</label>
        <asp:TextBox ID="newPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
        <label for="confirmPassword">Confirm Password:</label>
        <asp:TextBox ID="confirmPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
        <div class="button-group">
            <asp:Button ID="submitButton" runat="server" Text="Submit" CssClass="submit-btn" OnClick="SubmitButton_Click" />
            <asp:Button ID="cancelButton" runat="server" Text="Cancel" CssClass="cancel-btn" OnClick="CancelButton_Click" />
        </div>
        <asp:Label ID="resultLabel" runat="server" CssClass="result-label" Visible="false"></asp:Label>
    </div>
</asp:Content>