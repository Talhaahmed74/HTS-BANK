<%@ Page Title="" Language="C#" MasterPageFile="~/UserDashboard.Master" AutoEventWireup="true" CodeBehind="MobileRecharge.aspx.cs" Inherits="WebApplication12.MobileRecharge" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .container {
            background-color: cadetblue;
            text-align: center;
            border-radius: 8px;
            width: 600px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            padding: 20px;
            margin-bottom: 25px;
            margin: 0 auto;
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
        .buttons .button {
            padding: 10px 20px;
            margin-left: 10px;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            font-size: 16px;
            background-color: #3AAFA9;
            color: white;
            transition: background-color 0.3s;
        }
        .buttons .button:hover {
            background-color: #2a7a6d;
        }
    </style>
    <script type="text/javascript">
        function confirmRecharge() {
            var mNetwork = document.getElementById('<%= mobileNetwork.ClientID %>').value;
            var mNumber = document.getElementById('<%= mobileNumber.ClientID %>').value;
            var Amount = document.getElementById('<%= amount.ClientID %>').value;

            var confirmationMessage = "You are about to recharge " + Amount + " Rs on " + mNetwork + " for the number " + mNumber + ". Confirm?";
            return confirm(confirmationMessage);
        }

        function clearFields() {
            document.getElementById('<%= mobileNetwork.ClientID %>').selectedIndex = 0;
            document.getElementById('<%= mobileNumber.ClientID %>').value = '';
            document.getElementById('<%= amount.ClientID %>').value = '';
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="heading">Mobile Recharge</div>
        <div class="form-group">
            <label for="mobileNetwork">Mobile Network</label>
            <asp:DropDownList ID="mobileNetwork" runat="server" CssClass="form-control">
                <asp:ListItem Value="Zong">Zong</asp:ListItem>
                <asp:ListItem Value="Jazz">Jazz</asp:ListItem>
                <asp:ListItem Value="Ufone">Ufone</asp:ListItem>
                <asp:ListItem Value="Telenor">Telenor</asp:ListItem>
                <asp:ListItem Value="ONIC">ONIC</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="form-group">
            <label for="mobileNumber">Mobile Number</label>
            <asp:TextBox ID="mobileNumber" runat="server" CssClass="form-control" />
        </div>
        <div class="form-group">
    <label for="amount">Amount</label>
    <asp:TextBox ID="amount" runat="server" CssClass="form-control" />
</div>

        <div class="buttons">
            <asp:Button ID="proceedButton" runat="server" Text="Proceed" CssClass="button" OnClientClick="return confirmRecharge();" OnClick="ProceedButton_Click" />
            <asp:Button ID="cancelButton" runat="server" Text="Cancel" CssClass="button" OnClientClick="clearFields(); return false;" />
        </div>
    </div>
</asp:Content>

