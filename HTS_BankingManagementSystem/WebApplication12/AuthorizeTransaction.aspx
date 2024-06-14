<%@ Page Title="" Language="C#" MasterPageFile="~/AdminDashboard.master" AutoEventWireup="true" CodeBehind="AuthorizeTransaction.aspx.cs" Inherits="WebApplication12.AuthorizeTransaction" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .container {
            width: 850px;
            margin: 0 auto;
            padding: 20px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            background-color: #fff;
            text-align: center;
            position: absolute;
            left: 50%;
            top: 50%;
            transform: translate(-50%, -50%);
        }
        .container input[type=text] {
            width: 200px;
            padding: 10px;
            margin: 5px;
            border: 1px solid #ccc;
            border-radius: 4px;
            box-sizing: border-box;
        }
        .container button {
            background-color: #4CAF50;
            color: white;
            padding: 10px 20px;
            border: none;
            border-radius: 4px;
            cursor: pointer;
        }
        .container button:hover {
            background-color: #45a049;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" id="container">
        <h1>Transaction Authorization</h1>
        <asp:Label ID="lblAccountNumber" runat="server" Text="Account Number:"></asp:Label>
        <asp:TextBox ID="txtAccountNumber" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" EmptyDataText="No transaction history." Width="100%" Visible="false">
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
