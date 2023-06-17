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
        private int _ramenId;
        protected void Page_Load(object sender, EventArgs e)
        {
            string ramenName = Request.QueryString["RamenName"];
            LabelRamenNameToBeUpdate.Text = ramenName;
            string ramenId = Request.QueryString["RamenId"];

            if (ramenId == null) {
                LabelRamenIdNotValid.Text = "Ramen with ID: " + ramenId + " is not valid!";
                HyperLink link = new HyperLink();
                link.Text = "Back to List!";
                link.NavigateUrl = "ManageRamen.aspx";
                PlaceHolderNoRamenRecord.Controls.Add(link);
                UpdateRamenContainer.Visible = false;
                return;
            }

            this._ramenId = int.Parse(ramenId);

            if (!IsPostBack) {
                LoadRamenData(int.Parse(ramenId));
            }
        }

        protected void LoadRamenData(int ramenId)
        {
            Raman ramen = RamenController.GetRamen(ramenId);
            if (ramen == null)
            {
                LabelRamenIdNotValid.Text = "Ramen with ID: " + ramenId + " is not valid!";
                HyperLink link = new HyperLink();
                link.Text = "Back to List!";
                link.NavigateUrl = "ManageRamen.aspx";
                PlaceHolderNoRamenRecord.Controls.Add(link);
            }
            else
            {
                TextBoxRamenName.Text = ramen.Name;
                TextBoxRamenBrothName.Text = ramen.Borth;
                TextBoxRamenMeatName.Text = ramen.Meat.Name;
                TextBoxRamenPrice.Text = ramen.Price;
            }
        }

        protected void ButtonUpdateRamen_Click(object sender, EventArgs e)
        {
            string name = TextBoxRamenName.Text;
            string broth = TextBoxRamenBrothName.Text;
            string meat = TextBoxRamenMeatName.Text;
            string price = TextBoxRamenPrice.Text;

            string isRamenUpdated = RamenController.UpdateRamen(this._ramenId, name, broth, meat, price);
            LabelRamenUpdateInfo.Text = isRamenUpdated;
            
            if (isRamenUpdated.Equals("success updated"))
            {
                HyperLink link = new HyperLink();
                link.Text = "See updated ramen!";
                link.NavigateUrl = "ManageRamen.aspx";
                PlaceHolderNoRamenRecord.Controls.Add(link);

                TextBoxRamenName.Text = "";
                TextBoxRamenBrothName.Text = "";
                TextBoxRamenMeatName.Text = "";
                TextBoxRamenPrice.Text = "";

            }

        }
    }
}