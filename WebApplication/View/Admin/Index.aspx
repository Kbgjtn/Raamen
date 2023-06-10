<%@ Page Title="" Language="C#" MasterPageFile="~/View/Index.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WebApplication.View.Admin.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>Admin</h1>

        <div>
            <h3>Staff List</h3>
            <asp:GridView ID="GridViewStaffs" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="Username" HeaderText="Username" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                    <asp:BoundField DataField="Gender" HeaderText="Gender" />
                    <asp:BoundField DataField="Role.Name" HeaderText="Role" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
