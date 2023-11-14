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
        public static User Login()
        {
            //Вводим логин
            Console.WriteLine("Введите логин:");
            string username = Console.ReadLine().Trim();
            //Вводим пароль
            Console.WriteLine("Введите пароль:");
            string password = Console.ReadLine().Trim();

            //Возвращаем список людей с таким именем
            UserSearch userSearch = new UserSearch();
            List<User> foundUsers = userSearch.SearchByName(Biblioteque.users, username);
            //Если он не пустой, валидируем пароль
            if(foundUsers.Count > 0)
            {
                if (foundUsers[0].Authenticate(password))
                {
                    Console.WriteLine($"Вход выполнен успешно!Здравствуйте {foundUsers[0]}");
                    return foundUsers[0];
                }
                else Console.WriteLine("Вход не выполнен, неправильный пароль"); return null;
            }
            //Если нет ошибка
            else
            {
                Console.WriteLine("Пользователь с указанным именем не найден"); return null;
            }

        }
        /// <summary>
        /// Метод для регистрации пользователя
        /// </summary>
        public static void Register()
        {
            Console.WriteLine("Введите новый логин:");
            string newUsername = Console.ReadLine().Trim();

            Console.WriteLine("Введите новый пароль:");
            string newPassword = Console.ReadLine().Trim();

            Biblioteque.AddUser(new Customer(newUsername, newPassword));

            Console.WriteLine("Регистрация успешна!");
        }
        /// <summary>
        /// Метод для регистрации работника
        /// </summary>
        public static void Register(string workername)
        {
            string newUsername = workername.Trim();

            Console.WriteLine("Введите новый пароль:");
            string newPassword = Console.ReadLine().Trim();

            Biblioteque.AddUser(new Librarian(newUsername, newPassword));

            Console.WriteLine("Регистрация успешна!");
        }
    }
}

