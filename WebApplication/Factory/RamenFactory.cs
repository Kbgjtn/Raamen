﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Model;

namespace WebApplication.Factory
{
    public class RamenFactory
    {

        public static Raman InsertRamen(string name, string meatId, string broth, string price)
        {
            Raman item = new Raman();

            item.Name = name;
            item.MeatId = int.Parse(meatId);
            item.Borth = broth;
            item.Price = price;

            return item;
        }

        //public static Raman CreateRamen(string name, Meat meat, string broth, string price)
        //{

        //    Raman ramen = new Raman();

        //    ramen.Name = name;
        //    ramen.Borth = broth;
        //    ramen.Price = price;
        //    ramen.Meat = meat;

        //    return ramen;
        //}

        public static Meat CreateMeat(string name)
        {
            Meat meat = new Meat();
            meat.Name = name;

            return meat;
        }
    }
}