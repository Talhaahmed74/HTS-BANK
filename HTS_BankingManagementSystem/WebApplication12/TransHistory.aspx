<%@ Page Title="Transaction History" Language="C#" MasterPageFile="~/UserDashboard.Master" AutoEventWireup="true" CodeBehind="TransHistory.aspx.cs" Inherits="WebApplication12.TransHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .container {
            width: 850px;
            margin: 0 auto;
            padding: 20px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            background-color: #fff;
        }
        .container h1 {
            text-align: center;
        }
        .auto-style1 {
            width: 850px;
            margin: 0 auto;
            padding: 20px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            background-color: #fff;
            height: 202px;
        }
        .empty-data {
            text-align: center;
            font-weight: bold;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="auto-style1">
        <h1>Transaction History</h1>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" EmptyDataText="No transaction history." Width="100%">
            <Columns>
                <asp:BoundField DataField="ReceiverName" HeaderText="Receiver Name" />
                <asp:BoundField DataField="SenderName" HeaderText="Sender Name" />
                <asp:BoundField DataField="Date" HeaderText="Date" DataFormatString="{0:yyyy-MM-dd}" />
                <asp:BoundField DataField="Amount" HeaderText="Amount" DataFormatString="{0:C}" HtmlEncode="False" />
                <asp:BoundField DataField="Type" HeaderText="Type" />
                <asp:TemplateField HeaderText="Status">
                    <ItemTemplate>
                        <asp:Literal ID="Literal1" runat="server" Text='<%# Eval("Status") %>'></asp:Literal>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
