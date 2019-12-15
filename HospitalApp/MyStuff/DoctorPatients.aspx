<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DoctorPatients.aspx.cs" Inherits="HospitalApp.MyStuff.DoctorPatients" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>&nbsp;</p>
    <p style="font-size: large">View Patients</p>
    <p>
        <asp:TextBox ID="TextBox1" runat="server" Width="263px"></asp:TextBox>
&nbsp;<asp:Button ID="Button1" runat="server" class="btn" Text="Search" Width="131px" OnClick="Button1_Click" />

        <asp:GridView ID="GridView1" runat="server" CellSpacing="5" HorizontalAlign="Center" ShowHeader="False" AutoGenerateColumns="False" OnRowDataBound = "OnRowDataBound" OnSelectedIndexChanged = "OnSelectedIndexChanged" >
            <Columns>
                <asp:BoundField DataField="Name" />
            </Columns>
        </asp:GridView>

        <asp:LinkButton ID="lnkDummy" runat="server"></asp:LinkButton>

    </p>
    <p>
        &nbsp;</p>
        <p><a href="/MyStuff/Dashboard.aspx" class="btn btn-primary btn-lg">Back</a>&nbsp; </p>
    <p>&nbsp;</p>

</asp:Content>