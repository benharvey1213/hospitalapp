<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PatientAppointments.aspx.cs" Inherits="HospitalApp.MyStuff.PatientAppointments" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        &nbsp;</p>
    <div id="aptDiv" runat="server">
        <p>
            <span style="font-size: x-large">Appointments</span></p>
        <p>
            <asp:GridView ID="GridView1" HorizontalAlign="Center" HeaderText="Medication Name" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="30" ForeColor="Black" GridLines="Horizontal" Width="620px" >
            </asp:GridView>
        </p>
    </div>

    <div id="confirmationDiv" runat="server">
        <p>&nbsp;</p>
        <p>
            <asp:Label ID="lblConfirmation" runat="server" Text=""></asp:Label>
        </p>


    </div>

    <div id="btnScheduleDiv" runat="server">
        <p>&nbsp;</p>

        <p>
            <asp:Button ID="Button5" CssClass="btn" runat="server" Text="Schedule an Appointment" style="font-size: medium" OnClick="Button5_Click" />
        </p>
    </div>
    <div id="appointmentDiv" runat="server">
        <p style="font-size: x-large">
            Schedule an Appointment</p>
        <p style="font-size: medium">
            &nbsp;</p>
        <p style="font-size: medium">
            Department</p>
        <p>
            <asp:DropDownList ID="ddlDepartment" runat="server" OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged" AutoPostBack="True" >
            </asp:DropDownList>
        </p>
        <p>
            &nbsp;</p>
        <p style="font-size: medium">
            Doctor</p>
        <p>
            <asp:DropDownList ID="ddlDoctor" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDoctor_SelectedIndexChanged" >
            </asp:DropDownList>
        </p>
        <p>
            &nbsp;</p>
        <p style="font-size: medium">
            Date</p>
        <p>
            <asp:Calendar ID="Calendar1" Align="center" runat="server" Width="367px" AutoPostBack="True" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>
        </p>
        <p>
            &nbsp;</p>
        <p style="font-size: medium">
            Time</p>
        <p>
            <asp:DropDownList ID="ddlTimes" runat="server">
            </asp:DropDownList>
        </p>
        <p>
            &nbsp;</p>
        <p style="font-size: medium">
            Purpose for Appointment</p>
        <p>
            <asp:TextBox ID="textBoxPurpose" AutoCompleteType="Disabled" runat="server" Width="380px"></asp:TextBox>

        </p>
        <p>
            &nbsp;</p>
        <p>
            <asp:Button ID="btnSchedule" CssClass="btn" runat="server" Text="Schedule" style="font-size: medium" OnClick="btnSchedule_Click" />

        </p>
    </div>
    <p>
        &nbsp;</p>
        <p>
        <asp:Button ID="Button4" runat="server" CssClass="btn2" Text="Back" Width="131px" OnClick="Button4_Click" />
    </p>
    <p>&nbsp;</p>
</asp:Content>
