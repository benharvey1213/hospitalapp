<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DoctorAppointments.aspx.cs" Inherits="HospitalApp.MyStuff.DoctorAppointments" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
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

    <div id="newAppointment" runat="server">
        <p>
            &nbsp;</p>
        <p style="font-size: large">
            <asp:Button ID="btnNewAppointment" runat="server" Text="New Appointment" OnClick="btnNewAppointment_Click" style="font-size: small" />
        </p>
    </div>

    <div id="buttonSearch" runat="server">
        <p>
            <asp:Button ID="btnSearch" runat="server" Text="Show Patient Search" OnClick="btnSearch_Click" />
        </p>
    </div>

    <div id="searchDiv" runat="server">
        <p>
            Search for a Patient</p>
        <p>
        
        <asp:textbox runat="server" id="inputfield" />
            &nbsp;</p>

        <p>
            <asp:Button ID="searchButton" runat="server" Text="Search" OnClick="searchButton_Click" Width="157px" />
        </p>
<%--        <p>
            &nbsp;</p>--%>
        <p>
            <asp:GridView ID="GridView2"  HorizontalAlign="Center" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView2_SelectedIndexChanged">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:BoundField DataField="PatientName" HeaderText="Patient Name" />
                </Columns>
            </asp:GridView>
        </p>
<%--        <p>
            &nbsp;</p>--%>
    </div>
    <div id="buttonCalendar" runat="server">
        <p>
            <asp:Button ID="btnCalendar" runat="server" Text="Show Date Selection" />
        </p>
    </div>
    <div id="calendarDiv" runat="server">
        <p>
            Select a Date</p>
        <div style="width: 370px; margin: 0 auto;">
            <asp:Calendar ID="Calendar1" runat="server" Height="179px" Width="370px" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>
        </div>
        <p>
            &nbsp;</p>
        <p>
            </p>
    </div>
    <div id="buttonTime" runat="server">
        <p>
            <asp:Button ID="btnTime" runat="server" Text="Show Time Selection" />
        </p>
    </div>
    <div id="timeDiv" runat="server">
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
<%--        <p>
            &nbsp;</p>--%>
        <p>
            </p>
    </div>
    <div id="confirm" runat="server">
        <p>
        &nbsp;</p>

        <p>
            <asp:Label ID="ConfirmLabel" runat="server"></asp:Label>
        </p>
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Confirm Appointment" />
        </p>
    </div>

    <p>&nbsp;</p>
    
    <div align="center">&nbsp; <a href="/MyStuff/Dashboard.aspx" class="btn btn-primary btn-lg" style="font-size: small">Back</a></div>
        <p>&nbsp;</p>
        <p>&nbsp;</p>
</asp:Content>
