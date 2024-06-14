<%@ Page Title="AdminDefaultDash" Language="C#" MasterPageFile="~/AdminDashboard.master" AutoEventWireup="true" CodeBehind="AdminDefaultDash.aspx.cs" Inherits="WebApplication12.AdminDefaultDash" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        body, html {
           height:100%;
            margin: 0;
        }
        .content-area {
            background-color: #060c21;
            padding: 20px;
            height: calc(100% - 20px); 
            display: flex;
            justify-content: center;
            align-items: center;
        }
        .content-area img {
            width: 450px;
            height: auto;
            pointer-events: none; /* Prevents dragging */
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-area">
        <center>
        <img src="UI/Images/HTSLOGO_2.0.png"/>
    </div>
</asp:Content>
