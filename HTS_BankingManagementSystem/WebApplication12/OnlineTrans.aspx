<%@ Page Title="" Language="C#" MasterPageFile="~/UserDashboard.Master" AutoEventWireup="true" CodeBehind="OnlineTrans.aspx.cs" Inherits="WebApplication12.OnlineTrans" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .online-trans-panel {
            background-color: #f4f4f9; /* Light grey background */
            padding: 20px;
            width: 400px;
            margin: 0 auto; /* Center align */
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            text-align: center;
        }
        .online-trans-panel h2 {
            margin-bottom: 20px;
            color: #333;
        }
        .online-trans-panel .form-group {
            margin-bottom: 20px;
        }
        .online-trans-panel label {
            display: block;
            font-weight: bold;
            margin-bottom: 5px;
        }
        .online-trans-panel input[type="text"] {
            width: 100%;
            padding: 10px;
            border: 1px solid #ccc;
            border-radius: 5px;
            box-sizing: border-box;
        }
        .online-trans-panel .button-group {
            display: flex;
            justify-content: center;
            gap: 20px;
        }
        .online-trans-panel button {
            padding: 15px 20px;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            color: #fff;
            font-size: 18px;
            transition: background-color 0.3s;
        }
        .online-trans-panel .proceed-btn {
            background-color: #4285f4; /* Blue background */
        }
        .online-trans-panel .proceed-btn:hover {
            background-color: #357ae8; /* Darker blue on hover */
        }
        .online-trans-panel .cancel-btn {
            background-color: #f44336; /* Red background */
        }
        .online-trans-panel .cancel-btn:hover {
            background-color: #d32f2f; /* Darker red on hover */
        }
    </style>
    <script type="text/javascript">
        function confirmTransaction() {
            return confirm("Are you sure you want to proceed with this transaction?");
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="online-trans-panel">
        <h2>Online Deposit</h2>
        <div class="form-group">
            <label for="txtAccountNumber">Account Number:</label>
            <asp:TextBox ID="txtAccountNumber" runat="server" TextMode="SingleLine" placeholder="Enter Account Number"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="txtAmount">Amount:</label>
            <asp:TextBox ID="txtAmount" runat="server" TextMode="SingleLine" placeholder="Enter Amount"></asp:TextBox>
        </div>
        <div class="button-group">
            <asp:Button ID="proceedButton" runat="server" Text="Proceed" CssClass="proceed-btn" OnClientClick="return confirmTransaction();" OnClick="ProceedButton_Click" />
            <asp:Button ID="cancelButton" runat="server" Text="Cancel" CssClass="cancel-btn" OnClick="CancelButton_Click" />
        </div>
    </div>
</asp:Content>
