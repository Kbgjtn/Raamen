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

        // ini timi
        public static string UpdateUser(int id, string new_username, string new_email, string new_gender, string input_password, string curr_password)
        {
            if (new_username.Equals("") || new_email.Equals("") || input_password.Equals(""))
            {
                return "All field must be filled";
            }
            else if ((new_username.Length < 5 || new_username.Length > 15) || !(new_username.All(Char.IsLetter)))
            {
                return new_username + " Length must be between 5 and 15 and alphabet with space only.";
            }
            else if (!new_email.EndsWith(".com"))
            {
                return "Email must ends with ‘.com’.";
            }
            else if (new_gender == "")
            {
                return "Gender must be chosen";
            }
            else if (!input_password.Equals(curr_password))
            {
                return "Username Must be the same with the current password.";
            }

            return UserHandler.updateUser(id, new_username, new_email, new_gender);
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