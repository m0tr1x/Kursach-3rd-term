
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
        public static User? Login()
        {
            //Вводим id
            Console.WriteLine("Введите ваш id");
            int id = int.Parse(Console.ReadLine()!.Trim());
            //Вводим пароль
            Console.WriteLine("Введите пароль:");
            string password = Console.ReadLine()!.Trim();

            //Возвращаем людей с таким именем
            UserSearch userSearch = new UserSearch();
            User? foundUser = userSearch.SearchById(Biblioteque.users, id);
            //Если он не пустой, валидируем пароль
            if(foundUser != null)
            {
                if (foundUser.Authenticate(password))
                {
                    Console.WriteLine($"Вход выполнен успешно!Здравствуйте {foundUser.Name}");
                    return foundUser;
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
            string newUsername = Console.ReadLine()!.Trim();

            Console.WriteLine("Введите новый пароль:");
            string newPassword = Console.ReadLine()!.Trim();

            Biblioteque.AddUser(new Customer(newUsername, newPassword,Biblioteque.GetLastUserId()+1));

            Console.WriteLine("Регистрация успешна!");
        }
        /// <summary>
        /// Метод для регистрации работника
        /// </summary>
        public static void Register(string workername)
        {
            string newUsername = workername.Trim();

            Console.WriteLine("Введите новый пароль:");
            string newPassword = Console.ReadLine()!.Trim();

            Biblioteque.AddUser(new Librarian(newUsername, newPassword, Biblioteque.GetLastUserId() + 1));

            Console.WriteLine("Регистрация успешна!");
        }
    }
}

