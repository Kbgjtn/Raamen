using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Model;

namespace WebApplication.Repository
{
    public class RoleRepository
    {
        private static readonly Database1Entities db = new Database1Entities();
        public static void Inserts(IEnumerable<Role> roles)
        {
            foreach (var role in roles)
            {
                db.Roles.Add(role);
            }

            db.SaveChanges();
        }

        public static Role Insert(Role role)
        {
            Role newRole = db.Roles.Add(role);
            db.SaveChanges();
            return newRole;
        }

        public static Role GetRoleById(int id)
        {
            return db.Roles.Find(id);
        }
    }
}