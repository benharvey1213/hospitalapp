<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Doctor.aspx.cs" Inherits="HospitalApp.MyStuff.Doctor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h4>
        &nbsp;</h4>
    <h4>
        <asp:Label ID="GreetingLabel" runat="server" style="font-size: x-large"></asp:Label>
    </h4>
    <p>
        &nbsp;</p>
    <p>
        <asp:Button ID="Button1" runat="server" class="btn" Text="Manage Appointments" Width="293px" OnClick="Button1_Click" />
    </p>
    <p>
        <asp:Button ID="Button2" runat="server" class="btn" OnClick="Button2_Click" Text="View Patients" Width="293px" />
    </p>
    <p>
        <asp:Button ID="Button3" runat="server" class="btn" Text="Messages" Width="293px" OnClick="Button3_Click" />
    </p>
    <p>
        &nbsp;</p>
    <p>
    </p>
</asp:Content>
