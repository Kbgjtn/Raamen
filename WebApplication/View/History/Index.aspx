<%@ Page Title="" Language="C#" MasterPageFile="~/View/Index.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WebApplication.View.History.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="GridViewTransactionHistoryList" runat="server" AutoGenerateColumns="false" DataKeyNames="Id" OnRowCommand="GridViewTransactionHistoryList_RowCommand" >
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Transaction ID" Visible="true"/>
                <asp:BoundField DataField="CustomerId" HeaderText="Customer Id" />
                <asp:BoundField DataField="Date" HeaderText="Date" />
                <asp:ButtonField ButtonType="Button" Text="See Detail" HeaderText="Action" CommandName="SeeDetail" />
            </Columns>
            <EmptyDataRowStyle CssClass="empty-data-row" />
        </asp:GridView>
        <asp:Label ID="LblNoRecords" runat="server" Visible="false" Text="Status: No records for order transactions found yet!" CssClass="empty-data-message"></asp:Label>
</asp:Content>
