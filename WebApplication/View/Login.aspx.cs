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
                if (!String.IsNullOrEmpty(uid.Value))
                {
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

                if (isSetCookies)
                {
                    HttpCookie uidCookie = new HttpCookie("uid", userloggedIn.Id.ToString());
                    uidCookie.Expires = DateTime.Now.AddHours(24);
                    HttpCookie roleCookie = new HttpCookie("rid", userloggedIn.Role.Name);
                    roleCookie.Expires = DateTime.Now.AddHours(24);
                    Response.SetCookie(uidCookie);
                    Response.SetCookie(roleCookie);
                }else
                {
                    StoreSession(userloggedIn.Id);
                }

                Response.Redirect("/View/Home.aspx");
            } else
            {
                if (username.Equals(""))
                {
                    errTxt.Text = "username must be filled";
                }
                else if (password.Equals(""))
                {
                    errTxt.Text = "password must be filled";
                } else
                {
                    errTxt.Text = "user not found!";
                }
            }
        }

        protected void StoreSession(int userId)
        {
            HttpContext.Current.Session["uid"] = userId;
        }
    }
}