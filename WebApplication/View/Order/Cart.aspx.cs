using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication.Controllers;
using WebApplication.Model;
using WebApplication.Utills;

namespace WebApplication.View.Order
{
    public partial class Cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LabelCartLastUpdate.Text = "Last Updated: " + DateTime.Now;
                BindCartData();
            }
        }



        protected void GridViewCart_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ClearFromCart")
            {
                int ramenId = Convert.ToInt32(e.CommandArgument);
                bool isDeletedRamenFromCart = RemoveFromCart(ramenId);

                if (isDeletedRamenFromCart)
                {
                    LabelCartInfo.Text = "Info: Ramen with ID: " + ramenId + " successfully deleted!";
                    BindCartData();
                }
                else
                {
                    LabelCartInfo.Text = "Info: Ramen with ID: " + ramenId + " cannot be deleted!";
                }
            }
        }
        protected void GridViewCart_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
        protected void BindCartData()
        {
            List<Detail> cartItems = (List<Detail>)Session["Cart"];
            List<CartItem> cartProductObj = new List<CartItem>(); ;

            if (cartItems != null && cartItems.Count > 0)
            {
                foreach (var detail in cartItems)
                {
                    Raman ramen = RamenController.GetRamen(detail.RamenId);
                    CartItem existingItem = cartProductObj.FirstOrDefault(item => item.Ramen.Id == ramen.Id);
                    if (existingItem != null)
                    {
                        existingItem.Quantity += detail.Quantity;
                    }
                    else
                    {
                        CartItem newCartItem = new CartItem
                        {
                            Ramen = ramen,
                            Quantity = detail.Quantity
                        };
                        cartProductObj.Add(newCartItem);
                    }
                }
            }
            else
            {
                LblNoRecords.Visible = false;
                LabelCartInfo.Text = "No Records found in your Cart!";
                HyperLink link = new HyperLink();
                link.Text = "Order ramen now!";
                link.NavigateUrl = "/View/Order/Index.aspx";
                OrderRamenPlaceholder.Controls.Add(link);
            }


            GridViewCart.DataSource = cartProductObj;
            GridViewCart.DataBind();
        }

        protected bool RemoveFromCart(int itemId)
        {
            List<Detail> cartItems = (List<Detail>)Session["Cart"];
            Detail itemToClear = cartItems.FirstOrDefault(item => item.RamenId == itemId);

            if (itemToClear != null)
            {
                cartItems.Remove(itemToClear);
                StoreCartToSesseion(cartItems);
                return true;
            }
            else
            {
                return false;
            }

        }

        private void StoreCartToSesseion(List<Detail> cart)
        {
            Session["Cart"] = cart;
        }


        protected void btnClear_Command(object sender, CommandEventArgs e)
        {
            GridViewRow row = ((Button)sender).NamingContainer as GridViewRow;
            int ramenId = Convert.ToInt32(e.CommandArgument);
            GridViewCart.DeleteRow(row.RowIndex);
            RemoveFromCart(ramenId);
            BindCartData();
        }

        protected void GridViewCart_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void GridViewCart_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridViewCart.Rows[e.RowIndex];
            int ramenId = Convert.ToInt32(((Label)row.FindControl("lblId")).Text);
            TextBox txtEditQuantityItem = (TextBox)row.FindControl("txtEditQuantityItem");
            int newQuantity = Convert.ToInt32(txtEditQuantityItem.Text);

            UpdateCartQuantity(ramenId, newQuantity);
            BindCartData();

            GridViewCart.EditIndex = -1;
            e.Cancel = true;
        }

        protected void UpdateCartQuantity(int ramenId, int new_quantity)
        {
            List<Detail> cartItems = (List<Detail>)Session["Cart"];
            Detail itemInCart = cartItems.FirstOrDefault(item => item.RamenId == ramenId);
            itemInCart.Quantity = new_quantity;
            StoreCartToSesseion(cartItems);
        }
    }
}