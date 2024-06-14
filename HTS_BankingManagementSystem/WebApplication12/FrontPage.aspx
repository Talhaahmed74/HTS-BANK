<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrontPage.aspx.cs" Inherits="WebApplication12.UI.FrontPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>HTS Bank</title>
    <style>
        html, body {
            margin: 0;
            padding: 0;
            height: 100%;
            width: 100%;
            overflow: hidden;
            font-family: Arial, sans-serif;
        }
        .container {
            display: flex;
            height: 100vh;
            width: 100vw;
        }
        .left-side, .right-side {
            display: flex;
            flex-direction: column;
            align-items: center;
            justify-content: center;
            height: 100%;
        }
        .left-side {
            width: 40%;
            background-color: #3AAFA9;
            text-align: center;
            padding: 20px;
            box-sizing: border-box;
        }
        .right-side {
            width: 60%;
            background-color: #081818;
            color: white;
        }
        .logo {
            max-width: 450px;
            height: auto;
        }
        .welcome-message {
            color: #830E45;
            font-size: 36px;
            font-weight: bold;
            margin-bottom: 20px;
        }
        .btn-container {
            margin-top: 10px;
            text-align: center;
        }
        .btn {
            margin: 20px;
            padding: 15px 40px;
            font-size: 20px;
            cursor: pointer;
            border: none;
            border-radius: 8px;
            background-color: #5C8A71;
            color: white;
            transition: background-color 0.3s ease;
        }
        .btn:hover {
            background-color: #57BA98;
        }
        .label-container {
            margin-bottom: 20px;
            text-align: center;
            color: #1be4c2;
            font-size: 24px;
            font-weight: bold;
        }
        .footer {
            margin-top: auto;
            padding: 10px;
            font-size: 14px;
            color: #ffffff;
        }
        .auto-style1 {
            color: #FFFFFF;
            font-size: 36px;
            font-weight: bold;
            margin-bottom: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="left-side">
                <h1 class="auto-style1">Welcome to HTS Bank</h1>
                <img src="UI/Images/HTSLOGO_2.0.png" alt="Bank Logo" class="logo" />
                <div class="footer">© 2024 HTS Bank. All rights reserved.</div>
            </div>
            <div class="right-side">
                <div>
                    <div class="label-container">
                        <label>Either choose one to continue:</label>
                    </div>
                    <div class="btn-container">
                        <asp:Button ID="btnAdmin" runat="server" Text="Admin" OnClick="btnAdmin_Click" CssClass="btn" />
                        <asp:Button ID="btnCustomer" runat="server" Text="Customer" OnClick="btnCustomer_Click" CssClass="btn" />
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
