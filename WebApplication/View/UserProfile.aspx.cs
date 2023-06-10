using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication.Controllers;
using WebApplication.Model;
using WebApplication.Utills;

namespace WebApplication.View
{
    public partial class UserProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var uid = Request.Cookies["uid"];

            if (uid == null)
            {
                Response.Redirect("/View/Login.aspx");
            }


            int userId = int.Parse(uid.Value);
            User user = UserController.GetUserById(userId);

            LabelUserName.Text = "Hii, " + user.Username + "!";


            if (!IsPostBack)
            {
                TextBoxUserName.Text = user.Username;
                TextBoxEmail.Text = user.Email;
            }
        }

        protected void ButtonEditProfile_Click(object sender, EventArgs e)
        {
            TextBoxUserName.Enabled = true;
            TextBoxEmail.Enabled = true;

            RadioButtonWoman.Enabled = true;
            RadioButtonMan.Enabled = true;

            ButtonEditProfile.Visible = false;

            ButtonSaveProfile.Enabled = true;
            ButtonSaveProfile.Visible = true;
        }

        protected void ButtonSaveProfile_Click(object sender, EventArgs e)
        {
            string new_username = TextBoxUserName.Text;
            string new_email = TextBoxEmail.Text;
            string new_gender = UserValidator.CheckGender(RadioButtonMan.Checked, RadioButtonWoman.Checked);
            var uid = Request.Cookies["uid"];

            if (uid == null)
            {
                Response.Redirect("/Pages/Login.aspx");
            }

            int userId = int.Parse(uid.Value);

            bool isUpdated = UserController.Update(userId, new_username, new_email, new_gender);

            if (isUpdated == false)
            {
                LabelEditInfo.Text = "Info: Cannot updated your profile!";
                return;
            }
            else
            {
                LabelEditInfo.Text = "Info: Successfuly updated your profile!";
                HandleEditModeInput();
                return;
            }
        }

        protected void HandleEditModeInput()
        {
            TextBoxUserName.Enabled = !TextBoxUserName.Enabled;
            TextBoxEmail.Enabled = !TextBoxEmail.Enabled;

            RadioButtonWoman.Enabled = !RadioButtonWoman.Enabled;
            RadioButtonMan.Enabled = !RadioButtonMan.Enabled;

            ButtonEditProfile.Visible = !ButtonEditProfile.Visible;

            ButtonSaveProfile.Enabled = !ButtonSaveProfile.Enabled;
            ButtonSaveProfile.Visible = !ButtonSaveProfile.Visible;
        }

        protected void TextBoxUserName_TextChanged(object sender, EventArgs e)
        {
            string new_username = TextBoxUserName.Text;
        }

        protected void TextBoxEmail_TextChanged(object sender, EventArgs e)
        {
            string new_email = TextBoxUserName.Text;
        }
    }
}