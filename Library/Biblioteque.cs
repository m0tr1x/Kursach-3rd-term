
namespace Biblioteque
{
    /// <summary>
    /// Класс библиотеки
    /// </summary>
    static class Biblioteque
    {
        public static List<Book> books = new();
        public static List<User?> users = new();

        /// <summary>
        /// Метод для получения id последнего пользователя
        /// </summary>
        /// <returns></returns>
        public static int GetLastUserId()
        {
            return users[^1].Id;
        }
        /// <summary>
        /// Метод для добавление книги в библиотеку
        /// </summary>
        /// <param name="example"> Экземпляр книги</param>
        public static void AddBookToLibrary(Book example)
        {
            books.Add(example);
        }
        public static void GetBookFromLibrary(Book example)
        {
            example.Condition -= 1;
        }
        /// <summary>
        /// Метод для добавления пользователя в библиотеку
        /// </summary>
        /// <param name="user">Экземпляр пользователя</param>
        public static void AddUser(Customer user)
        {
            users.Add(user);
        }
        /// <summary>
        /// Метод для добавления работника в библиотеку
        /// </summary>
        /// <param name="user">Экземпляр работника</param>
        public static void AddUser(Librarian user)
        {
            users.Add(user);
        }
        //Немного ad-hoc полиморфизма
    }

}
