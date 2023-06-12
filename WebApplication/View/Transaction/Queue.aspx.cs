using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication.Controllers;
using WebApplication.Model;

namespace WebApplication.View.Transaction
{
    public partial class Queue : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadUnhandledTransactionData();
            }
        }

        protected void LoadUnhandledTransactionData()
        {
            List<Header> data = TransactionController.GetHeaders(0);
            
            if (data.Count <= 0 || data == null)
            {
                LblNoRecords.Visible = true;
            }

            GridViewUnhandledTransactionList.DataSource = data;
            GridViewUnhandledTransactionList.DataBind();
        }

        protected void GridViewUnhandledTransactionList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("HandleTransaction"))
            {
                var userId = int.Parse(Request.Cookies["uid"].Value);
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewUnhandledTransactionList.Rows[rowIndex];
                int headerId = Convert.ToInt32(GridViewUnhandledTransactionList.DataKeys[rowIndex].Value);
                TransactionController.UpdateTransaction(headerId, userId);
                LoadUnhandledTransactionData();
                LabelInfo.Visible = true;
                LabelInfo.Text = "Status: Transaction ID: " + headerId + " successfuly handled!";
            }
        }
    }
}