<%@ Page Title="" Language="C#" MasterPageFile="~/View/Index.Master" AutoEventWireup="true" CodeBehind="ManageRamen.aspx.cs" Inherits="WebApplication.View.Ramen.ManageRamen" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="manage-ramen-page">
        <div>
            <h1>Manage Ramen Page</h1> 
        </div>
        <div class="box-view-ramen">
            <div>
                <h1>List Ramen</h1>
                <asp:Label ID="status" runat="server" Text="Status: "></asp:Label>
                <asp:Label ID="Label1" runat="server" Text=""></asp:Label><br />
                <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
            </div>
            <asp:GridView CssClass="ramenGV" ID="GridViewRamen" runat="server" AutoGenerateColumns="false" OnRowDeleting="GridViewRamen_RowDeleting" DataKeyNames="Id" OnRowUpdating="GridViewRamen_RowUpdating">
                <Columns>
                    <asp:BoundField HeaderStyle-CssClass="header-short-GV" DataField="Id" HeaderText="ID" />
                    <asp:BoundField HeaderStyle-CssClass="header-long-GV" ItemStyle-CssClass="item-GV" DataField="Name" HeaderText="Name" />
                    <asp:BoundField HeaderStyle-CssClass="header-medium-GV" ItemStyle-CssClass="item-GV" DataField="Borth" HeaderText="Broth" />
                    <asp:BoundField HeaderStyle-CssClass="header-medium-GV" ItemStyle-CssClass="item-GV" DataField="Price" HeaderText="Price" />
                    <asp:BoundField HeaderStyle-CssClass="header-medium-GV" ItemStyle-CssClass="item-GV" DataField="Meat.Name" HeaderText="Meat" />
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
