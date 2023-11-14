
namespace Biblioteque
{
    /// <summary>
    /// Класс библиотеки
    /// </summary>
    static class Biblioteque
    {
        public static List<Book> books = new();
        public static List<User> users = new();
        /// <summary>1
        /// Метод для вывод количества книг на экран
        /// </summary>
        public static void GetBookCount()
        {
            Console.WriteLine($"В библиотеке на данный момент {books.Count} книг");
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
            example.Avaliable = false;
            example.Condition -= 1;
        }
        /// <summary>
        /// Метод для вывода всех пользователей
        /// </summary>
        public static void DisplayAllUsers()
        {
            foreach (var user in users)
            {
                Console.WriteLine($"User: {user.Name} ({user.Role})");
            }
            Console.WriteLine();
        }
        /// <summary>
        /// Метод для вывода всех книг
        /// </summary>
        public static void DisplayAllBooks()
        {
            foreach (var book in books)
            {
                Console.WriteLine($"Название: {book.Name} Автор: {book.Author}, Состояние: {book.Condition}%, В наличии: {(book.Avaliable ? "Да" : "Нет")}");
            }
            Console.WriteLine();
        }
        public static void DisplayAllAvaliableBooks()
        {
            foreach (var book in books)
            {
                if(book.Avaliable) Console.WriteLine($"Название: {book.Name} Автор: {book.Author}, Состояние: {book.Condition}%");
            }
            Console.WriteLine();
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
