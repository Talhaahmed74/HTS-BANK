<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="WebApplication12.UI.AdminLogin" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Login</title>
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
            background-color: #0E1C21;
            border-bottom: 1px solid #00D8BA;
            padding: 10px;
            text-align: center;
            height: 100px; /* Fixed height */
            display: flex;
            justify-content: center;
            align-items: center;
        }
        .top-panel h1 {
            margin: 0;
            font-size: 32px;
            color: white;
        }
        .bottom-middle-panel {
            flex: 1;
            display: flex;
            flex-direction: column;
            justify-content: center;
            align-items: center;
            padding: 20px;
            background-color: #15262C;
        }
        .login-box {
            width: 300px;
            padding: 40px;
            background: #0E1C21;
            box-shadow: 0px 0px 10px 0px #0000001a;
            border-radius: 10px;
            text-align: center;
            height: 350px; /* Increased height */
            display: flex;
            flex-direction: column;
            justify-content: center;
        }
        .login-box h1 {
            margin-bottom: 30px;
            font-size: 28px;
            color: white;
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
            font-weight: bold;
            color: white;
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
            background-color: #00D8BA;
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
        }
        .btn:hover {
            background-color: #2a7a6d;
        }
        .footer {
            text-align: center;
            color: #777;
            font-size: 14px;
            background-color: #15262C;
            width: 100%;
            padding: 10px 0;
            box-sizing: border-box;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="top-panel">
                <h1>Admin Panel</h1>
            </div>
            <div class="bottom-middle-panel">
                <div class="login-box">
                    <h1>Sign In</h1>
                    <div class="input-group">
                        <label for="txtAdminID">Admin ID:</label>
                        <asp:TextBox ID="txtAdminID" runat="server" TextMode="SingleLine" CssClass="form-control" />
                    </div>
                    <div class="input-group">
                        <label for="txtPassword">Password:</label>
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" />
                        <asp:Label ID="checkLbl" runat="server"></asp:Label>
                    </div>
                    <div class="btn-container">
                        <asp:Button ID="btnSignIn" runat="server" Text="Sign In" OnClick="btnSignIn_Click" CssClass="btn" />
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
