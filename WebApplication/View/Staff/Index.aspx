<%@ Page Title="Home" Language="C#" MasterPageFile="~/View/Index.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WebApplication.View.Staff.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>Staff</h1>

        <div>
            <h3>Customers</h3>
            <asp:GridView ID="GridViewCustomers" runat="server" AutoGenerateColumns="false">
                <columns>
                    <asp:BoundField DataField="Username" HeaderText="Username" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                    <asp:BoundField DataField="Gender" HeaderText="Gender" />
                    <asp:BoundField DataField="Role.Name" HeaderText="Role" />
                </columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
