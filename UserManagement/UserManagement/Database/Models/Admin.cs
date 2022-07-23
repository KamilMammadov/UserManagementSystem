using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Database.Models
{
    class Admin:User
    {
        //sildikden sonra ishletmek
        public Admin(string name, string surname, string email, string password, int id)
            : base(name, surname, email, password, id)
        {

        }
        public Admin(string firstName, string surname, string email, string password)
            : base(firstName, surname, email, password)
        {


        }

        public override string GetInfo()
        {
            return ID + " " + Name + " " + Surname + " " + Email;
        }
    }
}
