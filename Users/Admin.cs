using System;
namespace Biblioteque
{
    public class Admin : User
    {
        public Admin(string role, string name, string password) : base("Администатор", name, password)
        {
        }
        /// <summary>
        /// Метод для добавления новых работников
        /// </summary>
        public void AddNewLibrarian(string name)
        {
            AuthHandler.Register(name);
        }

    }
}

