using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Factory;
using WebApplication.Model;
using WebApplication.Repository;

namespace WebApplication.Handlers
{
    public class RoleHandler
    {
        public static Role CreateRole(string name)
        {
            return RoleRepository.Insert(RoleFactory.CreateRole(name));
        }

        public static void CreateRoles(List<string> rolesName)
        {
            foreach (var role in rolesName)
            {
                RoleRepository.Insert(RoleFactory.CreateRole(role));
            }
        }
    }
}