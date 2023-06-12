<%@ Page Title="" Language="C#" MasterPageFile="~/View/Index.Master" AutoEventWireup="true" CodeBehind="InsertRamen.aspx.cs" Inherits="WebApplication.View.Ramen.InsertRamen" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
        <h1>Add New Ramen</h1> 
        <p>Please, Fields the form bellow!</p>
        <asp:Label ID="infoStatus" runat="server" Text="Status: "></asp:Label>
        <asp:Label ID="LabelInfoCreateRamen" runat="server" Text=""></asp:Label>
        <asp:PlaceHolder ID="DetailsPlaceholder" runat="server"></asp:PlaceHolder><br /><br />
    </div>

    <%--<div>


        <asp:Label ID="lblName" runat="server" Text="Ramen Name: "></asp:Label>
        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
        <br />

        <asp:Label ID="lblBroth" runat="server" Text="Broth Type: "></asp:Label>
        <asp:TextBox ID="txtBroth" runat="server"></asp:TextBox>
        <br />
            
        <asp:Label ID="lblPrice" runat="server" Text="Price: "></asp:Label>
        <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
        <br />

        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
        <br />
        <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" />
        <br />
        <asp:Label ID="lblStatus" runat="server" Text="[status]"></asp:Label>
    </div>--%>


    <div>
        <div>
            <asp:Label ID="LabelRamenName" runat="server" Text="Ramen Name: "></asp:Label>
            <asp:TextBox ID="TextBoxRamenName" runat="server"></asp:TextBox>
        </div>

        <div>
            <asp:Label ID="lblMeatId" runat="server" Text="Meat: "></asp:Label>
            <asp:DropDownList ID="ddlMeatId" runat="server"></asp:DropDownList>
            <asp:Label ID="debug" runat="server" Text="debug: "></asp:Label>
        </div>

        <div>
            <asp:Label ID="LabelRamenBroth" runat="server" Text="Ramen Broth: "></asp:Label>
            <asp:TextBox ID="TextBoxRamenBrothName" runat="server"></asp:TextBox>
        </div>

        <div>
            <asp:Label ID="LabelRamenPrice" runat="server" Text="Ramen Price: "></asp:Label>
            <asp:TextBox ID="TextBoxRamenPrice" runat="server"></asp:TextBox>
        </div>

        <div>
            <asp:Button ID="ButtonCreateRamen" runat="server" Text="Create" OnClick="ButtonCreateRamen_Click" />
        </div>

        <div>
            <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" />
        </div>
    </div>
</asp:Content>
