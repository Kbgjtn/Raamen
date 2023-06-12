using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication.Model;

namespace WebApplication.View.Report
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CrystalReport1 report = new CrystalReport1();
            CrystalReportViewer1.ReportSource = report;

            Database1Entities db = new Database1Entities();
            DataSet1 data = getData(db.Headers.ToList());
            report.SetDataSource(data);
        }

        private DataSet1 getData(List<Header> headers)
        {
            DataSet1 data = new DataSet1();
            var header = data.Header;
            var detail = data.Detail;
            int totalPrice = 0;

            foreach (Header x in headers)
            {
                var hrow = header.NewRow();
                hrow["Id"] = x.Id;
                hrow["CustomerId"] = x.User.Username;
                hrow["StaffId"] = x.StaffId;
                hrow["Date"] = x.Date;
                hrow["TotalPrice"] = totalPrice.ToString();
                header.Rows.Add(hrow);

                foreach (Detail y in x.Details)
                {
                    var drow = detail.NewRow();
                    drow["HeaderId"] = y.HeaderId;
                    drow["MeatName"] = y.Raman.Meat.Name;
                    drow["Price"] = y.Raman.Price;
                    drow["Username"] = y.Header.User.Username;
                    drow["RamenId"] = y.Raman.Name;
                    drow["Quantity"] = y.Quantity;
                    drow["TotalPrice"] = (int.Parse(y.Raman.Price) * y.Quantity).ToString();
                    drow["SubTotalPrice"] = x.Details.Sum(z => int.Parse(z.Raman.Price) * z.Quantity);
                    totalPrice += int.Parse(drow["SubTotalPrice"].ToString());
                    detail.Rows.Add(drow);
                }
            }

            return data;
        }
    }
}