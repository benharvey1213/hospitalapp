<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DoctorAppointments.aspx.cs" Inherits="HospitalApp.MyStuff.DoctorAppointments" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        &nbsp;</p>
    <p>
        Make a new appointment</p>
    <p>
        &nbsp;</p>
    <p>
        Search for a Patient</p>
    <p>
        
    <asp:textbox runat="server" id="inputfield" />
        &nbsp;</p>

    <p>
        <asp:Button ID="searchButton" runat="server" Text="Search" OnClick="searchButton_Click" Width="157px" />
    </p>
    <p>
        &nbsp;</p>
    <p>
        <asp:GridView ID="GridView2"  HorizontalAlign="Center" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView2_SelectedIndexChanged">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="PatientName" HeaderText="Patient Name" />
            </Columns>
        </asp:GridView>
    </p>
    <p>
        &nbsp;</p>
    <p>
        Select a Date</p>
    <div style="width: 370px; margin: 0 auto;">
        <asp:Calendar ID="Calendar1" runat="server" Height="179px" Width="370px" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>
    </div>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        Select a Time</p>
    <p>
        <asp:GridView ID="GridView3" HorizontalAlign="Center" runat="server" OnSelectedIndexChanged="GridView3_SelectedIndexChanged">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <%--<asp:BoundField DataField="Time" HeaderText="Time" />--%>
            </Columns>
        </asp:GridView>
    </p>
    <p>
        &nbsp;</p>
    <p>
        </p>
    <p>
        <asp:Label ID="ConfirmLabel" runat="server"></asp:Label>
    </p>
    <p>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Confirm Appointment" />
    </p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        <span style="font-size: large">Here are your appointments,
        <asp:Label ID="NameLabel" runat="server"></asp:Label>
        </span></p>
    <p>
        <asp:GridView ID="GridView1" HorizontalAlign="Center" HeaderText="Medication Name" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="Date" HeaderText="Date" />
                <asp:BoundField DataField="Patient" HeaderText="Patient" />
                <asp:BoundField DataField="Purpose" HeaderText="Purpose" />
                <asp:CommandField ButtonType="Button" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
    </p>
    <p>
        &nbsp;</p>
        <div align="center">&nbsp; <a href="/MyStuff/Dashboard.aspx" class="btn btn-primary btn-lg">Back</a></div>
    <p>&nbsp;</p>
    <p>&nbsp;</p>
</asp:Content>
