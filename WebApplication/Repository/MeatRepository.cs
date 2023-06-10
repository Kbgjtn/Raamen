using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Model;

namespace WebApplication.Repository
{
    public class MeatRepository
    {
        private static readonly Database1Entities db = new Database1Entities();
        public static void InsertMeat(Meat meat)
        {
            db.Meats.Add(meat);
            db.SaveChanges();
        }

        public static bool UpdateMeat(int id, string meatName)
        {
            Meat meat = GetMeatById(id);

            if (meat == null)
            {
                return false;
            }
            else
            {
                meat.Name = meatName;
                db.SaveChanges();
                return true;
            }
        }

        public static Meat GetMeatById(int id)
        {
            return db.Meats.Find(id);
        }

        public static List<Meat> GetMeats()
        {
            return db.Meats.ToList();
        }

    }
}