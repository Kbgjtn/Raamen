using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication.Controllers;
using WebApplication.Model;

namespace WebApplication.View.History
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int userId = int.Parse(Request.Cookies["uid"].Value);
            string userRole = Request.Cookies["rid"].Value;


            if(!IsPostBack)
            {
                LoadHistoryData(userRole, userId);
            }
        }


        protected void LoadHistoryData(string role, int userId)
        {
            List<Header> data;
            if (role.Equals("Customer"))
            {
                data = TransactionController.GetHeadersByCustomerId(userId);
            } else
            {
                data = TransactionController.GetHeaders();
            }

            GridViewTransactionHistoryList.DataSource = data;
            GridViewTransactionHistoryList.DataBind();
        }

        protected void GridViewTransactionHistoryList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("SeeDetail"))
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewTransactionHistoryList.Rows[rowIndex];
                int headerId = Convert.ToInt32(GridViewTransactionHistoryList.DataKeys[rowIndex].Value);
                Response.Redirect($"Detail.aspx?headerId={headerId}");
                
            }
        }
    }
}