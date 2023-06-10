using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Model;

namespace WebApplication.Factory
{
    public class TransactionFactory
    {
        public static Header CreateHeader(int customerId, int staffId, List<Detail> cart)
        {
            Header header = new Header
            {
                CustomerId = customerId,
                StaffId = staffId,
                Date = DateTime.Now,
                Details = cart
            };

            return header;
        }
    }
}