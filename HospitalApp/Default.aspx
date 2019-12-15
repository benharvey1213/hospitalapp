<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HospitalApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1 style="font-size: 75px">Hospital</h1>
        <p id="dashp" runat="server">&nbsp;<asp:Button ID="DashboardButton" CssClass="btn big" runat="server" Text="Dashboard" OnClick="Button1_Click" Width="240px" style="font-size: 30px" /></p>
        <p id="inp" runat="server">&nbsp;<asp:Button ID="LoginButton" CssClass="btn big" runat="server" Text="Login" OnClick="Button2_Click" Width="240px" style="font-size: 30px" /></p>
        <p id="outp" runat="server">&nbsp;<asp:Button ID="LogoutButton" CssClass="btn big" runat="server" Text="Logout" OnClick="Button3_Click" Width="240px" style="font-size: 30px"/></p>
    </div>

    <div class="row">
        <div class="col-md-4">
        </div>
    </div>

</asp:Content>
