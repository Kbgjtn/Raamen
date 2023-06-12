using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Model;

namespace WebApplication.Repository
{
    public class TransactionRepository
    {
        private static readonly Database1Entities db = new Database1Entities();

        public static void CreateTransaction(Header header)
        {
            db.Headers.Add(header);
            db.SaveChanges();
        }

        public static Header GetHeaderById(int id) {
            return db.Headers.Find(id);
        }

        public static List<Header> GetHeaders()
        {
            return db.Headers.Where(header => header.StaffId != null).ToList();
        }

        public static List<Header> GetHeaders(int staffId = 0)
        {
            return db.Headers.Where(head => head.StaffId == staffId).ToList();
        }

        public static List<Header> GetHeadersByCustomerId(int id)
        {
            return db.Headers.Where(head => head.CustomerId == id && head.StaffId != 0).ToList();
        }

        public static void UpdateTransaction(int id, int staffId)
        {
            Header header = GetHeaderById(id);
            header.StaffId = staffId;

            db.SaveChanges();
        }

    }
}