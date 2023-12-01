using System;
namespace Biblioteque
{
    public class Admin : User
    {
        public Admin(string name, string password, int id) : base("Администатор", name, password, id)
        {
        }
    }
}

