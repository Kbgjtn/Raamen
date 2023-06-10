using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication.Controllers;
using WebApplication.Utills;

namespace WebApplication.View
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            labelUsernameError.Text = UserValidator.RequiredInput(username.Text) ? "Username: cannot be empty!" : "Username: ok!";
            labelEmailError.Text = UserValidator.CheckIsEmailValid(emailTextBox.Text) ? "Email: ok!" : "Email: must be using domain '.com'";
            labelPasswordError.Text = UserValidator.RequiredInput(password.Text) ? "Password: cannot be empty!" : "Password: ok!";
            labelConfirmPassword.Text = UserValidator.CheckPasswordMatched(password.Text, confirmPassword.Text) ? "Password is match!" : "Password: must be match!";

            var uid = Request.Cookies["uid"];
            if (uid != null)
            {
                if (!String.IsNullOrEmpty(uid.Value))
                {
                    Response.Redirect("/View/Home.aspx");
                }
            }
        }

        protected void handleRegister_Click(object sender, EventArgs e)
        {
            string userName = username.Text;
            string email = emailTextBox.Text;
            string gender = UserValidator.CheckGender(RadioButtonMan.Checked, RadioButtonWoman.Checked);
            string password = confirmPassword.Text;
            string role = UserValidator.CheckUserRole(RadioButtonCustomer.Checked, RadioButtonStaff.Checked);

            if (UserValidator.CheckIsEmailValid(email) == false)
            {
                labelEmailError.Text = "Email: must be using domain '.com'";
                labelOutput.Text = "Info: email is must be using domain '.com'";
                return;
            }
            else
            {
                UserController.CreateUser(userName, email, gender, password, role);
                Response.Redirect("/View/Login.aspx");
            }
        }
    }
}