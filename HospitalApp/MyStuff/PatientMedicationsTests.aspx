<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PatientMedicationsTests.aspx.cs" Inherits="HospitalApp.MyStuff.PatientMedicationsTests" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>&nbsp;</p>

    <p style="font-size: x-large">
        Medications</p>
    <p id="noMeds" runat="server">
        No Medications Found</p>
    <p>
        <asp:GridView ID="GridView1" HorizontalAlign="Center" ShowHeader="false" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="30" ForeColor="Black" GridLines="Horizontal">
        </asp:GridView>
    </p>
    <p>
        
        
        &nbsp;</p>
    <p style="font-size: x-large">
        Test Results</p>

    <p id="noTests" runat="server">
        No Test Results Found</p>
    <p>
        <asp:GridView ID="GridView2" CssClass="gview" HorizontalAlign="Center" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="30" ForeColor="Black" GridLines="Horizontal" Width="596px">
        </asp:GridView>
    </p>
    <p>
        &nbsp;</p>
     <p>
        <asp:Button ID="Button4" runat="server" CssClass="btn2" Text="Back" Width="131px" OnClick="Button4_Click" />
    </p>
    <p>&nbsp;</p>
</asp:Content>
