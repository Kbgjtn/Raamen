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

        private Dictionary<string, string> customerMenu = new Dictionary<string, string> 
        {
                { "Order Ramen", "/View/Ramen/Index.aspx"},
                { "History", "/View/History/Index.aspx" }
        };

        private Dictionary<string, string> staffMenu = new Dictionary<string, string>
        {
                { "Manage Ramen", "/View/Ramen/ManageRamen.aspx"},
                { "Order Queue", "/View/Transaction/Queue.aspx" }
        };

        private Dictionary<string, string> adminMenu = new Dictionary<string, string>
        {
                { "Manage Ramen", "/View/Ramen/ManageRamen.aspx"},
                { "Order Queue", "/View/Transaction/Queue.aspx" },
                { "History", "/View/History/Index.aspx" },
                { "Report", "/View/Report/Index.aspx" }
        };
        
        private Dictionary<string, List<string>> restrictedUrls = new Dictionary<string, List<string>>
        {
            { "/View/Ramen/ManageRamen.aspx", new List<string> { "Admin", "Staff" } },
            { "/View/Ramen/InsertRamen.aspx", new List<string> { "Admin", "Staff" } },
            { "/View/Ramen/UpdateRamen.aspx", new List<string> { "Admin", "Staff" } },
            { "/View/Ramen/Index.aspx", new List<string> { "Customer" } },
            { "/View/Transaction/Cart.aspx", new List<string> { "Customer" } },
            { "/View/Transaction/Queue.aspx", new List<string> { "Admin", "Staff" } },
            { "/View/History/Index.aspx", new List<string> { "Admin", "Customer" } },
            { "/View/History/Detail.aspx", new List<string> { "Admin", "Customer" } },
            { "/View/Report/Index.aspx", new List<string> { "Admin" } },
            { "/View/Home.aspx", new List<string> { "Admin", "Staff", "Customer" } }
        };

        private Dictionary<string, string> menuItems;
        protected void Page_Load(object sender, EventArgs e)
        {
            var uid = Request.Cookies["uid"];
            var role = Request.Cookies["rid"];
            string currentUrl = Request.Url.AbsolutePath;
            
            if (uid == null && role == null)
            {
                Response.Redirect("/View/Login.aspx");
            }

            if (role != null)
            {
                LabelRole.Text = role.Value;
                if (restrictedUrls.ContainsKey(currentUrl) && !restrictedUrls[currentUrl].Contains(role.Value))
                {
                    Response.Redirect("/View/Home.aspx");
                }
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
            if (Request.Cookies["uid"] != null && Request.Cookies["rid"] != null)
            {
                Response.Cookies["rid"].Expires = DateTime.Now.AddDays(-1);
                Response.Cookies["uid"].Expires = DateTime.Now.AddDays(-1);
                Session.Clear();

                Response.Redirect("/View/Login.aspx");
            }
        }
    }
}