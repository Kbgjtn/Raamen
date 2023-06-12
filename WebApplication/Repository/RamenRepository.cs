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

        public static string InsertRamen(Raman item)
        {
            db.Ramen.Add(item);
            db.SaveChanges();

            return "success add: " + item.Name;
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

        public static string deleteRamen(int ramenId)
        {
            Raman item = db.Ramen.Find(ramenId);

            if(item != null)
            {
                string temp = item.Name;

                db.Ramen.Remove(item);
                db.SaveChanges();

                return "success deleted: " + temp;
            }
            else
            {
                return "ramen not found, please refresh your page";
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

        public static string updateRamen(int ramenId, string name, string meatId, string broth, string price)
        {
            Raman item = GetRamenById(ramenId);

            if (item != null)
            {
                string temp = item.Name;

                item.MeatId = int.Parse(meatId);
                item.Name = name;
                item.Borth = broth;
                item.Price = price;

                db.SaveChanges();

                return "success updated: " + temp;
            }
            else
            {
                return "ramen not found";
            }
        }

        public static List<Raman> GetRamens()
        {
            return db.Ramen.ToList();
        }
    }
}