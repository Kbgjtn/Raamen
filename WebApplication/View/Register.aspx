<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="WebApplication.View.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Register your account!</h1>
        </div>
        <div>
            <asp:Label ID="Label" runat="server" Text="Username"></asp:Label><br/>
            <asp:Label ID="labelUsernameError" runat="server" Text="The username must be 5 to 10 alphabetic characters of length."></asp:Label>
            <br/>
            <asp:TextBox ID="username" runat="server" onCheckedChanged="usernameInput_CheckedChanged" Checked="true" AutoPostBack="true"></asp:TextBox>
        </div>

        <div>
            <asp:Label ID="labelEmail" runat="server" Text="Email*" ></asp:Label>
            <br/>
            <asp:Label ID="labelEmailError" runat="server" Text="The email address must be using '.com'!"></asp:Label>
            <br/>
            <asp:TextBox ID="emailTextBox" runat="server"></asp:TextBox>
        </div>

        <div>
             <asp:Label ID="genderLabel" runat="server" Text="Gender"></asp:Label><br />
             <asp:RadioButton id="RadioButtonMan" Text="Man" Checked="false" GroupName="RadioGroupGender" runat="server" /><br />
             <asp:RadioButton id="RadioButtonWoman" Text="Woman" Checked="false" GroupName="RadioGroupGender" runat="server" /><br />
        </div>

        <div>
             <asp:Label ID="Label1" runat="server" Text="Register as: "></asp:Label><br />
             <asp:RadioButton id="RadioButtonCustomer" Text="Customer" Checked="true" GroupName="RadioGroupRole" runat="server" /><br />
             <asp:RadioButton id="RadioButtonStaff" Text="Staff" Checked="false" GroupName="RadioGroupRole" runat="server" /><br />
        </div>

        <div>
            <asp:Label ID="Label3" runat="server" Text="Password"></asp:Label>
            <br/>
            <asp:Label ID="labelPasswordError" runat="server" Text="password is required!"></asp:Label>
            <br/>
            <asp:TextBox ID="password" runat="server" TextMode="Password"></asp:TextBox>
        </div>

        <div>
            <asp:Label ID="Label4" runat="server" Text="Confirm Password"></asp:Label>
            <br/>
            <asp:Label ID="labelConfirmPassword" runat="server" Text="password must match!"></asp:Label>
            <br/>
            <asp:TextBox ID="confirmPassword" runat="server" TextMode="Password"></asp:TextBox>
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
    </form>
</body>
</html>
