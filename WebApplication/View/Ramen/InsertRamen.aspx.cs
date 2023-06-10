using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication.Controllers;

namespace WebApplication.View.Ramen
{
    public partial class InsertRamen : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            var uid = Request.Cookies["uid"];
            var role = Request.Cookies["rid"];

            if (uid == null && role == null)
            {
                Response.Redirect("/View/Login.aspx");
                return;
            }

            if (uid.Value != null && role.Value.Equals("Customer"))
            {
                Response.Redirect("/View/Home.aspx");
            }
        }

        protected void ButtonCreateRamen_Click(object sender, EventArgs e)
        {
            string name = TextBoxRamenName.Text;
            string broth = TextBoxRamenBrothName.Text;
            string meat = TextBoxRamenMeatName.Text;
            string price = TextBoxRamenPrice.Text;

            RamenController.InsertRamen(name, meat, broth, price);


            TextBoxRamenName.Text = "";
            TextBoxRamenBrothName.Text = "";
            TextBoxRamenMeatName.Text = "";
            TextBoxRamenPrice.Text = "";

            LabelInfoCreateRamen.Text = "Info: Successfuly add new ramen!";
            HyperLink link = new HyperLink();
            link.Text = "See Details here!";
            link.NavigateUrl = "ManageRamen.aspx";
            DetailsPlaceholder.Controls.Add(link);
        }
    }
}