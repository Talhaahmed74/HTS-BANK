<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SideBar.ascx.cs" Inherits="WebApplication12.UI.SideBar" %>
<div class="sidebar">
    <asp:Button ID="AccInfoBtn" runat="server" Text="Account Info" PostBackUrl="~/AccountInfo.aspx" OnClick="btnAccountInfo_Click" CssClass="sidebar-button" /><br />
    <asp:Button ID="TransBtn" runat="server" Text="Online Deposit" PostBackUrl="~/OnlineTrans.aspx" OnClick="btnTransaction_Click" CssClass="sidebar-button" /><br />
    <asp:Button ID="BillPayBtn" runat="server" Text="Bill Payment" PostBackUrl="~/BillPayment.aspx" OnClick="btnBillPayment_Click" CssClass="sidebar-button" /><br />
    <asp:Button ID="TransHistoryBtn" runat="server" Text="Transaction History" PostBackUrl="~/TransHistory.aspx" OnClick="btnTransactionHistory_Click" CssClass="sidebar-button" /><br />
    <asp:Button ID="PinChangeBtn" runat="server" Text="Pin Change" PostBackUrl="~/PinChange.aspx" OnClick="btnPinChange_Click" CssClass="sidebar-button" /><br />
    <asp:Button ID="MobileRechargeBtn" runat="server" Text="Mobile Recharge" PostBackUrl="~/MobileRecharge.aspx" OnClick="btnMobileRecharge_Click" CssClass="sidebar-button" /><br />
    <asp:Button ID="SignOutBtn" runat="server" Text="Sign Out" PostBackUrl="~/FrontPage.aspx" CssClass="sidebar-button signout-button" OnClick="btnSignOut_Click" />
</div>
