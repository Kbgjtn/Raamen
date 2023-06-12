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
            string password1 = confirmPassword.Text;
            string role = UserValidator.CheckUserRole(RadioButtonCustomer.Checked, RadioButtonStaff.Checked);

            labelUsernameError.Text = UserValidator.RequiredInput(userName) ? "Username: cannot be empty!" : "Username: ok!";
            labelEmailError.Text = UserValidator.CheckIsEmailValid(email) ? "Email: ok!" : "Email: must be using domain '.com'";
            labelPasswordError.Text = UserValidator.RequiredInput(password.Text) ? "Password: cannot be empty!" : "Password: ok!";
            labelConfirmPassword.Text = UserValidator.CheckPasswordMatched(password.Text, password1) ? "Password is match!" : "Password: must be match!";

            // buat check email udah terdaftar oleh orang lain atau belum
            string msg = UserValidator.CheckEmail(email);
            
            if(gender == null)
            {
                labelOutput.Text = "Gender: must be filled";
            } 
            else if (UserValidator.CheckIsEmailValid(email) == false)
            {
                labelEmailError.Text = "Email: must be using domain '.com'";
                labelOutput.Text = "Info: email is must be using domain '.com'";
                return;
            }
            else if (!UserValidator.RequiredInput(username.Text) && UserValidator.CheckIsEmailValid(emailTextBox.Text) && !UserValidator.RequiredInput(password.Text) && UserValidator.CheckPasswordMatched(password.Text, confirmPassword.Text) && gender != null)
            {
                UserController.CreateUser(userName, email, gender, password1, role);
                Response.Redirect("/View/Login.aspx");
            }
        }
    }
}