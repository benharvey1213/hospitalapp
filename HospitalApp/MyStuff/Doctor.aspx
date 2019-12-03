<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Doctor.aspx.cs" Inherits="HospitalApp.MyStuff.Doctor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h4>
        <br />
        Welcome, Dr. (name go here)</h4>
    <p>
        <asp:Button ID="Button1" runat="server" Text="Manage Appointments" Width="293px" />
    </p>
    <p>
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="View Patients" Width="293px" />
    </p>
    <p>
        <asp:Button ID="Button3" runat="server" Text="Messages" Width="293px" />
    </p>
    <p>
        &nbsp;</p>
    <p>
    </p>
</asp:Content>
