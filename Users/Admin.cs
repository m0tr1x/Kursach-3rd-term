using System;
namespace Biblioteque
{
    public class Admin : User
    {
        public Admin(string name, string password, int id) : base("Администатор", name, password, id)
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

