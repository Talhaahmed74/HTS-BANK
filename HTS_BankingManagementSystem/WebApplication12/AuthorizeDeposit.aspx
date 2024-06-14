<%@ Page Title="" Language="C#" MasterPageFile="~/AdminDashboard.master" AutoEventWireup="true" CodeBehind="AuthorizeDeposit.aspx.cs" Inherits="WebApplication12.AuthorizeDeposit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .center-container {
            display: flex;
            flex-direction: column;
            align-items: center;
            justify-content: center;
            height: 100%;
        }
        .form-group {
            margin-bottom: 20px;
            text-align: center;
        }
        .form-group label {
            display: block;
            margin-bottom: 5px;
            font-weight: bold;
        }
        .form-group input[type="text"] {
            width: 300px;
            padding: 10px;
            border: 1px solid #ccc;
            border-radius: 5px;
        }
        .buttons {
            margin-top: 20px;
            text-align: center; /* Center align buttons */
        }

        .buttons button,
        .buttons .Proceed-btn {
             padding: 10px 20px;
             margin-right: 10px;
             border: none;
             border-radius: 5px;
            cursor: pointer;
            font-size: 16px;
             font-weight: bold;
        }

        .buttons .Proceed-btn {
            background-color: #4285f4;
             color: white;
        }

        .buttons .cancel-btn {
           background-color: #f44336;
            color: white;
        }

    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="center-container">
        <h2>Authorized Cash Deposit</h2>
        <div class="form-group">
            <label for="accountNumber">Account Number:</label>
            <asp:TextBox ID="accountNumber" runat="server" ClientIDMode="Static"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="amount">Amount:</label>
            <asp:TextBox ID="amount" runat="server" ClientIDMode="Static"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="paymentReceived">Have you received the payment?</label>
            <div>
                <asp:RadioButtonList ID="paymentReceived" runat="server" ClientIDMode="Static">
                    <asp:ListItem Text="Yes" Value="yes"></asp:ListItem>
                    <asp:ListItem Text="No" Value="no" Selected="True"></asp:ListItem>
                </asp:RadioButtonList>
            </div>
        </div>
        <div class="buttons">
            <asp:Button ID="proceedButton" runat="server" CssClass="Proceed-btn" OnClick="ProceedButton_Click" Text="Proceed" Enabled="false" />
            <button class="cancel-btn" type="button" onclick="clearFields()">Cancel</button>
        </div>
    </div>

    <script>
        function clearFields() {
            document.getElementById('<%= accountNumber.ClientID %>').value = "";
            document.getElementById('<%= amount.ClientID %>').value = "";
            document.getElementById('<%= paymentReceived.ClientID %>').getElementsByTagName('input')[1].checked = true; // Set default to "No"
            document.getElementById('<%= proceedButton.ClientID %>').disabled = true; // Disable Proceed button
        }

        document.getElementById('<%= paymentReceived.ClientID %>').addEventListener('change', function () {
            if (document.getElementById('<%= paymentReceived.ClientID %>').getElementsByTagName('input')[0].checked) {
                document.getElementById('<%= proceedButton.ClientID %>').disabled = false; // Enable Proceed button if "Yes" is selected
            } else {
                document.getElementById('<%= proceedButton.ClientID %>').disabled = true; // Disable Proceed button if "No" is selected
            }
        });
    </script>
</asp:Content>
