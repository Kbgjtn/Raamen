using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication.Controllers;
using WebApplication.Model;
using WebApplication.Utills;

namespace WebApplication.View.Transaction
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
                link.NavigateUrl = "/View/Ramen/Index.aspx";
                OrderRamenPlaceholder.Controls.Add(link);
            }

            decimal totalCartTransaction = CalculateCartTotal(cartProductObj);

            if (totalCartTransaction > 0)
            {
                LabelCartTotal.Visible = true;
                LabelCartTotal.Text = "Total Transaction: " + totalCartTransaction;
                HyperLinkBackToMenu.Visible = true;
                ButtonOrderCart.Enabled = true;
            } else
            {
                ButtonOrderCart.Enabled = false;
                HyperLinkBackToMenu.Visible = false;
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
            // ...
        }

        protected decimal CalculateCartTotal(List<CartItem> cartProductObj)
        {
            decimal totalCartTransaction = 0;

            if (cartProductObj.Count > 0 && cartProductObj != null)
            {
                foreach (CartItem item in cartProductObj)
                {
                    if (!string.IsNullOrEmpty(item.Ramen.Price))
                    {
                        if (decimal.TryParse(item.Ramen.Price, out decimal price))
                        {
                            totalCartTransaction += price * item.Quantity;
                        }
                        else
                        {
                            // TODO: HANDLE ERROR PARSING
                        }
                    }
                }
            }

            return totalCartTransaction;
        }

        protected void btnQuantity_Command(object sender, CommandEventArgs e)
        {
            int ramenId = Convert.ToInt32(e.CommandArgument);
            List<Detail> cartItems = (List<Detail>)Session["Cart"];
            Detail itemInCart = cartItems.FirstOrDefault(item => item.RamenId == ramenId);

            if (itemInCart != null)
            {
                int currentQuantity = itemInCart.Quantity;

                if (e.CommandName == "IncreaseQuantity")
                {
                    itemInCart.Quantity = currentQuantity + 1;
                }
                else if (e.CommandName == "DecreaseQuantity")
                {
                    if (currentQuantity > 1)
                        itemInCart.Quantity = currentQuantity - 1;
                }

                StoreCartToSesseion(cartItems);
                BindCartData();
            }
        }

        protected void ButtonOrderCart_Click(object sender, EventArgs e)
        {
            List<Detail> cartItems = (List<Detail>)Session["Cart"];
            int customerId = int.Parse(Request.Cookies["uid"].Value);
            TransactionController.CreateTransactionHeader(customerId, cartItems);
            Session.Remove("Cart");

            BindCartData();
            LabelCartTotal.Visible = true;
            LabelCartTotal.Text = "Status: Your ramen order is being prepared, please wait! Thank you so much for shopping!";
            ButtonOrderCart.Visible = false;
        }

        protected void GridViewCart_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}