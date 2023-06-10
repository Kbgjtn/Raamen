using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Factory;
using WebApplication.Model;
using WebApplication.Repository;

namespace WebApplication.Handlers
{
    public class UserHandler {
        public static void CreateUser(string username, string email, string gender, string password, string roleName)
        {
            Role role = RoleFactory.CreateRole(roleName);
            User user = UserFactory.CreateUser(username, email, gender, password, role);
            UserRepository.Insert(user);
        }

        public static bool UpdateUser(int id, string new_username, string new_email, string new_gender)
        {
            return UserRepository.Update(id, new_username, new_email, new_gender);
        }

        public static User GetUser(string username, string password)
        {
            return UserRepository.GetUser(username, password);
        }

        public static User GetUserById(int id)
        {
            return UserRepository.GetUserById(id);
        }

        public static List<User> GetUsers()
        {
            return UserRepository.GetUsers();
        }
        public static List<User> GetAllUserByRole(string role)
        {
            return UserRepository.GetAllUserByRole(role);
        }
    }
}