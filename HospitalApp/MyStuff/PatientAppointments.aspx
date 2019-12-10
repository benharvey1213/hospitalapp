<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PatientAppointments.aspx.cs" Inherits="HospitalApp.MyStuff.PatientAppointments" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        &nbsp;</p>
    <p>
        <span style="font-size: large">Here are your appointments,
        <asp:Label ID="NameLabel" runat="server"></asp:Label>
        </span></p>
    <p>
        <asp:GridView ID="GridView1" HorizontalAlign="Center" HeaderText="Medication Name" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        </asp:GridView>
    </p>
    <p>
        &nbsp;</p>
        <div align="center">&nbsp; <a href="/MyStuff/Dashboard.aspx" class="btn btn-primary btn-lg">Back</a></div>
    <p>&nbsp;</p>
    <p>&nbsp;</p>
</asp:Content>
