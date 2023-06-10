﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Handlers;
using WebApplication.Model;

namespace WebApplication.Controllers
{
    public class RamenController
    {
        public static void InsertRamen(string name, string meatName, string broth, string price)
        {
            RamenHandler.InsertRamen(name, meatName, broth, price);
        }

        public static void InsertMeat(string name)
        {
            RamenHandler.InsertMeat(name);
        }

        public static bool DeleteRamen(int id)
        {
            return RamenHandler.DeleteRamen(id);
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