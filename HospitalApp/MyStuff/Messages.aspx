<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Messages.aspx.cs" Inherits="HospitalApp.MyStuff.Messages" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<p>
        &nbsp;</p>
    <p>
        Send a Message:</p>
    <p>
        <table style="width:100%;">
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </p>
    <p>
        &nbsp;</p>
    <p>
        Messages:</p>
    <p>
        <asp:GridView ID="GridView1" HorizontalAlign="Center" runat="server">
        </asp:GridView>
    </p>
    <p>
        &nbsp;</p>
        <p><a href="/MyStuff/Dashboard.aspx" class="btn btn-primary btn-lg">Back</a>&nbsp; </p>
    <p>&nbsp;</p>
</asp:Content>
