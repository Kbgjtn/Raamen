using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace WebApplication.Utills
{
    public class UserValidator
    {
        public static bool CheckPasswordMatched(string password, string confirmPassword)
        {
            if (String.IsNullOrWhiteSpace(confirmPassword) && String.IsNullOrWhiteSpace(password))
            {
                return false;
            }

            return String.Equals(password, confirmPassword);
        }

        public static bool CheckIsEmailValid(string email)
        {
            return Regex.IsMatch(email, @"^([a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,})$") && email.EndsWith(".com");
        }

        public static bool RequiredInput(string value)
        {
            return String.IsNullOrWhiteSpace(value);
        }

        public static string CheckGender(bool man, bool woman)
        {
            if (man && !woman)
            {
                return "man";
            }
            else
            {
                return "woman";
            }
        }

        public static string CheckUserRole(bool customer, bool staff)
        {
            return customer && !staff ? "Customer" : "Staff";
        }
    }
}