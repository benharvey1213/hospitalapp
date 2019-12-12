<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PatientMedicationsTests.aspx.cs" Inherits="HospitalApp.MyStuff.PatientMedicationsTests" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        &nbsp;</p>
    <p>
        <span style="font-size: large">Medication and Test Results</span>
        </p>
    <p>
        &nbsp;</p>
    <p>
        Medications</p>
    <p>
        <asp:GridView ID="GridView1" HorizontalAlign="Center" HeaderText="Medication Name" runat="server" >
        </asp:GridView>
    </p>
    <p>
        &nbsp;</p>
    <p>
        Test Results</p>
    <p>
        <asp:GridView ID="GridView2" HorizontalAlign="Center" runat="server">
        </asp:GridView>
    </p>
    <p>
        &nbsp;</p>
        <p><a href="/MyStuff/Dashboard.aspx" class="btn btn-primary btn-lg">Back</a>&nbsp; </p>
    <p>&nbsp;</p>
</asp:Content>
