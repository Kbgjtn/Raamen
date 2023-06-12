using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication.Controllers;
using WebApplication.Model;

namespace WebApplication.View
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var uid = Request.Cookies["uid"];

            if (uid != null)
            {
                if (!String.IsNullOrEmpty(uid.Value)) {
                    Response.Redirect("/View/Home.aspx");
                }
            }
        }

        protected void ButtonLogin_Click1(object sender, EventArgs e)
        {
            string username = TextBoxUsername.Text;
            string password = TextBoxPassword.Text;

            

            User userloggedIn = UserController.Login(username, password);

            bool isSetCookies = RememberMeCheckBox.Checked;

            if (userloggedIn != null)
            {
                HttpCookie uidCookie = new HttpCookie("uid", userloggedIn.Id.ToString());
                HttpCookie roleCookie = new HttpCookie("rid", userloggedIn.Role.Name);

                if (isSetCookies)
                {
                    uidCookie.Expires = DateTime.Now.AddDays(1);
                    roleCookie.Expires = DateTime.Now.AddDays(1);
                    
                }else {
                    uidCookie.Expires = DateTime.Now.AddMinutes(30);
                    roleCookie.Expires = DateTime.Now.AddMinutes(30);
                }

                Response.SetCookie(uidCookie);
                Response.SetCookie(roleCookie);
                Response.Redirect("/View/Home.aspx");
            } else
            {
                errTxt.Text = "email or password is incorrect, please try again!";
            }
        }

    }
}