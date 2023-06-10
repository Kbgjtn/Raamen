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

        public static void Insert(Raman ramen)
        {
            db.Ramen.Add(ramen);
            db.SaveChanges();
        }

        public static bool Delete(int id)
        {
            Raman ramen = db.Ramen.Where(r => r.Id == id).FirstOrDefault();
            if (ramen != null)
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

        public static bool UpdateRamenById(int id, string name, string broth, string meat, string price)
        {
            Raman ramen = GetRamenById(id);
            if (ramen == null)
            {
                return false;
            }
            else
            {
                ramen.Name = name;
                ramen.Borth = broth;
                ramen.Price = price;
                ramen.Meat.Name = meat;

                db.SaveChanges();
                return true;
            }
        }
        public static List<Raman> GetRamens()
        {
            return db.Ramen.ToList();
        }
    }
}