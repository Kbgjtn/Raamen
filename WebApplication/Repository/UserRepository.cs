using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Model;

namespace WebApplication.Repository
{
    public class UserRepository
    {
        private static readonly Database1Entities db = new Database1Entities();

        public static void Insert(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }

        public static bool Update(int id, string username, string email, string gender)
        {
            User user = GetUserById(id);

            if (user == null)
            {
                return false;
            }
            else
            {
                user.Username = username;
                user.Email = email;
                user.Gender = gender;

                db.SaveChanges();
                return true;
            }
        }

        public static User GetUser(string username, string password)
        {
            var user = (from x in db.Users where x.Username.Equals(username) && x.Password.Equals(password) select x).FirstOrDefault();

            return user;
        }

        public static User GetUserById(int id)
        {
            return db.Users.Find(id);
        }


        public static List<User> GetUsers()
        {
            return db.Users.ToList();
        }

        public static List<User> GetAllUserByRole(string role)
        {
            return db.Users.Where(u => u.Role.Name == role).ToList();
        }
    }
}