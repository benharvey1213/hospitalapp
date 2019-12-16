<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PatientTests.aspx.cs" Inherits="HospitalApp.MyStuff.PatientTests" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        &nbsp;</p>
    <p>
        <span style="font-size: large">Here are your test results,
        <asp:Label ID="NameLabel" runat="server"></asp:Label>
        </span></p>
    <p>
        <asp:GridView ID="GridView1" HorizontalAlign="Center" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="30" ForeColor="Black" GridLines="Horizontal" Width="885px">
        </asp:GridView>
    </p>
    <p>
        &nbsp;</p>
        <p><a href="/MyStuff/Dashboard.aspx" class="btn btn-primary btn-lg">Back</a>&nbsp; </p>
    <p>&nbsp;</p>
</asp:Content>
