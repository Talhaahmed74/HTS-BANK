<%@ Page Title="" Language="C#" MasterPageFile="~/AdminDashboard.master" AutoEventWireup="true" CodeBehind="ModifyAccInfo.aspx.cs" Inherits="WebApplication12.ModifyAccInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
  .hidden {
            display: none;
        }
        .container {
            margin-top: 20px;
            text-align: center;
            background-color: #e3f2fd; 
            padding: 20px;
            border-radius: 10px;
        }
        .view-requests-button, .action-buttons button {
            padding: 15px 30px;
            font-size: 20px;
            margin: 20px;
            background-color: #007bff;
            color: white;
            border: none;
            border-radius: 10px;
            cursor: pointer;
        }
        .view-requests-button:hover, .action-buttons button:hover {
            background-color: #0056b3; 
        }
        .grid-container {
            display: flex;
            justify-content: center;
            margin-top: 20px;
        }
        .text-fields {
            margin: 20px auto;
            text-align: left;
            display: none;
            width: 100%;
            max-width: 600px;
        }
        .text-fields div {
            margin-bottom: 10px;
            display: flex;
            justify-content: space-between;
            align-items: center;
        }
        .text-fields label {
            width: 30%;
            margin-right: 10px;
        }
        .text-fields input {
            width: 65%;
            padding: 10px;
            font-size: 16px;
            border: 1px solid #ccc;
            border-radius: 5px;
        }
    </style>
    <script type="text/javascript">
        function showModifyView() {
            document.getElementById('<%= btnViewRequests.ClientID %>').style.display = 'none';
            document.getElementById('<%= modifyContainer.ClientID %>').style.display = 'block';
            document.getElementById('<%= gvRequests.ClientID %>').style.display = 'block';
        }

        function showRecordDetails() {
            document.getElementById('<%= btnViewRequests.ClientID %>').style.display = 'none';
            document.getElementById('<%= modifyContainer.ClientID %>').style.display = 'block';
            document.getElementById('<%= recordDetails.ClientID %>').style.display = 'block';
            document.getElementById('<%= gvRequests.ClientID %>').style.display = 'none';
        }

        function showGridView() {
            document.getElementById('<%= btnViewRequests.ClientID %>').style.display = 'block';
            document.getElementById('<%= modifyContainer.ClientID %>').style.display = 'none';
            document.getElementById('<%= recordDetails.ClientID %>').style.display = 'none';
            document.getElementById('<%= gvRequests.ClientID %>').style.display = 'block';
        }
        
        function hideRecordDetails() {
            document.getElementById('<%= btnViewRequests.ClientID %>').style.display = 'block';
            document.getElementById('<%= modifyContainer.ClientID %>').style.display = 'none';
            document.getElementById('<%= recordDetails.ClientID %>').style.display = 'none';
            document.getElementById('<%= gvRequests.ClientID %>').style.display = 'block';
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <asp:Button ID="btnViewRequests" runat="server" Text="View Modify Account Info Requests" CssClass="view-requests-button" OnClientClick="showModifyView(); return false;" />

        <div id="modifyContainer" runat="server" class="text-fields hidden">
            <asp:GridView ID="gvRequests" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvRequests_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="AccountNumber" HeaderText="Account Number" />
                    <asp:BoundField DataField="AccountName" HeaderText="First Name" />
                    <asp:BoundField DataField="AccountAddress" HeaderText="Address" />
                    <asp:BoundField DataField="AccountType" HeaderText="Account Type" />
                    <asp:BoundField DataField="AccountPhoneNumber" HeaderText="Phone Number" />
                    <asp:BoundField DataField="RequestDescription" HeaderText="Request Description" />
                    <asp:CommandField ShowSelectButton="True" />
                </Columns>
            </asp:GridView>
        </div>
            
        <div id="recordDetails" runat="server" class="text-fields hidden">
            <div>
                <asp:Label ID="lblAccountNumber" runat="server" Text="Account Number:"></asp:Label>
                <asp:TextBox ID="txtAccountNumber" runat="server" Enabled="false"></asp:TextBox>
            </div>
            <div class="flex-container">
                <div style="flex: 1;">
                    <asp:Label ID="lblFirstName" runat="server" Text="Name:"></asp:Label>
                    <asp:TextBox ID="txtName" runat="server" Enabled="false"></asp:TextBox>
                </div>
               <%-- <div style="flex: 1;">
                    <asp:Label ID="lblLastName" runat="server" Text="Last Name:"></asp:Label>
                    <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                </div>--%>
            </div>
            <div>
                <asp:Label ID="lblAddress" runat="server" Text="Address:"></asp:Label>
                <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="lblAccountType" runat="server" Text="Account Type:"></asp:Label>
                <asp:TextBox ID="txtAccountType" runat="server" Enabled="false"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="lblPhoneNumber" runat="server" Text="Phone Number:"></asp:Label>
                <asp:TextBox ID="txtPhoneNumber" runat="server" Enabled="false"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="Branch" runat="server" Text="Branch Name:"></asp:Label>
                <asp:TextBox ID="txtBranch" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="lblRequestDescription" runat="server" Text="Request Description:"></asp:Label>
                <asp:TextBox ID="txtRequestDescription" runat="server" Enabled="false"></asp:TextBox>
            </div>

            <div class="action-buttons">
                <asp:Button ID="btnModify" runat="server" Text="Modify Info" OnClick="btnModify_Click" CssClass="action-buttons button" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" CssClass="action-buttons button" />
            </div>
        </div>
    </div>
</asp:Content>
