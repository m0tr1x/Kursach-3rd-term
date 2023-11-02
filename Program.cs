/// <summary>
/// Класс книги 
/// </summary>
class Book
{
    private string? _name;
    private string? _author;
    private double _condition;
    // Название книги
    public string? Name
    {
        get { return _name; }
        set { if (value != null) _name = value; }
    }
    // Автор книги
    public string? Author
    {
        get { return _author; }
        set { if (value != null) _author = value; }
    }

    // Состояние книги
    public double Condition
    {
        get { return _condition; }
        set
        {
            if (value > 0 && value <= 100) _condition = value;
        }
    }
    // Наличие книги
    public bool Avaliable { get; set; }
    public void MarkAsTaken()
    {
        this.Avaliable = false;
        Condition -= 1;
    }

    public void MarkAsReturned()
    {
        this.Avaliable = true;
    }

    public Book(string Name, string Author, double Condition, bool Avaliable)
    {
        this.Name = Name;
        this.Author = Author;
        this.Condition = Condition;
        this.Avaliable = Avaliable;
    }

}


/// <summary>
/// Абстрактный класс для пользователя, который может быть либо работником, либо читателем
/// </summary>
abstract class User
{
    // Поле для хранения роли пользователя
    public string Role { get; }

    // ФИО пользователя
    private string _name;
    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    // Конструктор класса User
    public User(string role, string name)
    {
        Role = role;
        Name = name;
    }
}
/// <summary>
/// Читатель
/// </summary>
class Customer : User
{
    private List<Book> _takenBooks;
    public Customer(string name) : base("Читатель", name) { _takenBooks = new List<Book>(); }
    /// <summary>
    /// Метод для взятия книги в библиотеке
    /// </summary>
    /// <param name="book"> экземпляр книги</param>
    public void GetBook(Book book)
    {
        if (book.Avaliable)
        {
            _takenBooks.Add(book);
            book.MarkAsTaken();
            Console.WriteLine($"{Name} взял книгу: {book.Name} от {book.Author}");
        }
        else
        {
            Console.WriteLine($"Книга \"{book.Name}\" недоступна в данный момент.\n");
        }
    }
    /// <summary>
    /// Метод для возвращения книги назад
    /// </summary>
    /// <param name="book"></param>
    public void ReturnBook(Book book)
    {
        if (_takenBooks.Contains(book))
        {
            _takenBooks.Remove(book);
            book.MarkAsReturned();
            Console.WriteLine($"{Name} вернул книгу: {book.Name} от {book.Author}\n");
        }
        else
        {
            Console.WriteLine($"Книга \"{book.Name}\" не была взята вами.\n");
        }
    }
}

class Librarian : User
{
    public Librarian(string name) : base("Работник", name) { }
    /// <summary>
    /// Метод для добавление книги со стороны работника
    /// </summary>
    /// <param name="example"> Экземпляр книги</param>
    public void AddBook(Book book)
    {
        Biblioteque.AddBookToLibrary(book);
        Console.WriteLine($"{Name} добавил книгу \"{book.Name}\" в библиотеку\n");
    }


}

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
/// <summary>
/// Класс для сохранения и загрузки пользователей и книг
/// </summary>
class Repository
{
    /// <summary>
    /// Метод для загрузки пользователей
    /// </summary>
    /// <param name="filePath">Путь к файлу</param>
    /// <returns></returns>
    public static List<User> LoadUsers(string filePath)
    {
        List<User> users = new ();

        try
        {
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                string[] userData = line.Split(',');

                string name = userData[0];
                string role = userData[1];

                if (role == "Читатель")
                {
                    users.Add(new Customer(name));
                }
                else if (role == "Работник")
                {
                    users.Add(new Librarian(name));
                }
            }
        }
        catch (IOException e)
        {
            Console.WriteLine($"Ошибка чтения файла: {e.Message}");
        }

        return users;
    }
    /// <summary>
    /// Метод для загрузки списка книг из файлов
    /// </summary>
    /// <param name="filePath">Путь к файлу</param>
    /// <returns></returns>
    public static List<Book> LoadBooks(string filePath)
    {
        List<Book> books = new ();

        try
        {
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                string[] bookData = line.Split(',');

                string name = bookData[0];
                string author = bookData[1];
                double condition = double.Parse(bookData[2]);
                bool available = bool.Parse(bookData[3]);

                books.Add(new Book(name, author, condition, available));
            }
        }
        catch (IOException e)
        {
            Console.WriteLine($"Ошибка чтения файла: {e.Message}");
        }

        return books;
    }
    /// <summary>
    /// Метод для сохранения пользователей в файл
    /// </summary>
    /// <param name="users"> Список пользователей</param>
    /// <param name="filePath">Путь к файлу</param>
    public static void SaveUsers(List<User> users, string filePath)
    {
        try
        {
            using StreamWriter writer = new(filePath);
            foreach (User user in Biblioteque.users)
            {
                writer.WriteLine($"{user.Name},{user.Role}");
            }
        }
        catch (IOException e)
        {
            Console.WriteLine($"Ошибка сохранения файла: {e.Message}");
        }
    }
    /// <summary>
    /// Метод для сохранения списка книг в файл
    /// </summary>
    /// <param name="books">Список книг</param>
    /// <param name="filePath">Путь к файлу</param>
    public static void SaveBooks(List<Book> books, string filePath)
    {
        try
        {
            using StreamWriter writer = new(filePath);
            foreach (Book book in Biblioteque.books)
            {
                writer.WriteLine($"{book.Name},{book.Author},{book.Condition},{book.Avaliable}");
            }
        }
        catch (IOException e)
        {
            Console.WriteLine($"Ошибка сохранения файла: {e.Message}");
        }
    }
}

/// <summary>
/// Интерфейс для поиска
/// </summary>
/// <typeparam name="T">Тип данных</typeparam>
interface ISearchable<T>
{
    /// <summary>
    /// Метод для поиска по имени
    /// </summary>
    /// <param name="items">Список с данными</param>
    /// <param name="result">Нужный результат</param>
    /// <returns></returns>
     List<T> SearchByName(List<T> items, string result);
}
/// <summary>
/// Класс для поиска книг
/// </summary>
class BookSearch : ISearchable<Book>
{
    /// <summary>
    /// Реализуем интерфейс для поиска по имени
    /// </summary>
    /// <param name="users">Список </param>
    /// <param name="name">Требуемое имя</param>
    /// <returns></returns>
    public   List<Book> SearchByName(List<Book> books, string title)
    {
        List<Book> foundBooks = books.Where(book => book.Name.Contains(title)).ToList();
        return foundBooks;
    }

    public static List<Book> SearchByAuthor(List<Book> books, string author)
    {
        List<Book> foundBooks = books.Where(book => book.Author.Contains(author)).ToList();
        return foundBooks;
    }

}
/// <summary>
/// Класс для поиска пользователей
/// </summary>
class UserSearch : ISearchable<User>
{
    /// <summary>
    /// Реализуем интерфейс для поиска по имени
    /// </summary>
    /// <param name="users">Список </param>
    /// <param name="name">Требуемое имя</param>
    /// <returns></returns>
    public  List<User> SearchByName(List<User> users, string name)
    {
        List<User> foundUsers = users.Where(user => user.Name.ToLower().Contains(name.ToLower())).ToList();
        return foundUsers;
    }

    public static List<User> SearchByRole(List<User> users, string role)
    {
        List<User> foundUsers = users.Where(user => user.Role.ToLower() == role.ToLower()).ToList();
        return foundUsers;
    }
}

class Program
{
    static List<User> users;
    static List<Book> books;

    /// <summary>
    /// Метод для загрузки даных
    /// </summary>
    static void LoadData()
    {
        Biblioteque.users = Repository.LoadUsers("users.txt");
        Biblioteque.books = Repository.LoadBooks("books.txt");
    }
    /// <summary>
    /// Метод для обновления данных
    /// </summary>
    static void UpdateData()
    {
        Repository.SaveUsers(users, "users.txt");
        Repository.SaveBooks(books, "books.txt");
    }
    /// <summary>
    /// Событие, которое при выходе из программы обновляет списки
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    static void OnExit(object sender, EventArgs e)
    {
        UpdateData(); // Обновление данных при закрытии программы
    }

    /// <summary>
    /// Событие для старта программы
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    static void OnStart(object sender, EventArgs e)
    {
        LoadData(); // Загружаем данные при запуске программы
    }
    static void Main()
    {
        LoadData(); //Загружаем данные при старте программы
        AppDomain.CurrentDomain.ProcessExit += OnExit; // Подисываемся на событие закрытия приложения
        User userToAdd = new Customer("Михаил Закарян");
        Biblioteque.AddUserToLibrary(userToAdd);



        // Вывод пользователей на экран
        Console.WriteLine("Список пользователей:");
        Biblioteque.DisplayAllUsers();
        // Вывод книг на экран
        Console.WriteLine("\nСписок книг:");
        Biblioteque.DisplayAllBooks();

        // Пример использования функциональности:
        Customer customer = (Customer)Biblioteque.users.FirstOrDefault(u => u.Role == "Читатель");
        if (customer != null)
        {
            customer.GetBook(Biblioteque.books.FirstOrDefault(b => b.Name == "Война и мир"));
            customer.ReturnBook(Biblioteque.books.FirstOrDefault(b => b.Name == "Преступление и наказание"));
        }
        else
        {
            Console.WriteLine($"Читатель {customer.Name} не найден.");
        }

        Librarian librarian = (Librarian)Biblioteque.users.FirstOrDefault(u => u.Role == "Работник");
        if (librarian != null)
        {
            librarian.AddBook(new Book("Новая книга", "Новый автор", 70, true));
        }
        else
        {
            Console.WriteLine($"Работник  {librarian.Name} не найден.");
        }
    }
}
