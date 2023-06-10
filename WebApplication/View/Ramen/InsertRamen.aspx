<%@ Page Title="" Language="C#" MasterPageFile="~/View/Index.Master" AutoEventWireup="true" CodeBehind="InsertRamen.aspx.cs" Inherits="WebApplication.View.Ramen.InsertRamen" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>Add New Ramen</h1> 
        <p>Please, Fields the form bellow!</p>
        <asp:Label ID="LabelInfoCreateRamen" runat="server" Text=""></asp:Label>
        <asp:PlaceHolder ID="DetailsPlaceholder" runat="server"></asp:PlaceHolder><br /><br />
    </div>
    <div>
        <div>
            <asp:Label ID="LabelRamenName" runat="server" Text="Ramen Name: "></asp:Label>
            <asp:TextBox ID="TextBoxRamenName" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="LabelRamenBroth" runat="server" Text="Ramen Broth: "></asp:Label>
            <asp:TextBox ID="TextBoxRamenBrothName" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="LabelRamenMeatName" runat="server" Text="Ramen Meat: "></asp:Label>
            <asp:TextBox ID="TextBoxRamenMeatName" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="LabelRamenPrice" runat="server" Text="Ramen Price: "></asp:Label>
            <asp:TextBox ID="TextBoxRamenPrice" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="ButtonCreateRamen" runat="server" Text="Create" OnClick="ButtonCreateRamen_Click" />
        </div>
    </div>
</asp:Content>
