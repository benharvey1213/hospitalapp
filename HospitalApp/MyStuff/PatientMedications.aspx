<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PatientMedications.aspx.cs" Inherits="HospitalApp.MyStuff.PatientMedications" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        &nbsp;</p>
    <p>
        <span style="font-size: large">Here is your current list of medications,</span>
        <asp:Label ID="NameLabel" runat="server" style="font-size: large"></asp:Label>
        <span style="font-size: large">.</span></p>
    <p>
        <asp:GridView ID="GridView1" HorizontalAlign="Center" HeaderText="Medication Name" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        </asp:GridView>
    </p>
    <p>
        &nbsp;</p>
</asp:Content>
