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
    class DashBoard
    {


        
        public static void AdminPanel(string email)
        {

        User user = UserRepository.GetUserByEmail(email);
            Console.WriteLine("Admin succesfully joined", user.GetInfo());

            while (true)
            {
                Console.WriteLine("-----------------------------------------------------------");
                Console.WriteLine("Commands");

                Console.WriteLine("USER COMMANDS : ");
                Console.WriteLine("/show-users");
                Console.WriteLine("/remove-user");
                Console.WriteLine("/add-user");
                Console.WriteLine("/update-user");
                Console.WriteLine();
                Console.WriteLine("ADMIN USER`S COMMANDS :");
                Console.WriteLine("/make-admin");
                Console.WriteLine("/remove-admin");
                Console.WriteLine("/show-admins");
                Console.WriteLine("/add-admin");
                Console.WriteLine("/logout");

                Console.WriteLine("Enter Command");
                string command = Console.ReadLine();

                if (command == "/show-users")
                {
                    List<User> Users = UserRepository.GetAll();
                    foreach (User oneuser in Users)
                    {
                        Console.WriteLine(oneuser.ID + " " + oneuser.Name + " " + oneuser.Surname + " " + oneuser.Email);
                    }
                }
                else if (command == "/remove-user")
                {
                    Console.WriteLine("Please Enter email");
                    string targetemail = Console.ReadLine();

                    User RemoveUser = UserRepository.GetUserByEmail(targetemail);
                    if (RemoveUser == null)
                    {
                        Console.WriteLine("Email not found");
                    }
                    else
                    {
                        UserRepository.Delete(RemoveUser);
                        Console.WriteLine("User succesfully deleted");
                    }

                }
                else if (command == "/add-user")
                {
                    Authentication.Register();
                }

                else if (command == "/update-user")
                {
                    Console.WriteLine("enter user's email");
                    string updateEmail = Console.ReadLine();
                    User updateUser = UserRepository.GetUserByEmail(updateEmail);
                    if (!UserValidation.IsAdmin(updateUser))
                    {
                        UserRepository.Update(updateUser);
                        Console.WriteLine("succesfully updated");

                    }
                }

                else if (command == "/add-admin")
                {
                    User adminUser = Authentication.Register();
                    UserRepository.Delete(adminUser);

                    Admin admin = new Admin(adminUser.Name, adminUser.Surname, adminUser.Email, adminUser.Password, adminUser.ID);
                    UserRepository.Add(admin);
                    Console.WriteLine($"{admin.Name} {admin.Surname} is new Admin now");
                }

                else if (command == "/show-admins")
                {
                    Console.WriteLine("ADMINS : ");
                    UserRepository.ShowAdmins();

                }
                else if (command == "/make-admin")
                {
                    Console.WriteLine("Enter email");
                    string adminEmail = Console.ReadLine();
                    User user1 = UserRepository.GetUserByEmail(adminEmail);

                    UserRepository.Delete(user1);

                    Admin admin = new Admin(user1.Name, user1.Surname, user1.Email, user1.Password, user1.ID);
                    UserRepository.Add(admin);
                    Console.WriteLine($"{admin.Name} {admin.Surname} is Admin now");
                }
                else if (command == "/remove-admin")
                {
                    Console.WriteLine("emaili daxil edin");
                    string targetemail = Console.ReadLine();

                    User adminuser = UserRepository.GetUserByEmail(targetemail);
                    if (adminuser is Admin)
                    {

                        UserRepository.Delete(adminuser);
                        Console.WriteLine("Admin succesfully deleted");

                    }

                }

                else if (command == "/logout")
                {
                    Program.Main(new string[] { });
                }
                else
                {
                    Console.WriteLine("Command Not Found");
                }
            }

        }

        public static void UserPanel(string email)
        {
            User user = UserRepository.GetUserByEmail(email);
            Console.WriteLine($"User successfully authenticated : {user.GetInfo()}");
            Console.WriteLine();

            Console.WriteLine("commands : /logout \n /report ");
            string command = Console.ReadLine();

            if (command == "/logout")
            {
                Program.Main(new string[] { });
            }
            else
            {
                Console.WriteLine("command not found");
            }
        }
    }
}
