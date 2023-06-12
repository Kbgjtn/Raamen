using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Factory;
using WebApplication.Model;
using WebApplication.Repository;

namespace WebApplication.Handlers
{
    public class TransactionHandler
    {
        public static void CreateTransactionHeader(int customerId, List<Detail> transactionDetails)
        {
            Header transactionHeader = TransactionFactory.CreateHeader(customerId, transactionDetails);
            TransactionRepository.CreateTransaction(transactionHeader);
        }

        public static Header GetHeaderById(int id)
        {
            return TransactionRepository.GetHeaderById(id);
        }

        public static List<Header> GetHeaders()
        {
            return TransactionRepository.GetHeaders();
        }

        // Get Unhandled Transaction by passing 0 as staffId
        public static List<Header> GetHeaders(int staffId = 0)
        {
            return TransactionRepository.GetHeaders(staffId);
        }

        public static List<Header> GetHeadersByCustomerId(int id)
        {
            return TransactionRepository.GetHeadersByCustomerId(id);
        }

        public static void UpdateTransaction(int id, int staffId)
        {
            TransactionRepository.UpdateTransaction(id, staffId);
        }
    }
}