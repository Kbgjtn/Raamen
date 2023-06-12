using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Model;

namespace WebApplication.Factory
{
    public class TransactionFactory
    {
        public static Header CreateHeader(int customerId, List<Detail> cart)
        {
            Header header = new Header
            {
                CustomerId = customerId,
                Date = DateTime.Now,
                Details = cart
            };

            return header;
        }
    }
}