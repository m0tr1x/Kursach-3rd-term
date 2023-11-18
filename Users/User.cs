
namespace Biblioteque
{
    /// <summary>
    /// Абстрактный класс для пользователя, который может быть либо работником, либо читателем, либо админом
    /// </summary>
    public abstract class User
    {
        // Поле для хранения роли пользователя
        public string Role { get; }
        public int Id { get; private set; }

        // ФИО пользователя
        private string _name;
        //Его пароль
        public string Password { get; private set; }
        public string Name

        {
            get { return _name; }
            set { _name = value; }
        }

        // Конструктор класса User
        public User(string role, string name, string password, int id)
        {
            Role = role;
            Name = name;
            Password = password;
            Id = id;
        }

        /// <summary>
        /// Метод для проверки соответсвия паролей
        /// </summary>
        /// <param name="password">Предполагаемый пароль</param>
        /// <returns></returns>
        public bool Authenticate(string password)
        {
            return Password == password;
        }

    }
}

