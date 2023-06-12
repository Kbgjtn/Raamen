<%@ Page Title="" Language="C#" MasterPageFile="~/View/Index.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WebApplication.View.Ramen.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div>
        <h1>
            Ramen Menu
        </h1> 
        <asp:Label ID="LabelOrderLastUpdate" runat="server" Text=""></asp:Label><br />
        
        <asp:PlaceHolder ID="CartRamenPlaceholder" runat="server"></asp:PlaceHolder>
        <br />
    </div>
    <div>
        <p><asp:Label ID="LabelRamenInfo" runat="server" Text="Info: "></asp:Label></p><br />
        <h4>
            <asp:HyperLink ID="HyperLinkGoToCart" href="/View/Transaction/Cart.aspx" Visible="false" runat="server">See Cart!</asp:HyperLink>
        </h4>
    </div>
    <div>
        <asp:GridView ID="GridViewRamenList" runat="server" AutoGenerateColumns="false" DataKeyNames="Id" OnRowCommand="GridViewRamenList_RowCommand">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="ID" Visible="false"/>
                <asp:BoundField DataField="Name" HeaderText="Name" />
                <asp:BoundField DataField="Borth" HeaderText="Broth" />
                <asp:BoundField DataField="Price" HeaderText="Price" />
                <asp:BoundField DataField="Meat.Name" HeaderText="Meat" />
                <asp:ButtonField ButtonType="Button" Text="Add to Cart" CommandName="AddToCart" />
            </Columns>
            <EmptyDataRowStyle CssClass="empty-data-row" />
        </asp:GridView>
        <asp:Label ID="LblNoRecords" runat="server" Visible="false" Text="No records found." CssClass="empty-data-message"></asp:Label>
    </div>
</asp:Content>
