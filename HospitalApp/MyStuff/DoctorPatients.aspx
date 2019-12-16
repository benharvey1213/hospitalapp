<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DoctorPatients.aspx.cs" Inherits="HospitalApp.MyStuff.DoctorPatients" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>&nbsp;</p>

    <p id="header" runat="server" style="font-size: xx-large">Patients</p>


    <p id="searchDiv" runat="server">
        <p>
            <asp:Button ID="Button8" runat="server" class="btn small" Text="View My Patients" Width="190px" OnClick="Button8_Click" />
        </p>
        <p>
        <asp:TextBox ID="TextBox1" runat="server" Width="263px"></asp:TextBox>
        &nbsp;<asp:Button ID="Button1" runat="server" class="btn" Text="Search" Width="131px" OnClick="Button1_Click" />
            </p>
        <p>&nbsp;</p>

        <asp:GridView ID="GridView1" runat="server" DataKeyNames="Username" HorizontalAlign="Center" ShowHeader="False" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="30" ForeColor="Black" GridLines="Horizontal" Width="197px">
            <Columns>
                <asp:BoundField DataField="Name" />
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
            <SelectedRowStyle BackColor="#BCD8C1" ForeColor="White" CssClass="gview" />

        </asp:GridView>
    </p>
    <p>&nbsp;</p>
    <p id="buttonsDiv" runat="server">
        <asp:Button ID="Button2" class="btn small" runat="server" Text="Message" OnClick="Button2_Click" Style="font-size: medium" />
        <asp:Button ID="Button3" class="btn small" runat="server" Text="Make Appointment" OnClick="Button3_Click" Style="font-size: medium" />
        <asp:Button ID="Button7" class="btn small" runat="server" Text="Toggle Patient Info" OnClick="Button7_Click" Style="font-size: medium" />
        <p>&nbsp;</p>
    </p>
    <p id="messager" runat="server">
        <p>
            <asp:Label ID="lblTo" runat="server" Text=""></asp:Label>
        </p>
        <p>
            <asp:TextBox runat="server" ID="Textbox3" Width="514px" AutoCompleteType="Disabled" />
        </p>
        <p>
            <asp:Button ID="Button6" class="btn" runat="server" Text="Send" OnClick="Button6_Click" />
        </p>
        <p>&nbsp;</p>
    </p>

    <div id="patientInfoDiv" runat="server">
        <p>
            <asp:Label ID="lblPatientName" runat="server" Text=""></asp:Label>
        </p>
        <p>
            <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label>
        </p>
        <p>
            &nbsp;</p>
        <p id="testResultsName" runat="server">
            Test Results</p>
        <p>
            <asp:GridView ID="GridView2" HorizontalAlign="Center" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="30" ForeColor="Black" GridLines="Horizontal" Width="719px">
            </asp:GridView>     
        </p>

        <p>
            &nbsp;</p>
        <p>
            <asp:Label ID="lblHistory" runat="server" Text=""></asp:Label>
        </p>
        <p>
            <asp:GridView ID="GridView3" HorizontalAlign="Center" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="30" ForeColor="Black" GridLines="Horizontal" Width="509px" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="Date" HeaderText="Date" />
                    <asp:BoundField DataField="Purpose" HeaderText="Purpose" />
                </Columns>
            </asp:GridView>     
        </p>
        <p>
            &nbsp;</p>
        <p>
            <asp:Label ID="lblMedication" runat="server" Text=""></asp:Label>
        </p>
        <p>
        <asp:GridView ID="GridView4" HorizontalAlign="Center" ShowHeader="false" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="30" ForeColor="Black" GridLines="Horizontal">
        </asp:GridView>
    </p>

        <p>&nbsp;</p>

    </div>

    <p id="confirmation" runat="server">
        <asp:Label ID="lblConfirmation" runat="server" Style="font-size: small"></asp:Label>
        <p>
    </p>
    </p>
    <div id="appointmentDiv" runat="server">
        <p>
            <asp:Label ID="lblPatient" runat="server"></asp:Label>
        </p>
        <div style="width: 309px; margin: 0 auto; height: 190px;">
            <asp:Calendar ID="Calendar1" AutoPostback="false" runat="server" Width="309px" Height="190px" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>
        </div>
        <p>&nbsp;</p>
        <p>
            <asp:DropDownList ID="DropDownList1" runat="server" Width="164px">
            </asp:DropDownList>
        </p>
        <p>&nbsp;</p>
        <p>
            Reason for Appointment:       
        <p>
            <asp:TextBox runat="server" ID="inputfield0" Width="514px" AutoCompleteType="Disabled" />
        </p>
        <p>&nbsp;</p>
        <p>

            <asp:CheckBox ID="CheckBox1" runat="server" Text="Send confirmation to patient?" Checked="true" />

        </p>
        <p>&nbsp;</p>
        <p>
            <asp:Button ID="Button5" class="btn" runat="server" Text="Confirm Appointment" OnClick="Button5_Click" />
        </p>
        <p>&nbsp;</p>

    </div>

    <p>
        <asp:Button ID="Button4" runat="server" class="btn2" Text="Back" Width="131px" OnClick="Button4_Click" />
    </p>

    <p>&nbsp;</p>

</asp:Content>
