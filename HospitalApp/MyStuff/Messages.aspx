<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Messages.aspx.cs" Inherits="HospitalApp.MyStuff.Messages" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="messagingDiv" runat="server">
        <p>
            &nbsp;</p>
        <p>Send a Message:</p>
    
            <p>
                To:
                <asp:DropDownList ID="DropDownList1" runat="server"/>
            </p>
            <p>
                <asp:TextBox ID="TextBox2" runat="server" autocomplete="off" Width="644px"/>
            </p>
   
        <p>
            <asp:Label ID="ErrorLabel" runat="server" style="color: #FF0000"></asp:Label>
        </p>
        <p>
            &nbsp;<asp:Button ID="Button1" CssClass="btn small" runat="server" Text="Send" OnClick="Button1_Click" />
        </p>
    </div>
    <p>&nbsp;</p>
    <p id="btnSendDoctor" runat="server">
        <asp:Button ID="Button3" CssClass="btn" runat="server" Text="Send a Message" OnClick="Button3_Click" style="font-size: medium" />
    </p>
    <p>
        &nbsp;</p>
    <p>
        <asp:Label ID="TableLabel" runat="server" style="font-size: medium"></asp:Label>
    </p>
    <p>
        <asp:GridView ID="GridView1" datakeynames="MessageID" CellSpacing="5" HorizontalAlign="Center" runat="server" OnRowDeleting="GridView1_RowDeleting" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="30" ForeColor="Black" GridLines="Horizontal" Width="1049px" style="margin-bottom: 0px">
            <Columns>
                <asp:BoundField DataField="Date" HeaderText="Date" />
                <asp:BoundField DataField="Sender" HeaderText="Sender" />
                <asp:BoundField DataField="Message" HeaderText="Message" />
                <asp:CommandField ButtonType="Button" ShowDeleteButton="True" ControlStyle-CssClass="btn small red" />
            </Columns>
        </asp:GridView>
    </p>

    <p>
        &nbsp;</p>
    <p>
        <asp:Label ID="TableLabel2" runat="server" style="font-size: medium"></asp:Label>
    </p>
    <p>
        <asp:GridView ID="GridView2" datakeynames="MessageID" CellSpacing="5" HorizontalAlign="Center" runat="server" OnRowDeleting="GridView2_RowDeleting" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="30" ForeColor="Black" GridLines="Horizontal" Width="1049px" style="margin-bottom: 0px" OnSelectedIndexChanged="GridView2_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="Date" HeaderText="Date" />
                <asp:BoundField DataField="Recipient" HeaderText="Recipient" />
                <asp:BoundField DataField="Message" HeaderText="Message" />
                <asp:CommandField ButtonType="Button" ShowDeleteButton="True" ControlStyle-CssClass="btn small red" />
            </Columns>
        </asp:GridView>
    </p>

    <p>
        &nbsp;</p>
        <p>
        <asp:Button ID="Button4" runat="server" CssClass="btn2" Text="Back" Width="131px" OnClick="Button4_Click" />
    </p>
    <p>&nbsp;</p>
</asp:Content>
