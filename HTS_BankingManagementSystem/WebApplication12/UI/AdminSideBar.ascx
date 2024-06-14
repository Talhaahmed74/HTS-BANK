<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdminSideBar.ascx.cs" Inherits="WebApplication12.UI.AdminSideBar" %>
<div class="sidebar" style="width: 170px;">
    <asp:Button ID="AccInfoBtn" runat="server" Text="View Customer Accounts" PostBackUrl="~/SearchAccountInfo.aspx" CssClass="sidebar-button" Style="font-size: 18px;" />
        <asp:Button ID="ModifyAccInfoBtn" runat="server" Text="Modify Customer Accounts Info" PostBackUrl="~/ModifyAccInfo.aspx" CssClass="sidebar-button" Style="font-size: 18px;" />
    <asp:Button ID="AuthorizeTransBtn" runat="server" Text="View Transactions" PostBackUrl="~/AuthorizeTransaction.aspx" CssClass="sidebar-button" Style="font-size: 18px;" />
    <asp:Button ID="AuthorizeDepositBtn" runat="server" Text="Authorize Deposit" PostBackUrl="~/AuthorizeDeposit.aspx" CssClass="sidebar-button" Style="font-size: 18px;" />
        
<asp:Button ID="SignOutBtn" runat="server" Text="Sign Out" PostBackUrl="~/FrontPage.aspx" OnClick="SignOutBtn_Click" CssClass="sidebar-button" Style="background-color: red; font-size: 18px;" />

</div>
    