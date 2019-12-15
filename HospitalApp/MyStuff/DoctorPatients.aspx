<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DoctorPatients.aspx.cs" Inherits="HospitalApp.MyStuff.DoctorPatients" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>&nbsp;</p>
    <p style="font-size: large">View Patients</p>
    <p>
        <asp:TextBox ID="TextBox1" runat="server" Width="263px"></asp:TextBox>
&nbsp;<asp:Button ID="Button1" runat="server" class="btn" Text="Search" Width="131px" OnClick="Button1_Click" />

        <asp:GridView ID="GridView1" runat="server" datakeynames="Username" HorizontalAlign="Center" ShowHeader="False" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" >
            <Columns>
                <asp:BoundField DataField="Name" />
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
    </p>
    <p>
        &nbsp;</p>
    <p id="buttonsDiv" runat="server">
        <asp:Button ID="Button2" class="btn" runat="server" Text="Message" OnClick="Button2_Click" />
        <asp:Button ID="Button3" class="btn" runat="server" Text="Make Appointment" OnClick="Button3_Click" />
    </p>
    <p id="lblErrorDiv" runat="server">
        <asp:Label ID="lblError" runat="server" style="color: #CC0000"></asp:Label>
        <p>
        &nbsp;</p>
    </p>
    <p id="confirmation" runat="server">

        <asp:Label ID="lblConfirmation" runat="server" style="font-size: small"></asp:Label>

    </p>
    <div ID="appointmentDiv" runat="server">
        <p>
            &nbsp;</p>
        <p>
            <asp:Label ID="lblPatient" runat="server"></asp:Label>
        </p>
        <div style="width:309px; margin: 0 auto; height: 190px;">
            <asp:Calendar ID="Calendar1" AutoPostback = false runat="server" Width="309px" Height="190px" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>
        </div>
        <p>
            &nbsp;</p>
        <p>
            <asp:DropDownList ID="DropDownList1" runat="server" Width="164px">
            </asp:DropDownList>
        </p>
        <p>
            &nbsp;</p><p>
            Reason for Appointment:</p>
        <p>
            <asp:textbox runat="server" id="inputfield0" Width="514px" />
            </p>
        <p>
            &nbsp;</p>
        <p>
            <asp:Button ID="Button5" class="btn" runat="server" Text="Confirm Appointment" OnClick="Button5_Click" />
        </p>
        <p>
            &nbsp;</p>

    </div>
        <%--<p><a href="/MyStuff/Dashboard.aspx" class="btn2">Back</a>&nbsp; </p>--%>
<%--    <p>
        &nbsp;</p>--%>
    <p>
        <asp:Button ID="Button4" runat="server" class="btn2" Text="Back" Width="131px" OnClick="Button4_Click" />
        </p>
    <p>
        &nbsp;</p>

</asp:Content>