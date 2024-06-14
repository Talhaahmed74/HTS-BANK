<%@ Page Title="" Language="C#" MasterPageFile="~/UserDashboard.Master" AutoEventWireup="true" CodeBehind="BillPayment.aspx.cs" Inherits="WebApplication12.BillPayment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .bill-payment-panel {
            background-color: #f4f4f9;
            padding: 20px;
            width: 400px;
            margin: 0 auto;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            text-align: center;
        }

            .bill-payment-panel h2 {
                margin-bottom: 20px;
                color: #333;
            }

            .bill-payment-panel label {
                display: block;
                margin-bottom: 10px;
                text-align: left;
                color: #555;
            }

            .bill-payment-panel input[type="text"], .bill-payment-panel .text-label {
                width: calc(100% - 22px);
                padding: 10px;
                margin-bottom: 20px;
                border: 1px solid #ccc;
                border-radius: 5px;
                display: block;
                background-color: #fff;
                color: #333;
                box-sizing: border-box;
            }

            .bill-payment-panel .text-label {
                background-color: #f9f9f9;
                padding: 10px;
                border: 1px solid #ccc;
                border-radius: 5px;
                display: block;
                width: calc(100% - 22px);
                margin-bottom: 20px;
                box-sizing: border-box;
            }

            .bill-payment-panel .button-group {
                display: flex;
                justify-content: space-between;
            }

            .bill-payment-panel button {
                padding: 10px 20px;
                border: none;
                border-radius: 5px;
                cursor: pointer;
                color: #fff;
            }

            .bill-payment-panel .view-due-btn {
                background-color: #4285f4;
            }

            .bill-payment-panel .pay-btn {
                background-color: #34a853;
            }

            .bill-payment-panel .cancel-btn {
                background-color: #ea4335;
            }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <div class="bill-payment-panel">

        

        <asp:UpdatePanel ID="upBillPayment" runat="server">
            <ContentTemplate>

                <h2>Bill Payment</h2>

                <asp:Label ID="errorMessage" runat="server" CssClass="" Visible="false"></asp:Label>

                <label for="billNumberTextBox">Bill Number:</label>
                <asp:TextBox ID="billNumberTextBox" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="billNumberTextBox_TextChanged"  ></asp:TextBox>

                <label for="billAmountLabel">Bill Amount:</label>
                <asp:Label ID="billAmountLabel" runat="server" CssClass="text-label"></asp:Label>

                <label for="billTypeLabel">Bill Type:</label>
                <asp:Label ID="billTypeLabel" runat="server" CssClass="text-label"></asp:Label>

            </ContentTemplate>
        </asp:UpdatePanel>

        <div class="button-group">
            <%--<asp:Button ID="ViewDueButton" runat="server" Text="View Due Bills" CssClass="view-due-btn" OnClick="ViewDueButton_Click" />--%>
            <asp:Button ID="PayButton" runat="server" Text="Pay" CssClass="pay-btn" OnClick="PayButton_Click" />
            <asp:Button ID="CancelButton" runat="server" Text="Cancel" CssClass="cancel-btn" OnClick="CancelButton_Click" />
        </div>
    </div>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="true"></asp:GridView>
</asp:Content>
