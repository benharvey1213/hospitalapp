<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Messages.aspx.cs" Inherits="HospitalApp.MyStuff.Messages" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        &nbsp;</p>
    <p>
        Send a Message:</p>
    <p>
        <table style="width:100%;">
            <tr>
                <td>To</td>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="height: 25px">Message</td>
                <td style="height: 25px">
                    <asp:TextBox ID="TextBox2" runat="server" autocomplete="off" Width="520px"></asp:TextBox>
                </td>
            </tr>
            </table>
    </p>
    <p>
        <asp:Label ID="ErrorLabel" runat="server" style="color: #FF0000"></asp:Label>
    </p>
    <p>
        &nbsp;<asp:Button ID="Button1" runat="server" Text="Send" OnClick="Button1_Click" />
    </p>
    <p>&nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        <asp:Label ID="TableLabel" runat="server"></asp:Label>
    </p>
    <p>
        <asp:GridView ID="GridView1" datakeynames="MessageID" CellSpacing="5" HorizontalAlign="Center" runat="server" OnRowDeleting="GridView1_RowDeleting" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="Date" HeaderText="Date" />
                <asp:BoundField DataField="Sender" HeaderText="Sender" />
                <asp:BoundField DataField="Message" HeaderText="Message" />
                <asp:CommandField ButtonType="Button" ShowDeleteButton="True" ControlStyle-CssClass="btn" />
            </Columns>
        </asp:GridView>
    </p>
    <p>
        &nbsp;</p>
        <div align="center">&nbsp; <a href="/MyStuff/Dashboard.aspx" class="btn btn-primary btn-lg">Back</a></div>
    <p>&nbsp;</p>
</asp:Content>
