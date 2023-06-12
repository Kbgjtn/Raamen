<%@ Page Title="" Language="C#" MasterPageFile="~/View/Index.Master" AutoEventWireup="true" CodeBehind="Detail.aspx.cs" Inherits="WebApplication.View.History.Detail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>Detail Transaction ID: 
            <asp:Label ID="LabelHeaderIdHistory" runat="server" Text=""></asp:Label>
            <asp:PlaceHolder ID="GoBackPlaceholder" runat="server"></asp:PlaceHolder>
            
        </h1>
    </div>
    <div>
        <asp:Label ID="Label1GoBackPlaceholder" runat="server" Text=""></asp:Label>
    </div>
    <div>
         <asp:GridView ID="GridViewDetailTransactionHistoryList" runat="server" AutoGenerateColumns="false" DataKeyNames="Id" >
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="ID" Visible="false"/>
                <asp:BoundField DataField="Name" HeaderText="Name" />
                <asp:BoundField DataField="Borth" HeaderText="Broth" />
                <asp:BoundField DataField="Price" HeaderText="Price" />
                <asp:BoundField DataField="Meat.Name" HeaderText="Meat" />
            </Columns>
            <EmptyDataRowStyle CssClass="empty-data-row" />
        </asp:GridView>
        <asp:Label ID="LblNoRecords" runat="server" Visible="false" Text="Cannot load the records of your transaction found." CssClass="empty-data-message"></asp:Label>
    </div>
</asp:Content>
