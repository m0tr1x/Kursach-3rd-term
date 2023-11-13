using System;
namespace Biblioteque
{
    /// <summary>
    /// Класс для аутентификации
    /// </summary>
	public class AuthHandler
	{
        /// <summary>
        /// Метод для логина
        /// </summary>
        public static void Login()
        {
            //Вводим логин
            Console.WriteLine("Введите логин:");
            string username = Console.ReadLine();
            //Вводим пароль
            Console.WriteLine("Введите пароль:");
            string password = Console.ReadLine();

            //Возвращаем список людей с таким именем
            UserSearch userSearch = new UserSearch();
            List<User> foundUsers = userSearch.SearchByName(Biblioteque.users, username);
            //Если он не пустой, валидируем пароль
            if(foundUsers.Count > 0)
            {
                if (foundUsers[0].Authenticate(password)) Console.WriteLine("Вход выполнен успешно!");
                else Console.WriteLine("Вход не выполнен, неправильный пароль");
            }
            //Если нет ошибка
            else
            {
                Console.WriteLine("Пользователь с указанным именем не найден");
            }

        }
        /// <summary>
        /// Метод для регистрации
        /// </summary>
        public static void Register()
        {
            Console.WriteLine("Введите новый логин:");
            string newUsername = Console.ReadLine();

            Console.WriteLine("Введите новый пароль:");
            string newPassword = Console.ReadLine();

            Biblioteque.AddUserToLibrary(new Customer(newUsername, newPassword));

            Console.WriteLine("Регистрация успешна!");
        }
    }
}

