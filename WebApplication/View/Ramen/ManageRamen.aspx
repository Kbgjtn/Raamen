<%@ Page Title="" Language="C#" MasterPageFile="~/View/Index.Master" AutoEventWireup="true" CodeBehind="ManageRamen.aspx.cs" Inherits="WebApplication.View.Ramen.ManageRamen" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div>
            <h1>Manage Ramen Page</h1> 
        </div>
        <div>
            <div>
                <h1>List Ramen</h1><br />
                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            </div>
            <asp:GridView ID="GridViewRamen" runat="server" AutoGenerateColumns="false" OnRowDeleting="GridViewRamen_RowDeleting" DataKeyNames="Id" OnRowUpdating="GridViewRamen_RowUpdating">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="ID" />
                    <asp:BoundField DataField="Name" HeaderText="Name" />
                    <asp:BoundField DataField="Borth" HeaderText="Broth" />
                    <asp:BoundField DataField="Price" HeaderText="Price" />
                    <asp:BoundField DataField="Meat.Name" HeaderText="Meat" />
                    <asp:ButtonField ButtonType="Button" Text="Update" CommandName="Update" />
                    <asp:ButtonField ButtonType="Button" Text="Delete" CommandName="Delete" />
                </Columns>
                <EmptyDataRowStyle CssClass="empty-data-row" />
            </asp:GridView>
            <asp:Label ID="LblNoRecords" runat="server" Visible="false" Text="No records found." CssClass="empty-data-message"></asp:Label>

            <div>
                <p>Create or Add new Ramen here:</p>
                <asp:Button ID="ButtonInsertRamen" runat="server" Text="Add Ramen" OnClick="ButtonInsertRamen_Click" />
            </div>
        </div>
    </div>
</asp:Content>
