<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication.View.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link href="../Styles/Styles.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-page">
            <div>
                <h1>Login to your account!</h1>
            </div>
            <div class="textInput">
                <asp:Label ID="Label1" runat="server" Text="Username: "></asp:Label>
                <br />
                <asp:TextBox ID="TextBoxUsername" runat="server"></asp:TextBox>
            </div>

             <div class="textInput">
                <asp:Label ID="Label2" runat="server" Text="Password: "></asp:Label>
                 <br />
                <asp:TextBox ID="TextBoxPassword" runat="server" TextMode="Password"></asp:TextBox>
            </div>

            <div class="textInput">
                <asp:CheckBox ID="RememberMeCheckBox" Checked="true" runat="server" Text="Remember Me"></asp:CheckBox>
            </div>

            <div>
                <asp:Label ID="errTxt" runat="server" Text=""></asp:Label>
            </div>

            <div>
                <asp:Button ID="ButtonLogin" runat="server" Text="Login" OnClick="ButtonLogin_Click1" />
            </div>
            <div>
                <p>Dont have account?</p> 
                <asp:HyperLink ID="HyperLinkRegister" href="/View/Register.aspx"  runat="server">Register Here!</asp:HyperLink>
            </div>
        </div>
    </form>
</body>
</html>