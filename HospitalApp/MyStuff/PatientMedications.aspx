<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PatientMedications.aspx.cs" Inherits="HospitalApp.MyStuff.PatientMedications" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        &nbsp;</p>
    <p>
        <span style="font-size: large">Here is your current list of medications,</span>
        <asp:Label ID="NameLabel" runat="server" style="font-size: large"></asp:Label>
        </p>
    <p>
        <asp:GridView ID="GridView1" HorizontalAlign="Center" HeaderText="Medication Name" runat="server" >
        </asp:GridView>
    </p>
    <p>
        &nbsp;</p>
        <p><a href="/MyStuff/Dashboard.aspx" class="btn btn-primary btn-lg">Back</a>&nbsp; </p>
    <p>&nbsp;</p>
</asp:Content>
