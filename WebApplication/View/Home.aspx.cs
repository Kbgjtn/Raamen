using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication.Controllers;
using WebApplication.Model;

namespace WebApplication.View
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var uid = Request.Cookies["uid"];
            var rid = Request.Cookies["rid"];
            if (uid == null && rid == null)
            {
                Response.Redirect("/View/Login.aspx");
            }

            if (!IsPostBack)
            {
                if (rid != null)
                {
                    if (rid.Value.Equals("Customer"))
                    {
                        return;
                    }

                    if (rid.Value.Equals("Staff"))
                    {
                        LoadUserData("Customer");
                        return;
                    }

                    if (rid.Value.Equals("Admin"))
                    {
                        LoadUserData("Staff");
                        return;
                    }

                }
            }
        }

        private void LoadUserData(string role)
        {
            List<User> users = UserController.GetAllUserByRole(role);

            if (users.Count > 0)
            {
                GridViewCustomers.DataSource = users;
                GridViewCustomers.DataBind();
            } else
            {
                if (role.Equals("Staff"))
                {
                    LblNoRecords.Text = "No staffs records found.";
                } else
                {
                    LblNoRecords.Text = "No users records found.";
                }
                
                LblNoRecords.Visible = true;
            }
        }
    }
}