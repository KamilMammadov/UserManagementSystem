using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.ApplicationLogic.Validations;
using UserManagement.Database.Models;
using UserManagement.Database.Repository;

namespace UserManagement.ApplicationLogic
{
    class Authentication
    {
        public static User Register()
        {
            Console.WriteLine();
            Console.WriteLine("name :");
            string name = Console.ReadLine();

            while (!UserValidation.IsNameValid(name))
            {
                Console.WriteLine("write name again");
                name = Console.ReadLine();
            }

            Console.WriteLine("surname :");
            string surname = Console.ReadLine();

            while (!UserValidation.IsSurnameValid(surname))
            {
                Console.WriteLine("write surname again");
                surname = Console.ReadLine();
            }

            Console.WriteLine("email :");
            string email = Console.ReadLine();

            while (!UserValidation.IsEmailValid(email) & UserValidation.isEmailUnical(email))
            {
                Console.WriteLine("write email again");
                email = Console.ReadLine();
            }

            Console.WriteLine("password :");
            string password = Console.ReadLine();

            Console.WriteLine("Confirm Password : ");
            string confirmPassword = Console.ReadLine();


            while (!(UserValidation.IsPasswordValid(password) && UserValidation.IsPaswordsMatch(password, confirmPassword)))
            {
                Console.WriteLine("write password again");
                password = Console.ReadLine();

                Console.WriteLine("write confirm password again");
                confirmPassword = Console.ReadLine();
            }

            UserRepository.Add(name, surname, email, password);
            Console.WriteLine("You succesfully registered you can login now with your account");

            User user = UserRepository.GetUserByEmail(email);

            return user;
            
        }

        public static void Login()
        {
            Console.WriteLine("Enter email");
            string email = Console.ReadLine();

            Console.WriteLine("enter password");
            string password = Console.ReadLine();

            if (UserValidation.IsLogin(email, password))
            {
                User user = UserRepository.GetUserByEmail(email);


                 if (user is Admin)
                {
                    DashBoard dashBoard = new DashBoard(user);
                    DashBoard.AdminPanel(email);
                }
                else
                {
                    DashBoard.UserPanel(email);
                }

            }
        }
    }
}

