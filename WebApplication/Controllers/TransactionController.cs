using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Handlers;
using WebApplication.Model;

namespace WebApplication.Controllers
{

    public class TransactionHistory { 
        public Header Header { get; set; }
       public  User User { get; set; }
    }

    public class TransactionController
    {
        public static void CreateTransactionHeader(int customerId, List<Detail> transactionDetails)
        {
            TransactionHandler.CreateTransactionHeader(customerId, transactionDetails);
        }

        public static Header GetHeaderById(int id)
        {
            return TransactionHandler.GetHeaderById(id);
        }

        public static List<Header> GetHeaders()
        {
            return TransactionHandler.GetHeaders();
        }

        // Get Unhandled Transaction by passing 0 as staffId
        public static List<Header> GetHeaders(int staffId = 0)
        {
            return TransactionHandler.GetHeaders(staffId);
        }

        public static List<Header> GetHeadersByCustomerId(int id)
        {
            return TransactionHandler.GetHeadersByCustomerId(id);
        }

        public static void UpdateTransaction(int id, int staffId)
        {
            TransactionHandler.UpdateTransaction(id, staffId);
        }
    }
}