﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PatientMedicationsTests.aspx.cs" Inherits="HospitalApp.MyStuff.PatientMedicationsTests" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">



    <p>
        &nbsp;</p>
    <p>
        <span style="font-size: x-large">Medication and Test Results</span>
        </p>
    <p>
        &nbsp;</p>
    <p>
        Medications</p>
    <p>
        <asp:GridView ID="GridView1" HorizontalAlign="Center" ShowHeader="false" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="30" ForeColor="Black" GridLines="Horizontal">
        </asp:GridView>
    </p>
    <p>
        
        
        &nbsp;</p>
    <p>
        Test Results</p>
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
