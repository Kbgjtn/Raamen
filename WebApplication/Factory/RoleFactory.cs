using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Model;

namespace WebApplication.Factory
{
    public class RoleFactory
    {
        public static Role CreateRole(string role_name)
        {
            Role role = new Role();
            role.Name = role_name;
            return role;
        }
    }
}