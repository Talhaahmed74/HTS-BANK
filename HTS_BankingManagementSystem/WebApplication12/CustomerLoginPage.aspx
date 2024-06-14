<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerLoginPage.aspx.cs" Inherits="WebApplication12.UI.CustomerLoginPage" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Page</title>
    <style>
        /* CSS for the layout */
        body, html {
            margin: 0;
            padding: 0;
            height: 100%;
            font-family: Arial, sans-serif;
            background-color: #fafafa;
        }
        .container {
            display: flex;
            flex-direction: column;
            height: 100%;
        }
        .top-panel {
            background-color: #3AAFA9;
            border-bottom: 1px solid #ccc;
            padding: 10px;
            text-align: center;
            height: 100px; /* Increased height */
            display: flex;
            justify-content: center;
            align-items: center;
        }
        .bottom-middle-panel {
            flex: 1;
            display: flex;
            flex-direction: column;
            justify-content: center;
            align-items: center;
            padding: 20px;
        }
        .login-box {
            width: 300px;
            padding: 40px;
            background: #222b33;
            box-shadow: 0px 0px 10px 0px #0000001a;
            border-radius: 10px;
            text-align: center;
        }
        .login-box h1 {
            margin-bottom: 30px;
            font-size: 28px; /* Increased font size */
            color: #fff; /* Changed color to white */
            padding: 10px;
            border-radius: 5px;
        }
        .input-group {
            margin-bottom: 15px;
            text-align: left;
        }
        .input-group label {
            display: block;
            margin-bottom: 5px;
            font-weight: bold; /* Make labels bold */
            color: white; /* Add contrasting color */
        }
        .input-group input[type="text"],
        .input-group input[type="password"] {
            width: 100%;
            padding: 10px;
            border: 1px solid #ccc;
            border-radius: 5px;
            box-sizing: border-box;
        }
        .btn-container {
            margin-top: 20px;
        }
        .btn {
            background-color: #4CAF50; /* Green */
            border: none;
            color: white;
            padding: 10px 20px;
            text-align: center;
            text-decoration: none;
            display: inline-block;
            font-size: 16px;
            cursor: pointer;
            border-radius: 5px;
            width: 100%;
            margin-bottom: 10px;
        }
        .btn:hover {
            background-color:  #2a7a6d; /* Darker green */
        }
        .footer {
            margin-top: 20px;
            text-align: center;
            color: #777;
            font-size: 14px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="top-panel">
                <h1 style="margin: 0; font-size: 32px;">Customer Login</h1>
            </div>
            <div class="bottom-middle-panel">
                <div class="login-box">
                    <h1>Login</h1>
                    <div class="input-group">
                        <label for="txtAccountNumber">Account Number:</label>
                        <asp:TextBox ID="txtAccountNumber" runat="server" TextMode="SingleLine" CssClass="form-control" />
                    </div>
                    <div class="input-group">
                        <label for="txtPassword">Password:</label>
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" />
                        <asp:Label ID="lblText" runat="server" Visible="False"></asp:Label>
                    </div>
                    <div class="btn-container">
                        <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" CssClass="btn" />
                        <asp:Button ID="btnSignup" runat="server" Text="Signup" OnClick="btnSignup_Click" CssClass="btn" />
                        <br />
                        <br />
                    </div>
                </div>
                <div class="footer">
                    © 2024 HTS BANK. All rights reserved.
                </div>
            </div>
        </div>
    </form>
</body>
</html>
