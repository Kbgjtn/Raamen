<%@ Page Title="" Language="C#" MasterPageFile="~/View/Index.Master" AutoEventWireup="true" CodeBehind="Queue.aspx.cs" Inherits="WebApplication.View.Transaction.Queue" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>Transaction Queue</h1>
    </div>
    <div>
        <h4>
            <asp:Label ID="LabelInfo" runat="server" Visible="false" Text="Status: " CssClass="empty-data-message"></asp:Label>
        </h4>
    </div>
    <div>
        <asp:GridView ID="GridViewUnhandledTransactionList" runat="server" AutoGenerateColumns="false" DataKeyNames="Id" OnRowCommand="GridViewUnhandledTransactionList_RowCommand" >
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Transaction ID" Visible="true"/>
                <asp:BoundField DataField="CustomerId" HeaderText="Customer Id" />
                <asp:BoundField DataField="Date" HeaderText="Date" />
                <asp:ButtonField ButtonType="Button" Text="Handle Transaction" HeaderText="Action" CommandName="HandleTransaction" />
            </Columns>
            <EmptyDataRowStyle CssClass="empty-data-row" />
        </asp:GridView>
        <asp:Label ID="LblNoRecords" runat="server" Visible="false" Text="Status: No records for unhandled transactions found! GOOD JOB!" CssClass="empty-data-message"></asp:Label>
    </div>
</asp:Content>
