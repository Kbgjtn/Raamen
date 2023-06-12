using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication.Controllers;
using WebApplication.Model;

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
                Response.Redirect("~/View/Login.aspx");
                return;
            }

            if (uid.Value != null && role.Value.Equals("Customer"))
            {
                Response.Redirect("~/View/Home.aspx");
            }

            //getMeat();

            if (!IsPostBack)
            {
                getMeat();
            }

        }

        protected void ButtonCreateRamen_Click(object sender, EventArgs e)
        {
            string name = TextBoxRamenName.Text;
            string meatId = ddlMeatId.Text;
            string broth = TextBoxRamenBrothName.Text;
            //string meat = TextBoxRamenMeatName.Text;
            string price = TextBoxRamenPrice.Text;

            //lblMeatId.Text = meatId;

            LabelInfoCreateRamen.Text = RamenController.InsertRamen(name, meatId, broth, price);

            if (LabelInfoCreateRamen.Text.Contains("success"))
            {
                TextBoxRamenName.Text = "";
                TextBoxRamenBrothName.Text = "";
                TextBoxRamenPrice.Text = "";                

                HyperLink link = new HyperLink();
                link.Text = "See Details here!";
                link.NavigateUrl = "ManageRamen.aspx";
                DetailsPlaceholder.Controls.Add(link);
            }

            //LabelInfoCreateRamen.Text = "Successfuly add new ramen!";
        }

        protected void getMeat()
        {
            List<Meat> dataMeat = RamenController.GetAllMeat();

            foreach (Meat item in dataMeat)
            {
                ddlMeatId.Items.Add(new ListItem(item.Name, item.Id.ToString()));
            }

            //ddlMeatId.DataSource = dataMeat;
            //ddlMeatId.DataTextField = "Name";
            //ddlMeatId.DataValueField = "Id";
            //ddlMeatId.DataBind();
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/Ramen/ManageRamen.aspx");
        }
    }
}