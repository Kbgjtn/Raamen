using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Handlers;
using WebApplication.Model;

namespace WebApplication.Controllers
{
    public class RamenController
    {
        public static string InsertRamen(string name, string meatId, string broth, string price)
        {
            bool isPriceString = System.Text.RegularExpressions.Regex.IsMatch(price, "[^0-9]");

            if (name.Equals("") || meatId.Equals("") || broth.Equals("") || price.Equals(""))
            {
                return "Please fill all the field";
            }
            else if (!name.Contains("Ramen"))
            {
                return "Name must contains 'Ramen'";
            }
            else if (meatId.Equals(""))
            {
                return "Meat must be selected";
            }
            else if (isPriceString)
            {
                return "Price must be number";
            }
            else if (int.Parse(price) < 3000)
            {
                return "Price must be at least 3000";
            }

            return RamenHandler.InsertRamen(name, meatId, broth, price);
        }
        //public static void InsertRamen(string name, string meatName, string broth, string price)
        //{
        //    RamenHandler.InsertRamen(name, meatName, broth, price);
        //}

        public static void InsertMeat(string name)
        {
            RamenHandler.InsertMeat(name);
        }

        public static bool DeleteRamen(int id)
        {
            return RamenHandler.DeleteRamen(id);
        }

        public static string deleteRamen(int ramenId)
        {
            return RamenHandler.deleteRamen(ramenId);
        }

        public static Raman GetRamen(int id)
        {
            return RamenHandler.GetRamenById(id);
        }

        public static Meat GetMeat(int id)
        {
            return RamenHandler.GetMeatById(id);
        }

        public static bool UpdateRamen(int id, string name, string broth, string meat, string price)
        {
            return RamenHandler.UpdateRamen(id, name, broth, meat, price);
        }

        public static string updateRamen(int ramenId, string name, string meatId, string broth, string price)
        {
            bool isPriceString = System.Text.RegularExpressions.Regex.IsMatch(price, "[^0-9]");

            if (name.Equals("") || meatId.Equals("") || broth.Equals("") || price.Equals(""))
            {
                return "Please fill all the field";
            }
            else if (!name.Contains("Ramen"))
            {
                return "Name must contains 'Ramen'";
            }
            else if (meatId.Equals(""))
            {
                return "Meat must be selected";
            }
            else if (isPriceString)
            {
                return "Price must be number";
            }
            else if (int.Parse(price) < 3000)
            {
                return "Price must be at least 3000";
            }

            return RamenHandler.updateRamen(ramenId, name, meatId, broth, price);
        }

        public static bool UpdateMeat(int id, string name)
        {
            return RamenHandler.UpdateMeat(id, name);
        }

        public static List<Raman> GetAllRamen()
        {
            return RamenHandler.GetAllRamen();
        }

        public static List<Meat> GetAllMeat()
        {
            return RamenHandler.GetAllMeat();
        }
    }
}