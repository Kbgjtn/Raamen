using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Handlers;
using WebApplication.Model;

namespace WebApplication.Controllers
{
    public class UserController
    {
        public static void CreateUser(string username, string email, string gender, string password, string roleName)
        {
            UserHandler.CreateUser(username, email, gender, password, roleName);
        }

        public static bool Update(int id, string new_username, string new_email, string new_gender)
        {
            return UserHandler.UpdateUser(id, new_username, new_email, new_gender);
        }

        public static User Login(string username, string password)
        {
            return UserHandler.GetUser(username, password);
        }

        public static User GetUserById(int id)
        {
            return UserHandler.GetUserById(id);
        }

        public static List<User> GetUsers()
        {
            return UserHandler.GetUsers();
        }

        public static List<User> GetAllUserByRole(string role)
        {
            return UserHandler.GetAllUserByRole(role);
        }

    }
}