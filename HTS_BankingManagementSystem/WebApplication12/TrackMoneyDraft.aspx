<%@ Page Title="" Language="C#" MasterPageFile="~/UserDashboard.Master" AutoEventWireup="true" CodeBehind="TrackMoneyDraft.aspx.cs" Inherits="WebApplication12.TrackMoneyDraft" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .container {
            background-color: #fff;
            padding: 20px;
            border-radius: 8px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            width: 100%;
            max-width: 800px;
            margin: 0 auto; /* Center the container horizontally */
        }

        .heading {
            text-align: center;
            margin-bottom: 20px;
            font-size: 24px;
            color: #3AAFA9;
        }

        .form-group {
            margin-bottom: 20px;
        }

        .form-group label {
            display: block;
            margin-bottom: 5px;
            font-weight: bold;
        }

        .form-group input[type=text] {
            width: 100%;
            padding: 8px;
            font-size: 16px;
            border: 1px solid #ccc;
            border-radius: 4px;
        }

        .big-button {
            padding: 10px 20px;
            font-size: 16px;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            background-color: #3AAFA9;
            color: white;
            transition: background-color 0.3s;
        }

        .big-button:hover {
            background-color: #2a7a6d;
        }

        .status-label {
            font-size: 18px;
            font-weight: bold;
            color: #3AAFA9;
            text-align: center;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h1 class="heading">Track Money Draft</h1>
        <div class="form-group">
            <label for="moneyDraftName">Name of Money Draft:</label>
            <asp:TextBox ID="NameTextBox" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Button ID="trackButton" runat="server" Text="Track" OnClick="trackButton_Click" CssClass="big-button" />
        </div>
        <asp:Label ID="statusLabel" runat="server" CssClass="status-label" Text=""></asp:Label>
        <div class="form-group">
            <asp:Button ID="downloadButton" runat="server" Text="Download Money Draft" OnClick="downloadButton_Click" CssClass="big-button" />
        </div>
    </div>
</asp:Content>
