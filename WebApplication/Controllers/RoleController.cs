using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Handlers;

namespace WebApplication.Controllers
{
    public class RoleController
    {
        public static void CreateRole(string name)
        {
            RoleHandler.CreateRole(name);
        }

        public static void CreateRoles(List<string> roleNames)
        {
            RoleHandler.CreateRoles(roleNames);
        }
    }
}