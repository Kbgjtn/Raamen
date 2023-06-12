<%@ Page Title="Home" Language="C#" MasterPageFile="~/View/Index.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="WebApplication.View.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div>
            <h4> Successfuly logged in! </h4>
        </div>

        <asp:GridView ID="GridViewCustomers" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="Username" HeaderText="Username" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:BoundField DataField="Gender" HeaderText="Gender" />
                <asp:BoundField DataField="Role.Name" HeaderText="Role" />
            </Columns>
        </asp:GridView>
        <div>
            <asp:Label ID="LblNoRecords" runat="server" Visible="false" Text="No users records found." CssClass="empty-data-message"></asp:Label>
        </div>
    </div>
</asp:Content>
