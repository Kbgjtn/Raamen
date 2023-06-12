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
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LabelOrderLastUpdate.Text = "Last Update: " + DateTime.Now;
            LabelRamenInfo.Text = "Info: Order your ramen now!";

            if (!IsPostBack)
            {
                BindRamenData();
            }
        }

        protected void BindRamenData()
        {
            List<Raman> ramens = RamenController.GetAllRamen();

            if (ramens.Count > 0)
            {
                GridViewRamenList.DataSource = ramens;
                GridViewRamenList.DataBind();
                HyperLinkGoToCart.Visible = true;
            }
            else
            {
                GridViewRamenList.Visible = false;
                LblNoRecords.Visible = true;
                LblNoRecords.Text = "Info: Sorry, our ramen menu is not available at the moment. Please check regularly, thank you!";
            }
        }

        protected void GridViewRamenList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "AddToCart")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewRamenList.Rows[rowIndex];
                int itemId = Convert.ToInt32(GridViewRamenList.DataKeys[rowIndex].Value);
                string ramenName = row.Cells[1].Text;
                AddToCart(itemId, 1);
                LabelRamenInfo.Text = "Info: Order " + ramenName + " x (1)";
            }
        }

        protected void AddToCart(int ramenId, int quantity)
        {
            List<Detail> cartItems;

            if (Session["Cart"] != null)
            {
                cartItems = (List<Detail>)Session["Cart"];
            }
            else
            {
                cartItems = new List<Detail>();
            }

            Detail existingItem = cartItems.FirstOrDefault(item => item.RamenId == ramenId);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                cartItems.Add(new Detail { RamenId = ramenId, Quantity = quantity });
            }

            StoreCartToSesseion(cartItems);
        }

        private void StoreCartToSesseion(List<Detail> cart)
        {
            Session["Cart"] = cart;
        }

        protected void GridViewCart_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TextBox txtQuantityItem = (TextBox)e.Row.FindControl("txtQuantityItem");
                if (txtQuantityItem != null)
                {
                    int quantity = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Quantity"));
                    txtQuantityItem.Text = quantity.ToString();
                }
            }
        }
    }
}