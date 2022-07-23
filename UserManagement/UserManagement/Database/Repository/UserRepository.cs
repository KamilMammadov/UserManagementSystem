using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Database.Models;

namespace UserManagement.Database.Repository
{
    class UserRepository
    {
        private static int _idcounter;

        public static int IDCounter
        {
            get
            {
                _idcounter++;
                return _idcounter;
            }

        }


        public static List<User> Users { get; set; } = new List<User>()
        {
            new User ("Kamil","Mammadov","kamil@gmail.com","123321"),
            new Admin ("Super","admin","admin@gmail.com","123321")


        };

        public static User Add(string name, string surname, string email, string password)
        {
            User user = new User(name, surname, email, password, IDCounter);
            Users.Add(user);
            return user;
        }

        public static User Add(string name, string surname, string email, string password, int id)
        {
            User user = new User(name, surname, email, password, id);
            Users.Add(user);
            return user;
        }

        public static User Add(User user)
        {
            Users.Add(user);
            return user;
        }
        public static User Add(Admin admin)
        {
            Users.Add(admin);
            return admin;
        }

        public static bool Delete(User user)
        {
            return Users.Remove(user);
        }


        public static List<User> GetAll()
        {
            return Users;
        }


        public static User GetUserByEmail(string email)
        {
            foreach (User user in Users)
            {
                if (user.Email == email)
                {
                    return user;
                }
            }
            return null;
        }


        public static bool RemoveUserByEmail(string email)
        {
            foreach (User user in Users)
            {
                if (user.Email == email)
                {
                    Users.Remove(user);
                    return true;
                }
            }
            return false;
        }

    }
}
