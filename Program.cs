﻿/// <summary>
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
    public List<User> LoadUsers(string filePath)
    {
        List<User> users = new List<User>();

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
    public List<Book> LoadBooks(string filePath)
    {
        List<Book> books = new List<Book>();

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
    public void SaveUsers(List<User> users, string filePath)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (User user in users)
                {
                    writer.WriteLine($"{user.Name},{user.Role}");
                }
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
    public void SaveBooks(List<Book> books, string filePath)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (Book book in books)
                {
                    writer.WriteLine($"{book.Name},{book.Author},{book.Condition},{book.Avaliable}");
                }
            }
        }
        catch (IOException e)
        {
            Console.WriteLine($"Ошибка сохранения файла: {e.Message}");
        }
    }
}


class Program
{
    static void Main()
    {

    }
}
