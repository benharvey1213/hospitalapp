<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HospitalApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Hospital</h1>
        <p>&nbsp;</p>
        <p id="dashp" runat="server">&nbsp;<asp:Button ID="DashboardButton" runat="server" Text="Dashboard" OnClick="Button1_Click" Width="165px" /></p>
        <p id="inp" runat="server">&nbsp;<asp:Button ID="LoginButton" runat="server" Text="Login" OnClick="Button2_Click" Width="165px" /></p>
        <p id="outp" runat="server">&nbsp;<asp:Button ID="LogoutButton" runat="server" Text="Logout" OnClick="Button3_Click" Width="165px"/></p>
    </div>

    <div class="row">
        <div class="col-md-4">
        </div>
    </div>

</asp:Content>
