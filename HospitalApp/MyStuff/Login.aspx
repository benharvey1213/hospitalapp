<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="HospitalApp.MyStuff.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>&nbsp;</h1>
    <h1>HOSPITAL</h1>
    <h2>w&nbsp;&nbsp;&nbsp; e&nbsp;&nbsp;&nbsp; l&nbsp;&nbsp;&nbsp; c&nbsp;&nbsp;&nbsp; o&nbsp;&nbsp;&nbsp; m&nbsp;&nbsp;&nbsp; e</h2>
    <p>
    </p>
    <p>
        Please Enter Login Information:</p>
    <p>
        <asp:Label ID="ErrorPlaceholder" runat="server" style="color: #FF0000"></asp:Label>
    </p>
    <p>
        Username:</p>
    <p>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    </p>
    <p>
        Password:</p>
    <p>
        <asp:TextBox ID="TextBox2" TextMode="Password" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Login" />
    </p>
    <p>
        &nbsp;</p>
    <h3>
        <asp:HyperLink ID="HyperLink1" runat="server">Don&#39;t Have An Account?</asp:HyperLink>
    </h3>
    <p>
        &nbsp;</p>
    <p>
    </p>
</asp:Content>
