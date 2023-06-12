<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="WebApplication.View.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register</title>
    <link href="../Styles/Styles.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">

        <div class="register-page">
            <div>
                <h1>Register your account!</h1>
            </div>

            <div class="box-register">
                <asp:Label ID="Label" runat="server" Text="Username"></asp:Label>
                <br/>
                <asp:TextBox ID="username" runat="server" onCheckedChanged="usernameInput_CheckedChanged" Checked="true"></asp:TextBox>
                <br/>
                <asp:Label CssClass="thin-error" ID="labelUsernameError" runat="server" Text=""></asp:Label>
            </div>

            <div class="box-register">
                <asp:Label ID="labelEmail" runat="server" Text="Email*" ></asp:Label>
                <br/>
                <asp:TextBox ID="emailTextBox" runat="server"></asp:TextBox>
                <br/>
                <asp:Label CssClass="thin-error" ID="labelEmailError" runat="server" Text=""></asp:Label>
            </div>

            <div class="box-register">
                 <asp:Label ID="genderLabel" runat="server" Text="Gender"></asp:Label><br />
                 <asp:RadioButton id="RadioButtonMan" Text="Man" Checked="false" GroupName="RadioGroupGender" runat="server" />
                 <asp:RadioButton id="RadioButtonWoman" Text="Woman" Checked="false" GroupName="RadioGroupGender" runat="server" />
            </div>

            <div class="box-register">
                 <asp:Label ID="Label1" runat="server" Text="Register as: "></asp:Label><br />
                 <asp:RadioButton id="RadioButtonCustomer" Text="Customer" Checked="true" GroupName="RadioGroupRole" runat="server" />
                 <asp:RadioButton id="RadioButtonStaff" Text="Staff" Checked="false" GroupName="RadioGroupRole" runat="server" />
            </div>

            <div class="box-register">
                <asp:Label ID="Label3" runat="server" Text="Password"></asp:Label>
                <br/>
                <asp:TextBox ID="password" runat="server" TextMode="Password"></asp:TextBox>
                <br/>
                <asp:Label CssClass="thin-error" ID="labelPasswordError" runat="server" Text=""></asp:Label>
            </div>

            <div class="box-register">
                <asp:Label ID="Label4" runat="server" Text="Confirm Password"></asp:Label>
                <br/>
                <asp:TextBox ID="confirmPassword" runat="server" TextMode="Password"></asp:TextBox>
                <br/>
                <asp:Label CssClass="thin-error" ID="labelConfirmPassword" runat="server" Text=""></asp:Label>
            </div>

            <div>
                <asp:Button ID="handleRegister" runat="server" Text="Register" OnClick="handleRegister_Click" />
            </div>

            <br />
            <asp:Label ID="labelOutput" runat="server" Text="Info: "></asp:Label>

            <div>
                <p>Already have account?</p> 
                <asp:HyperLink ID="HyperLinkLogin" href="/View/Login.aspx"  runat="server">Login Now!</asp:HyperLink>
            </div>
        </div>
    </form>
</body>
</html>
