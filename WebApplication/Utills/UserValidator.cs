using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

        // check email apa udah dipake atau belum, return true kalau udah ada yg pake
        public bool CheckIsEmailExists(string email)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework");
            connection.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM [User] WHERE Email = @Email", connection);

            cmd.Parameters.AddWithValue("@Email", email);
            int count = (int)cmd.ExecuteScalar();
            return count > 0;
        }

        public static string CheckEmail(string email)
        {
            UserValidator uv = new UserValidator();
            bool isValid = CheckIsEmailValid(email);
            bool isExist = uv.CheckIsEmailExists(email);

            if (isValid)
            {
                return "Email: must be using domain '.com'";
            }
            else if(isExist)
            {
                return "The email already exists. Please use a different email address.";
            }
            else
            {
                return "";
            }

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