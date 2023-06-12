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
    public partial class Detail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string headerId = Request.QueryString["headerId"];
            LabelHeaderIdHistory.Text = headerId;
            

            if (headerId == null)
            {
                Label1GoBackPlaceholder.Text = "Header with ID: " + headerId + " is not valid!";
                HyperLink link = new HyperLink();
                link.Text = "Back to Transaction History!";
                link.NavigateUrl = "/View/History/Index.aspx";
                GoBackPlaceholder.Controls.Add(link);
                return;
            }

            if (!IsPostBack)
            {
                LoadHeaderTransactionDetail(int.Parse(headerId));
            }
        }
        protected void LoadHeaderTransactionDetail(int headerId)
        {
            Header data = TransactionController.GetHeaderById(headerId);
            List<Raman> ramenItems = new List<Raman>();
            if (data.Details.Count < 0 || data.Details == null)
            {
                LblNoRecords.Visible = true;
            }

            foreach(var item in data.Details)
            {
                ramenItems.Add(RamenController.GetRamen(item.RamenId));
            }

            GridViewDetailTransactionHistoryList.DataSource = ramenItems;
            GridViewDetailTransactionHistoryList.DataBind();
        }   
    }
}