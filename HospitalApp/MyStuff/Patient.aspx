<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Patient.aspx.cs" Inherits="HospitalApp.MyStuff.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h4>&nbsp;</h4>
    <p>
        <asp:Label ID="WelcomeLabel" runat="server" style="font-size: x-large"></asp:Label>
    </p>
    <p>
        <asp:Button ID="Button1" runat="server" Text="Manage Appointments" Width="293px" OnClick="Button1_Click" />
    </p>
    <p>
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Medications and Test Results" Width="293px" />
    </p>
    <p>
        <asp:Button ID="Button4" runat="server" Text="Messages" Width="293px" OnClick="Button4_Click" />
    </p>
    <p>
        &nbsp;</p>
</asp:Content>
