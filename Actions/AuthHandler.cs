
namespace Biblioteque
{
    /// <summary>
    /// Класс для аутентификации
    /// </summary>
	public class AuthHandler
	{
        private MessagesToUser _messagesToUser { get; set; }

        public AuthHandler(MessagesToUser messagesToUser)
        {
            _messagesToUser = messagesToUser;
        }
        /// <summary>
        /// Метод для логина
        /// </summary>
        public User? Login()
        {
            //Вводим id
            _messagesToUser.GetIdFromUser();
            int id = int.Parse(Console.ReadLine()!.Trim());
            //Вводим пароль
            _messagesToUser.GetPassword();
            string password = Console.ReadLine()!.Trim();
            

            //Возвращаем людей с таким именем
            UserSearch userSearch = new UserSearch();
            User? foundUser = userSearch.SearchById(Biblioteque.users, id);
            //Если он не пустой, валидируем пароль
            if(foundUser != null)
            {
                if (foundUser.Authenticate(password))
                {
                    _messagesToUser.SayHello(foundUser.Name);
                    return foundUser;
                }
                else _messagesToUser.SendAuthErr(); return null;
            }
            //Если нет ошибка
            else
            {
                _messagesToUser.SendAuthErr(); return null;
            }

        }

        

        /// <summary>
        /// Метод для регистрации пользователя
        /// </summary>
        public void Register()
        {
            _messagesToUser.GetName();
            string newUsername = Console.ReadLine()!.Trim();

            _messagesToUser.GetPassword();
            string newPassword = Console.ReadLine()!.Trim();

            Biblioteque.AddUser(new Customer(newUsername, newPassword,Biblioteque.GetLastUserId()+1));

            _messagesToUser.SendOK();
        }

        


        /// <summary>
        /// Метод для регистрации работника
        /// </summary>
        public void Register(string workername)
        {
            string newUsername = workername.Trim();
            _messagesToUser.GetPassword();
            string newPassword = Console.ReadLine()!.Trim();
            Biblioteque.AddUser(new Librarian(newUsername, newPassword, Biblioteque.GetLastUserId() + 1));
            _messagesToUser.SendOK();
        }
    }
}

