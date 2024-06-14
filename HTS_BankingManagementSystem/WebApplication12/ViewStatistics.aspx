<%@ Page Title="Bank Statistics" Language="C#" MasterPageFile="~/AdminDashboard.master" AutoEventWireup="true" CodeBehind="ViewStatistics.aspx.cs" Inherits="WebApplication12.ViewStatistics" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .center-container {
            display: flex;
            flex-direction: column;
            align-items: center;
            justify-content: flex-start;
            height: 90vh;
            text-align: center;
            margin-top: 30px;
        }

        .buttons-container {
            margin-top: 20px;
        }

        .buttons-container .button {
            margin: 10px;
            padding: 10px 20px;
            font-size: 16px;
            background-color: #0a6289;
            color: white;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            transition: background-color 0.3s, transform 0.3s;
        }

        .buttons-container .button:hover {
            background-color: #3AAFA9;
            transform: scale(1.05);
        }

        .stats-container {
            margin-top: 30px;
        }

        .dropdown-container {
            margin-top: 10px;
        }

        .label-textbox {
            display: flex;
            align-items: center;
            justify-content: center;
            margin-top: 20px;
        }

        .label-textbox label {
            margin-right: 10px;
        }

        .grid-view {
            margin-top: 20px;
        }

        .back-button {
            margin-top: 20px;
            padding: 10px 20px;
            font-size: 16px;
            background-color: red;
            color: white;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            transition: background-color 0.3s, transform 0.3s;
        }

        .back-button:hover {
            background-color: #e74c3c;
            transform: scale(1.05);
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="center-container">
        <h1 style="margin-bottom: 20px;">Bank Statistics</h1>

        <div class="buttons-container">
            <asp:Button ID="btnViewTransactionStats" runat="server" Text="View Transaction Stats" CssClass="button" OnClick="btnViewTransactionStats_Click" />
            <asp:Button ID="btnViewBillPaymentStats" runat="server" Text="View Bill Payment Stats" CssClass="button" OnClick="btnViewBillPaymentStats_Click" />
        </div>

        <asp:Panel ID="panelStats" runat="server" Visible="false" CssClass="stats-container">
            <asp:Label ID="lblNumOfTransactions" runat="server" Text="" CssClass="label-textbox"></asp:Label>
            <asp:TextBox ID="txtNumOfTransactions" runat="server" ReadOnly="true"></asp:TextBox>

            <div class="dropdown-container">
                <asp:Label ID="lblTimeFrame" runat="server" Text="Select Time Frame: "></asp:Label>
                <asp:DropDownList ID="ddlTimeFrame" runat="server">
                    <asp:ListItem Text="Weekly" Value="Weekly"></asp:ListItem>
                    <asp:ListItem Text="Monthly" Value="Monthly"></asp:ListItem>
                    <asp:ListItem Text="Yearly" Value="Yearly"></asp:ListItem>
                </asp:DropDownList>
            </div>

            <asp:GridView ID="gridViewStats" runat="server" CssClass="grid-view" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="DepositedBy" HeaderText="Deposited By" />
                    <asp:BoundField DataField="Receiver" HeaderText="Receiver" />
                    <asp:BoundField DataField="AccountNo" HeaderText="Account No" />
                    <asp:BoundField DataField="DepositAmount" HeaderText="Deposit Amount" />
                    <asp:BoundField DataField="DepositDate" HeaderText="Deposit Date" />
                    <asp:BoundField DataField="DepositStatus" HeaderText="Deposit Status" />
                    <asp:BoundField DataField="AccountName" HeaderText="Account Name" />
                </Columns>
            </asp:GridView>

            <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="back-button" OnClick="btnBack_Click" Visible="false" />
        </asp:Panel>
    </div>
</asp:Content>
