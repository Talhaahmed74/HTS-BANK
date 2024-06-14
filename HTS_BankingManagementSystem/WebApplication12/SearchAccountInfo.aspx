<%@ Page Title="" Language="C#" MasterPageFile="~/AdminDashboard.master" AutoEventWireup="true" CodeBehind="SearchAccountInfo.aspx.cs" Inherits="WebApplication12.SearchAccountInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        body, html {
            height: 100%;
            margin: 0;
        }
        .center-container {
            display: flex;
            flex-direction: column;
            align-items: center;
            justify-content: center;
            height: 100%;
            background-color: #f4f4f9;
            padding: 20px;
        }
        .center-container h2 {
            margin-bottom: 20px;
            color: #333;
        }
        .center-container label {
            display: block;
            margin-bottom: 10px;
            text-align: left;
            color: #555;
        }
        .center-container input[type="text"] {
            width: 100%;
            max-width: 400px;
            padding: 10px;
            margin-bottom: 20px;
            border: 1px solid #ccc;
            border-radius: 5px;
            display: block;
            background-color: #fff;
            color: #333;
            box-sizing: border-box;
        }
        .search-btn {
            padding: 10px 20px;
            border: none;
            border-radius: 50px;
            cursor: pointer;
            color: #fff;
            background-color: #4285f4;
            transition: transform 0.2s, background-color 0.2s;
        }
        .search-btn:hover {
            transform: scale(1.1);
            background-color: #357ae8;
        }
        .container {
            background-color: #fff;
            padding: 20px;
            border-radius: 8px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            width: 100%;
            max-width: 800px;
            margin: 20px auto;
            display: none; /* Initially hidden */
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
        function showAccountInfo() {
            document.getElementById('accountInfoContainer').style.display = 'block';
            document.getElementById('searchContainer').style.display = 'none';
        }

        function hideAccountInfo() {
            document.getElementById('accountInfoContainer').style.display = 'none';
            document.getElementById('searchContainer').style.display = 'flex';
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="searchContainer" class="center-container">
        <h2>Search Customer Account Info</h2>
        <label for="accountNumberTextBox">Account Number:</label>
        <asp:TextBox ID="accountNumberTextBox" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:Button ID="SearchButton" runat="server" Text="Search" CssClass="search-btn" OnClick="SearchButton_Click" />
    </div>

    <div id="accountInfoContainer" class="container">
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
        <div class="form-group single-line">
            <label for="address">Address:</label>
            <asp:TextBox ID="address" runat="server"></asp:TextBox>
        </div>
  <div class="form-group single-line">
        <label for="accountType">Account Type:</label>
        <asp:TextBox ID="accountType" runat="server" ReadOnly="true"></asp:TextBox>
        <label for="cnic" style="margin-left: 20px;">CNIC:</label>
        <asp:TextBox ID="cnic" runat="server" ReadOnly="true"></asp:TextBox>
    </div>
    <div class="form-group single-line">
        <label for="branch">Branch:</label>
        <asp:TextBox ID="branch" runat="server"></asp:TextBox>
        <label for="phoneNumber" style="margin-left: 20px;">Phone Number:</label>
        <asp:TextBox ID="phoneNumber" runat="server"></asp:TextBox>
    </div>
    <div class="buttons">
        <asp:Button ID="BackButton" runat="server" Text="Back" CssClass="update-button" OnClientClick="hideAccountInfo(); return false;" />
    </div>
</div></asp:Content>
