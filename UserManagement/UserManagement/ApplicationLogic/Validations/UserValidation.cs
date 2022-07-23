using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UserManagement.Database.Models;
using UserManagement.Database.Repository;

namespace UserManagement.ApplicationLogic.Validations
{
    class UserValidation
    {
        public static bool IsNameValid(string name)
        {
            Regex regex = new Regex(@"^[A-Z]+[a-z]{2,30}");

            return regex.IsMatch(name);
        }

        public static bool IsSurnameValid(string surname)
        {
            Regex regex = new Regex(@"^[A-Z]+[a-z]{2,30}");

            return regex.IsMatch(surname);
        }

        public static bool IsEmailValid(string email)
        {
            Regex regex = new Regex("^[a-z]+[@]+[code]+[.]+[edu]+[.]+[az]+$");

            return regex.IsMatch(email);
        }

        public static bool IsPasswordValid(string password)
        {
            Regex regex = new Regex(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]).{8,}$");

            return regex.IsMatch(password);
        }

        public static bool IsPaswordsMatch(string password, string confirmPassword)
        {
            return password == confirmPassword;
        }

        public static bool isEmailUnical(string email)
        {
            foreach (User user in UserRepository.Users)
            {
                if (user.Email==email)
                {
                    return true;
                }
            }
            return false;
        }

        ///////////////////////////////
        ///

        public static bool IsLogin(string email, string password)
        {
            foreach (User user in UserRepository.Users)
            {
                if (user.Email == email && user.Password == password)
                {
                    return true;
                }
            }
            Console.WriteLine("melumatlar yanlishdir");
            return false;

        }

        public static bool IsAdmin(User user)
        {
            if (user is Admin)
            {
                Console.WriteLine("User is Admin");
                return true;
            }
            return false;
        }

       



    }
}
