<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Patient.aspx.cs" Inherits="HospitalApp.MyStuff.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h4>&nbsp;</h4>
    <p>
        <asp:Label ID="WelcomeLabel" runat="server" style="font-size: 40px"></asp:Label>
    </p>
    <p>
        <asp:Button ID="Button1" CssClass="btn" runat="server" Text="Manage Appointments" Width="425px" OnClick="Button1_Click" style="font-size: 20px" />
    </p>
    <p>
        <asp:Button ID="Button2" CssClass="btn" runat="server" OnClick="Button2_Click" Text="Medications and Test Results" Width="425px" style="font-size: 20px" />
    </p>
    <p>
        <asp:Button ID="Button4" CssClass="btn" runat="server" Text="Messages" Width="425px" OnClick="Button4_Click" style="font-size: 20px" />
    </p>
    <p>
        &nbsp;</p>

    <p>
        <asp:Button ID="Button5" CssClass="btn2" runat="server" Text="Home" Width="136px" OnClick="Button5_Click" style="font-size: 20px" />
    </p>

    <p>
        &nbsp;</p>
</asp:Content>
