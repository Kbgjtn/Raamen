using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication.View
{
    public partial class Index : System.Web.UI.MasterPage
    {
        private Dictionary<string, string> customerMenu = new Dictionary<string, string> {
                { "Home", "Home.aspx" },
                { "Order Ramen", "/View/Order/Index.aspx"},
                { "History", "/View/History/Index.aspx" },
                { "Profile", "/View/UserProfile.aspx" }
            };

        private Dictionary<string, string> staffMenu = new Dictionary<string, string>
            {
                { "Home", "Home.aspx" },
                { "Manage Ramen", "/View/Ramen/ManageRamen.aspx"},
                { "Order Queue", "/View/Order/Queue.aspx" },
                { "Profile", "/View/UserProfile.aspx" }
            };

        private Dictionary<string, string> adminMenu = new Dictionary<string, string>
            {
                { "Home", "Home.aspx" },
                { "Manage Ramen", "/View/Ramen/ManageRamen.aspx"},
                { "Order Queue", "/View/Order/Queue.aspx" },
                { "History", "/View/History/Index.aspx" },
                { "Report", "/View/Report/Index.aspx" },
                { "Profile", "/View/UserProfile.aspx" }
            };

        private Dictionary<string, string> menuItems;
        protected void Page_Load(object sender, EventArgs e)
        {
            var uid = Request.Cookies["uid"];

            if (uid == null)
            {
                Response.Redirect("/View/Login.aspx");
            }


            var role = Request.Cookies["rid"];

            if (role != null)
            {
                LabelRole.Text = role.Value;
            }

            switch (role.Value)
            {
                case "Admin":
                    this.menuItems = this.adminMenu;
                    break;
                case "Customer":
                    this.menuItems = this.customerMenu;
                    break;
                case "Staff":
                    this.menuItems = this.staffMenu;
                    break;
                default:
                    this.menuItems = this.customerMenu;
                    break;
            }

            foreach (KeyValuePair<string, string> menuItem in menuItems)
            {
                HyperLink link = new HyperLink();
                link.Text = menuItem.Key;
                link.NavigateUrl = menuItem.Value;
                menuPlaceholder.Controls.Add(link);
                menuPlaceholder.Controls.Add(new LiteralControl(" | "));
            }
        }

        protected void ButtonLogout_Click(object sender, EventArgs e)
        {

            if (Request.Cookies["uid"] != null)
            {
                Response.Cookies["rid"].Expires = DateTime.Now.AddDays(-1);
                Response.Cookies["uid"].Expires = DateTime.Now.AddDays(-1);

                Response.Redirect("/View/Login.aspx");
            }
        }
    }
}