using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication.Controllers;
using WebApplication.Model;

namespace WebApplication.View.Staff
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCustomerData();
            }
        }

        private void LoadCustomerData()
        {

            List<User> customers = UserController.GetAllUserByRole("Customer");

            GridViewCustomers.DataSource = customers;
            GridViewCustomers.DataBind();
        }
    }
}