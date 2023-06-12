using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication.Controllers;
using WebApplication.Model;

namespace WebApplication.View.Ramen
{
    public partial class UpdateRamen : System.Web.UI.Page
    {
        //private int _ramenId;
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

            //int ramenId = int.Parse(Request.QueryString["RamenId"]);
            //string ramenName = Request.QueryString["RamenName"];

            //Raman item = RamenController.GetRamen(ramenId);

            //if (item == null)
            //{
            //    LabelRamenIdNotValid.Text = "Ramen with ID: " + ramenId + " is not valid!";
            //    HyperLink link = new HyperLink();
            //    link.Text = "Back to List!";
            //    link.NavigateUrl = "ManageRamen.aspx";
            //    PlaceHolderNoRamenRecord.Controls.Add(link);
            //    UpdateRamenContainer.Visible = false;
            //}

            if (!IsPostBack)
            {
                int ramenId = int.Parse(Request.QueryString["RamenId"]);
                string ramenName = Request.QueryString["RamenName"];
                // update label info sedang updating ramen apa
                LabelRamenNameToBeUpdate.Text = ramenName;

                //TextBoxRamenName.Text = item.Name;
                //ddlMeatId.Text = item.Meat.Name;
                //TextBoxRamenBrothName.Text = item.Borth;
                //TextBoxRamenPrice.Text = item.Price;

                LoadRamenData(ramenId);

                getMeat();
            }

            //if (ramenId == null)
            //{
            //    LabelRamenIdNotValid.Text = "Ramen with ID: " + ramenId + " is not valid!";
            //    HyperLink link = new HyperLink();
            //    link.Text = "Back to List!";
            //    link.NavigateUrl = "ManageRamen.aspx";
            //    PlaceHolderNoRamenRecord.Controls.Add(link);
            //    UpdateRamenContainer.Visible = false;
            //    return;
            //}

            //this._ramenId = int.Parse(ramenId);
            //if (!IsPostBack)
            //{
            //    LoadRamenData(int.Parse(ramenId));
            //    getMeat();
            //}
        }

        protected void LoadRamenData(int ramenId)
        {
            Raman item = RamenController.GetRamen(ramenId);
            if (item == null)
            {
                LabelRamenIdNotValid.Text = "Ramen with ID: " + ramenId + " is not valid!";
                HyperLink link = new HyperLink();
                link.Text = "Back to List!";
                link.NavigateUrl = "ManageRamen.aspx";
                PlaceHolderNoRamenRecord.Controls.Add(link);

                editForm();
            }
            else
            {
                TextBoxRamenName.Text = item.Name;
                ddlMeatId.Text = item.Meat.Name;
                TextBoxRamenBrothName.Text = item.Borth;
                TextBoxRamenPrice.Text = item.Price;
            }
        }

        protected void ButtonUpdateRamen_Click(object sender, EventArgs e)
        {
            int ramenId = int.Parse(Request.QueryString["RamenId"]);
            string name = TextBoxRamenName.Text;
            string meatId = ddlMeatId.Text;
            string broth = TextBoxRamenBrothName.Text;
            string price = TextBoxRamenPrice.Text;

            LabelRamenUpdateInfo.Text = RamenController.updateRamen(ramenId, name, meatId, broth, price);

            if (LabelRamenUpdateInfo.Text.Contains("success"))
            {
                TextBoxRamenName.Text = "";
                TextBoxRamenBrothName.Text = "";
                TextBoxRamenPrice.Text = "";

                HyperLink link = new HyperLink();
                link.Text = "See updated ramen!";
                link.NavigateUrl = "ManageRamen.aspx";
                PlaceHolderNoRamenRecord.Controls.Add(link);
            }

            //bool isRamenUpdated = RamenController.UpdateRamen(this._ramenId, name, broth, meat, price);
            //if (isRamenUpdated != false)
            //{
            //    LabelRamenUpdateInfo.Text = "Ramen with ID: " + this._ramenId + " successfuly updated!";
            //    HyperLink link = new HyperLink();
            //    link.Text = "See updated ramen!";
            //    link.NavigateUrl = "ManageRamen.aspx";
            //    PlaceHolderNoRamenRecord.Controls.Add(link);

            //}
            //else
            //{
            //    LabelRamenUpdateInfo.Text = "Ramen with ID: " + this._ramenId + " cannot be updated!";
            //}

            //TextBoxRamenName.Text = "";
            //TextBoxRamenBrothName.Text = "";
            //TextBoxRamenMeatName.Text = "";
            //TextBoxRamenPrice.Text = "";
        }

        protected void getMeat()
        {
            List<Meat> dataMeat = RamenController.GetAllMeat();

            foreach (Meat item in dataMeat)
            {
                ddlMeatId.Items.Add(new ListItem(item.Name, item.Id.ToString()));
            }
        }

        protected void editForm()
        {
            TextBoxRamenName.Enabled = false;
            ddlMeatId.Enabled = false;
            TextBoxRamenBrothName.Enabled = false;
            TextBoxRamenPrice.Enabled = false;

            ButtonUpdateRamen.Enabled = false;
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/Ramen/ManageRamen.aspx");
        }
    }
}