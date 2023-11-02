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
    protected string Role { get; }

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
            Console.WriteLine("Книга недоступна в данный момент.");
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
            Console.WriteLine($"{Name} вернул книгу: {book.Name} от {book.Author}");
        }
        else
        {
            Console.WriteLine("Эта книга не была взята вами.");
        }
    }
}

class Librarian : User
{
    public Librarian(string name) : base("Работник",name) {}
    /// <summary>
    /// Метод для добавление книги со стороны работника
    /// </summary>
    /// <param name="example"> Экземпляр книги</param>
    public void AddBook(Book example)
    {
        Biblioteque.AddBookToLibrary(example);
        Console.WriteLine($"{Name} добавил книгу в библиотеку");
    }
    
    
}

/// <summary>
/// Класс библиотеки
/// </summary>
static class Biblioteque
{
    private static List<Book> books = new List<Book>();
    private static List<User> users = new List<User>();
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
}




class Program
{
    static void Main()
    {

    }
}
