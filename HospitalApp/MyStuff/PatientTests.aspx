<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PatientTests.aspx.cs" Inherits="HospitalApp.MyStuff.PatientTests" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        &nbsp;</p>
    <p>
        <span style="font-size: large">Here are your test results,
        <asp:Label ID="NameLabel" runat="server"></asp:Label>
        </span></p>
    <p>
        <asp:GridView ID="GridView1" HorizontalAlign="Center" runat="server">
        </asp:GridView>
    </p>
    <p>
        &nbsp;</p>
</asp:Content>
