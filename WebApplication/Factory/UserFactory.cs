using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Model;

namespace WebApplication.Factory
{
    public class UserFactory
    {
        public static User CreateUser(string username, string email, string gender, string password, Role role)
        {
            User user = new User();
            user.Username = username;
            user.Email = email;
            user.Gender = gender;
            user.Password = password;
            user.Role = role;

            return user;
        }
    }
}