<%@ Page Title="" Language="C#" MasterPageFile="~/AdminDashboard.master" AutoEventWireup="true" CodeBehind="AccountInfoOption.aspx.cs" Inherits="WebApplication12.AccountInfoOption" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .center-container {
            text-align: center;
            margin-top: 100px; 
        }

        .btn-container {
            margin-top: 20px;
        }

        .btn {
            padding: 15px 30px;
            font-size: 20px;
            background-color: #28acb4;
            color: white;
            border: none;
            cursor: pointer;
            transition: all 0.3s ease;
            margin: 10px; 
        }

        .btn:hover {
            background-color: #1d8086; 
            transform: scale(1.05); 
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="center-container">
        <div class="btn-container">
            <asp:Button ID="btnViewCustomer" runat="server" Text="View Customer Account Info" CssClass="btn" OnClick="btnViewCustomer_Click" />
        </div>
        <div class="btn-container">
            <asp:Button ID="btnModifyCustomer" runat="server" Text="Modify Customer Account Info" CssClass="btn" OnClick="btnModifyCustomer_Click" />
        </div>
        <div>
            <asp:Label ID="lblChoose" runat="server" Text="Choose between the two to continue" Font-Size="20px" ForeColor="Black"></asp:Label>
        </div>
    </div>
</asp:Content>
