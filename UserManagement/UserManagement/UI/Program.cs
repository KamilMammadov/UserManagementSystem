using System;
using UserManagement.ApplicationLogic;

namespace UserManagement
{
    class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
            Console.WriteLine("------------------------");

            Console.WriteLine("commands :");

            Console.WriteLine("reg");
            Console.WriteLine("log");
                Console.WriteLine("enterCommand");
                string command = Console.ReadLine();

                if (command == "reg")
                {
                    Authentication.Register();
                }
                else if (command == "log")
                {
                    Authentication.Login();
                }
            }

        }
    }
}
