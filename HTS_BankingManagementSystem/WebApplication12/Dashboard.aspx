<%@ Page Title="Dashboard" Language="C#" MasterPageFile="~/UserDashboard.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="WebApplication12.Dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        body, html {
            height: 100%;
            margin: 0;
        }
        .content-area {
          background-color: #fcebeb; 
            padding: 20px;
            min-height: 100%; 
            display: flex;
            justify-content: center;
            align-items: center;
        }
        .content-area img {
            width: 450px; 
            height: auto; 
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-area">
        <img src="UI/Images/HTS%20LOGO.png" alt ="HTS Bank Logo"/>
    </div>
</asp:Content>
