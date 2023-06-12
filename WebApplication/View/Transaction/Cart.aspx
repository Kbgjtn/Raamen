<%@ Page Title="Cart" Language="C#" MasterPageFile="~/View/Index.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="WebApplication.View.Transaction.Cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>
            Cart
        </h1> 
        <asp:Label ID="LabelCartLastUpdate" runat="server" Text=""></asp:Label><br />
        <asp:Label ID="LabelCartInfo" runat="server" Text="Info: "></asp:Label><br />
        <asp:PlaceHolder ID="OrderRamenPlaceholder" runat="server"></asp:PlaceHolder>
        <br />
    </div>
    <div>
        <div>
            <h4>
                <asp:HyperLink ID="HyperLinkBackToMenu" Visible="false" href="/View/Ramen/Index.aspx" runat="server">Back to menu!</asp:HyperLink>
            </h4>
        </div>
        <asp:GridView ID="GridViewCart" runat="server" AutoGenerateColumns="false" OnRowCommand="GridViewCart_RowCommand" OnRowDataBound="GridViewCart_RowDataBound" OnRowDeleting="GridViewCart_RowDeleting" OnSelectedIndexChanged="GridViewCart_SelectedIndexChanged">
            <Columns>
                <asp:TemplateField HeaderText="ID" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblId" runat="server" Text='<%# Eval("Ramen.Id") %>' Visible="false" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Ramen.Name" HeaderText="Name" />
                <asp:BoundField DataField="Ramen.Borth" HeaderText="Broth" />
                <asp:BoundField DataField="Ramen.Price" HeaderText="Price (Rp)" />
                <asp:BoundField DataField="Ramen.Meat.Name" HeaderText="Meat" />
                <asp:TemplateField HeaderText="Quantity">
                    <ItemTemplate>
                        <asp:Button ID="btnIncreaseQuantity" runat="server" Text="+" CssClass="quantity-button" CommandName="IncreaseQuantity" CommandArgument='<%# Eval("Ramen.Id") %>' OnCommand="btnQuantity_Command" style="padding: 5px 10px;"/>
                        <asp:TextBox ID="txtQuantityItem" runat="server" ReadOnly="true" Text='<%# Eval("Quantity") %>' style="width: 30px; padding: 5px; text-align: center;"/>
                        <asp:Button ID="btnDecreaseQuantity" runat="server" Text="-" CssClass="quantity-button" CommandName="DecreaseQuantity" CommandArgument='<%# Eval("Ramen.Id") %>' OnCommand="btnQuantity_Command" style="padding: 5px 10px;" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                        <asp:Button ID="btnClear" runat="server" Text="Clear" CommandName="ClearFromCart" CommandArgument='<%# Eval("Ramen.Id") %>' OnCommand="btnClear_Command" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataRowStyle CssClass="empty-data-row" />
        </asp:GridView>
        <asp:Label ID="LblNoRecords" runat="server" Visible="false" Text="No records found." CssClass="empty-data-message"></asp:Label>
    </div>
    <div>
        <p>
            <asp:Label ID="LabelCartTotal" runat="server" Visible="false" Text=""></asp:Label>
        </p>

        <asp:Button ID="ButtonOrderCart" runat="server" Text="Order Ramen" Enabled="false" OnClick="ButtonOrderCart_Click" />
    </div>
</asp:Content>
