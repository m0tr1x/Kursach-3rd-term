
/// <summary>
/// Класс библиотеки
/// </summary>
static class Biblioteque
{
    public static List<Book> books = new ();
    public static List<User> users = new ();
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
            Console.WriteLine($"Book: {book.Name} by {book.Author}, Condition: {book.Condition}, Available: {(book.Avaliable ? "Yes" : "No")}");
        }
        Console.WriteLine();
    }
    /// <summary>
    /// Метод для добавления пользователя в библиотеку
    /// </summary>
    /// <param name="user">Экземпляр пользователя</param>
    public static void AddUserToLibrary(User user)
    {
        users.Add(user);
    }
}
