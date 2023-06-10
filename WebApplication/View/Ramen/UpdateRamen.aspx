<%@ Page Title="" Language="C#" MasterPageFile="~/View/Index.Master" AutoEventWireup="true" CodeBehind="UpdateRamen.aspx.cs" Inherits="WebApplication.View.Ramen.UpdateRamen" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>
            Update  
            <asp:Label ID="LabelRamenNameToBeUpdate" runat="server" Text=""></asp:Label>
        </h1> 
        <p>Please, Fields the form bellow!</p>
        <asp:Label ID="LabelInfoCreateRamen" runat="server" Text=""></asp:Label>
        <asp:PlaceHolder ID="DetailsPlaceholder" runat="server"></asp:PlaceHolder>
    </div>
    <div>
         <asp:Label ID="LabelRamenIdNotValid" runat="server" Text=""></asp:Label>
        <asp:Label ID="LabelRamenUpdateInfo" runat="server" Text=""></asp:Label>
         <asp:PlaceHolder ID="PlaceHolderNoRamenRecord" runat="server"></asp:PlaceHolder><br /><br />
    </div>
    <div id="UpdateRamenContainer" runat="server">
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
        <br />
        <div>
            <asp:Button ID="ButtonUpdateRamen" runat="server" Text="Update Ramen" OnClick="ButtonUpdateRamen_Click"/>
        </div>
    </div>
</asp:Content>
