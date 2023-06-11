<%@ Page Title="Profile" Language="C#" MasterPageFile="~/View/Index.Master" AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs" Inherits="WebApplication.View.UserProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="profile-page">
        <div>
            <h1 id="ProfileTitleWithName">
                <asp:Label ID="LabelUserName" runat="server" Text=""></asp:Label>
            
            </h1>
            <h2>
                <asp:Label ID="LabelUserRole" runat="server" Text=""></asp:Label>
            </h2>
        </div>

        <div>
            <div class="box-register">
                <asp:Label CssClass="label-info" ID="LabelEditInfo" runat="server" Text="User Information: "></asp:Label><br />
            </div>

            <div class="box-register">
                <asp:Label ID="IdLabelUsername" runat="server" Text="Username: "></asp:Label>
                <br />
                <asp:TextBox ID="TextBoxUserName" runat="server" Enabled="false" AutoCompleteType="Disabled" OnTextChanged="TextBoxUserName_TextChanged"></asp:TextBox>
            </div>

            <div class="box-register">
                <asp:Label ID="LabelEmail" runat="server" Text="Email: "></asp:Label>
                <br />
                <asp:TextBox ID="TextBoxEmail" runat="server" AutoCompleteType="Disabled" Enabled="false" OnTextChanged="TextBoxEmail_TextChanged"></asp:TextBox>
            </div>

            <div class="box-register">
                <asp:Label ID="Label" runat="server" Text="Gender: "></asp:Label>
                <asp:RadioButton id="RadioButtonMan" Text="Man" Checked="false" Enabled="false" GroupName="RadioGroupGender" runat="server" />
                <asp:RadioButton id="RadioButtonWoman" Text="Woman" Checked="false" Enabled="false"  GroupName="RadioGroupGender" runat="server" />
                <br />
            </div>

            <div class="box-register">
                <asp:Label ID="LabelPassword" runat="server" Visible="false" Text="Current Password: "></asp:Label>
                <br />
                <asp:TextBox ID="TextBoxPassword" runat="server" Visible="false" TextMode="Password" AutoCompleteType="Disabled" Enabled="false" OnTextChanged="TextBoxPassword_TextChanged"></asp:TextBox>
            </div>

<%--            <div class="box-register">
                <asp:Label ID="LabelCoPassword" runat="server" Text="Confirm Password: "></asp:Label>
                <br />
                <asp:TextBox ID="TextBoxCoPassword" runat="server" AutoCompleteType="Disabled" Enabled="false" OnTextChanged="TextBoxCoPassword_TextChanged" AutoPostBack="true" ></asp:TextBox>
            </div>--%>

            <div>
                <asp:Button ID="ButtonEditProfile" runat="server" Text="Edit Profile" OnClick="ButtonEditProfile_Click" />
            </div>

            <div>
                <asp:Button ID="ButtonSaveProfile" runat="server" Text="Save Profile" OnClick="ButtonSaveProfile_Click" Enabled="false" Visible="false"/>
            </div>
        </div>
    </div>
</asp:Content>
