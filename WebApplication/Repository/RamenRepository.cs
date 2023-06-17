using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Model;

namespace WebApplication.Repository
{
    public class RamenRepository
    {
        private static readonly Database1Entities db = new Database1Entities();

        public static string Insert(Raman ramen)
        {
            db.Ramen.Add(ramen);
            db.SaveChanges();

            return "success add: " + ramen.Name;
        }

        public static bool Delete(int id)
        {
            Raman ramen = GetRamenById(id);
            var detail = db.Details.Where(d => d.RamenId == id).FirstOrDefault();
            
            if (detail != null)
            {
                return false;
            }
            else if (ramen != null && detail == null)
            {
                db.Ramen.Remove(ramen);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public static Raman GetRamenById(int id)
        {
            return db.Ramen.Find(id);
        }

        public static string UpdateRamenById(int id, string name, string broth, string meat, string price)
        {
            Raman ramen = GetRamenById(id);
            if (ramen == null)
            {
                return "failed";
            }
            else
            {
                ramen.Name = name;
                ramen.Borth = broth;
                ramen.Price = price;
                ramen.Meat.Name = meat;

                db.SaveChanges();
                return "success updated";
            }
        }
        public static List<Raman> GetRamens()
        {
            return db.Ramen.ToList();
        }
    }
}