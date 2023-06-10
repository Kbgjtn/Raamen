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
            if (uid == null)
            {
                Response.Redirect("Login.aspx");
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
                        LoadCustomerData("Customer");
                        return;
                    }

                    if (rid.Value.Equals("Admin"))
                    {
                        LoadCustomerData("Staff");
                        return;
                    }

                }
            }
        }

        private void LoadCustomerData(string role)
        {
            List<User> customers = UserController.GetAllUserByRole(role);

            GridViewCustomers.DataSource = customers;
            GridViewCustomers.DataBind();
        }
    }
}