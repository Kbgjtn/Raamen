using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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

            var uid = Request.Cookies["uid"];
            var role = Request.Cookies["rid"];

            if (uid == null && role == null)
            {
                Response.Redirect("/View/Login.aspx");
                return;
            }

            if (uid.Value != null && role.Value.Equals("Customer"))
            {
                Response.Redirect("/View/Home.aspx");
            }


            if (!IsPostBack)
            {
                BindRamenData();
            }
        }

        // buat ambil data ramen untuk ditampilin
        protected void BindRamenData()
        {
            List<Raman> ramens = RamenController.GetAllRamen();

            // kalau ramen nya ada, tampilin semua data ramen
            if (ramens.Count > 0)
            {
                //GridViewRamen.DataSource = ramens;
                //GridViewRamen.DataBind();

                GridRamenGV.DataSource = ramens;
                GridRamenGV.DataBind();
            }
            else
            {
                // kalau ga ada, tampilin label no record nya aktifin
                //GridViewRamen.Visible = false;
                GridRamenGV.Visible = false;
                LblNoRecords.Visible = true;
            }
        }

        protected void GridRamenGV_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //if (e.CommandName == "Update")
            //{
            //    int rowIndex = Convert.ToInt32(e.CommandArgument);
            //    GridViewRow row = GridRamenGV.Rows[rowIndex];
            //    int ramenId = Convert.ToInt32(row.Cells[0].Text);

            //    Response.Redirect($"UpdateRamen.aspx?RamenId={ramenId}");
            //}
        }

        protected void ButtonInsertRamen_Click(object sender, EventArgs e)
        {
            Response.Redirect("/View/Ramen/InsertRamen.aspx");
        }

        //protected void GridViewRamen_RowUpdating(object sender, GridViewUpdateEventArgs e)
        //{
        //    GridViewRow row = GridViewRamen.Rows[e.RowIndex];
        //    int ramenId = Convert.ToInt32(row.Cells[0].Text);
        //    string ramenName = row.Cells[1].Text;
        //    Response.Redirect($"UpdateRamen.aspx?RamenId={ramenId}&RamenName={ramenName}");
        //}

        //protected void GridViewRamen_RowDeleting(object sender, GridViewDeleteEventArgs e)
        //{
        //    int ramenId = Convert.ToInt32(GridViewRamen.DataKeys[e.RowIndex].Value);
        //    bool isDeletedRamen = RamenController.DeleteRamen(ramenId);

        //    if (isDeletedRamen != false)
        //    {
        //        Label1.Text = "Ramen with ID: " + ramenId + " successfuly deleted!";
        //        BindRamenData(); return;
        //    }
        //    else
        //    {
        //        Label1.Text = "Ramen with ID: " + ramenId + " cannot be deleted!";
        //        BindRamenData(); return;
        //    }
        //}

        protected void GridRamenGV_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = GridRamenGV.Rows[e.RowIndex];

            int ramenId = int.Parse(row.Cells[0].Text.ToString());

            Label1.Text = RamenController.deleteRamen(ramenId);

            refreshBtn.Visible = true;

            
            //Label1.Text = "heihei";

            Response.Redirect("~/View/Ramen/ManageRamen.aspx");
        }

        protected void refreshBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/Ramen/ManageRamen.aspx");
        }

        protected void GridRamenGV_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridRamenGV.Rows[e.RowIndex];

            int ramenId = int.Parse(row.Cells[0].Text);
            string ramenName = row.Cells[1].Text;

            Response.Redirect($"UpdateRamen.aspx?RamenId={ramenId}&RamenName={ramenName}");
        }

        protected void GridRamenGV_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = GridRamenGV.Rows[e.NewEditIndex];

            int id = int.Parse(row.Cells[0].Text);
        }
    }
}