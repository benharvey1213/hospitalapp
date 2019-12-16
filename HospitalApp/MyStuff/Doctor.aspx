<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Doctor.aspx.cs" Inherits="HospitalApp.MyStuff.Doctor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h4>&nbsp;</h4>

    <h4>
        <asp:Label ID="GreetingLabel" runat="server" style="font-size: xx-large"></asp:Label>
    </h4>

    <p>&nbsp;</p>

    <p>
        <asp:Button ID="Button1" runat="server" CssClass="btn" Text="Manage Appointments" Width="293px" OnClick="Button1_Click" style="font-size: large" />
    </p>

    <p>
        <asp:Button ID="Button2" runat="server" class="btn" OnClick="Button2_Click" Text="View Patients" Width="293px" style="font-size: large" />
    </p>

    <p>
        <asp:Button ID="Button3" runat="server" class="btn" Text="Messages" Width="293px" OnClick="Button3_Click" style="font-size: large" />
    </p>

    <p>&nbsp;</p>

     <p>
        <asp:Button ID="Button4" runat="server" class="btn2" Text="Home" Width="293px" OnClick="Button4_Click" style="font-size: large" />
    </p>

    <p>&nbsp;</p>
</asp:Content>
