<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DoctorAppointments.aspx.cs" Inherits="HospitalApp.MyStuff.DoctorAppointments" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>&nbsp;</p>
    <p>
        <span style="font-size: x-large">Appointments</span>

    </p>

    <div id="newAppointment" runat="server">
        <p>
            &nbsp;</p>
        <p style="font-size: large">
            <asp:Button ID="btnNewAppointment" runat="server" CssClass="btn" Text="New Appointment" OnClick="btnNewAppointment_Click" style="font-size: large" />
        </p>
    </div>
    <p>&nbsp;</p>

    <p>
        <p id="lblCurrent" runat="server" style="font-size: medium">Upcoming</p>
        <asp:GridView ID="GridView1" DataKeyNames="AppointmentID" OnRowDeleting="GridView1_RowDeleting" HorizontalAlign="Center" HeaderText="Medication Name" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="30" ForeColor="Black" GridLines="Horizontal" Width="1049px" >
            <Columns>
                <asp:BoundField DataField="Date" HeaderText="Date" />
                <asp:BoundField DataField="Patient" HeaderText="Patient" />
                <asp:BoundField DataField="Purpose" HeaderText="Purpose" />
                <asp:CommandField ButtonType="Button" ControlStyle-CssClass="btn small red" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>

        <p>&nbsp;</p>
        <p id="lblpast" runat="server" style="font-size: medium">Past</p>

        <asp:GridView ID="GridView2" DataKeyNames="AppointmentID" OnRowDeleting="GridView2_RowDeleting" HorizontalAlign="Center" HeaderText="Medication Name" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="30" ForeColor="Black" GridLines="Horizontal" Width="1049px" OnSelectedIndexChanged="GridView2_SelectedIndexChanged" >
            <Columns>
                <asp:BoundField DataField="Date" HeaderText="Date" />
                <asp:BoundField DataField="Patient" HeaderText="Patient" />
                <asp:BoundField DataField="Purpose" HeaderText="Purpose" />
                <asp:CommandField ShowSelectButton="True" />
                <asp:CommandField ButtonType="Button" ControlStyle-CssClass="btn small red" ShowDeleteButton="True" >
<ControlStyle CssClass="btn small red"></ControlStyle>
                </asp:CommandField>
            </Columns>
            <SelectedRowStyle BackColor="#BCD8C1" ForeColor="White" CssClass="gview" />
        </asp:GridView>
    </p>

    <div id="updateTestResultsDiv" runat="server" >
        <p>
            <asp:TextBox ID="TextBox1" AutoCompleteType="Disabled" runat="server" Width="577px"></asp:TextBox>
        </p>

        <p>
            <asp:Button ID="Button5" CssClass="btn small" runat="server" Text="Update Appointment Summary" OnClick="Button5_Click" style="font-size: medium" />
        </p>
    </div>


    <p>&nbsp;</p>

    <p>
        <asp:Button ID="Button4" runat="server" CssClass="btn2" Text="Back" Width="131px" OnClick="Button4_Click" />
    </p>

    <p>&nbsp;</p>

</asp:Content>
