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
    public partial class ManageRamen : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
                GridViewRamen.DataSource = ramens;
                GridViewRamen.DataBind();
            }
            else
            {
                GridViewRamen.Visible = false;
                LblNoRecords.Visible = true;
            }
        }

        protected void GridViewRamen_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Update")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewRamen.Rows[rowIndex];
                int ramenId = Convert.ToInt32(row.Cells[0].Text);
                Response.Redirect($"UpdateRamen.aspx?RamenId={ramenId}");
            }
        }

        protected void ButtonInsertRamen_Click(object sender, EventArgs e)
        {
            Response.Redirect("/View/Ramen/InsertRamen.aspx");
        }

        protected void GridViewRamen_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridViewRamen.Rows[e.RowIndex];
            int ramenId = Convert.ToInt32(row.Cells[0].Text);
            string ramenName = row.Cells[1].Text;
            Response.Redirect($"UpdateRamen.aspx?RamenId={ramenId}&RamenName={ramenName}");
        }

        protected void GridViewRamen_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int ramenId = Convert.ToInt32(GridViewRamen.DataKeys[e.RowIndex].Value);
            bool isDeletedRamen = RamenController.DeleteRamen(ramenId);

            if (isDeletedRamen != false)
            {
                Label1.Text = "Ramen with ID: " + ramenId + " successfuly deleted!";
                BindRamenData(); return;
            }
            else
            {
                Label1.Text = "Ramen with ID: " + ramenId + " cannot be deleted!";
                Label2.Text = "Warn: You cannot remove the the items which related to the transaction order!";
                BindRamenData(); return;
            }
        }
    }
}