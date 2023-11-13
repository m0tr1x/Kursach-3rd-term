
namespace Biblioteque
{
    /// <summary>
    /// Абстрактный класс для пользователя, который может быть либо работником, либо читателем
    /// </summary>
    abstract class User
    {
        // Поле для хранения роли пользователя
        public string Role { get; }

        // ФИО пользователя
        private string _name;
        private string _password;
        public string Name

        {
            get { return _name; }
            set { _name = value; }
        }

        // Конструктор класса User
        public User(string role, string name, string password)
        {
            Role = role;
            Name = name;
            _password = password;
        }

        /// <summary>
        /// Метод для проверки соответсвия паролей
        /// </summary>
        /// <param name="password">Предполагаемый пароль</param>
        /// <returns></returns>
        public bool Authenticate(string password)
        {
            return _password == password;
        }

    }
}

