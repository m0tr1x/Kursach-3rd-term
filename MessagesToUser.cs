namespace Biblioteque;
/// <summary>
/// Класс для общения с пользователем
/// </summary>
public class MessagesToUser
{
    internal void SendCustomerText()
    {
        Console.WriteLine("Ваши опции:");
        Console.WriteLine("1. Взять книгу");
        Console.WriteLine("2. Вернуть книгу");
        Console.WriteLine("3. Посмотреть взятые книги");
        Console.WriteLine("4. Выйти");
    }
    internal void SendLibrarianActions()
    {
        Console.WriteLine("Ваши опции:");
        Console.WriteLine("1. Добавить книгу");
        Console.WriteLine("2. Посмотреть все книги");
        Console.WriteLine("3. Посмотреть всех пользователей");
        Console.WriteLine("4. Выйти");
    }
    
    internal void SendAdminActions()
    {
        Console.WriteLine("Ваши опции:");
        Console.WriteLine("1. Добавить работника");
        Console.WriteLine("2. Выйти");
    }
    internal void SendErr()
    {
        Console.WriteLine("Некорректный выбор. Пожалуйста, выберите снова.");
    }
    internal  void SendUnauthorizedGuestMessages()
    {
        Console.WriteLine("1. Войти");
        Console.WriteLine("2. Зарегистрироваться");
        Console.WriteLine("3. Выйти из программы");
    }
    internal void SendExitAccountMessage()
    {
        Console.WriteLine("Вы вышли из аккаунта");
    }
    internal void GetUsername()
    {
        Console.WriteLine("Введите имя нового работника");
    }
    internal void GetBookName()
    {
        Console.WriteLine("Какую именно книгу вы хотите взять?");
    }
    internal void SendGoodbye()
    {
        Console.WriteLine("До свидания!");
    }
    internal  void SendEmptyBooks()
    {
        Console.WriteLine("Книг нет");
    }
    internal void GetPassword()
    {
        Console.WriteLine("Введите пароль:");
    }

    internal void GetIdFromUser()
    {
        Console.WriteLine("Введите ваш id");
    }
    internal void GetName()
    {
        Console.WriteLine("Введите имя:");
    }
    internal void SendOK()
    {
        Console.WriteLine("Регистрация успешна!");
    }

    internal void GetAuthorName()
    {
        Console.WriteLine("Введите имя автора");
    }

    internal void GetCondition()
    {
        Console.WriteLine("Введите состояние книги");
    }

    internal void SendAuthErr()
    {
       Console.WriteLine("Вы ввели неверный логин или пароль");
    }
    /// <summary>
    /// Метод для вывода всех пользователей
    /// </summary>
    internal void DisplayAllUsers()
    {
        foreach (var user in Biblioteque.users)
        {
            Console.WriteLine($"Id: {user.Id} Name: {user.Name} ({user.Role})");
        }
        Console.WriteLine();
    }
    /// <summary>
    /// Метод для вывода всех книг
    /// </summary>
    internal void DisplayAllBooks()
    {
        foreach (var book in Biblioteque.books)
        {
            Console.WriteLine($"Название: {book.Name} Автор: {book.Author}, Состояние: {book.Condition}%, В наличии: {(book.Owner == 0 ? "Да" : "Нет")}");
        }
        Console.WriteLine();
    }

    internal void SayHello(string foundUserName)
    {
        Console.WriteLine($"Успешный вход, здравствуйте! {foundUserName}");
    }
    /// <summary>
    /// Метод для возвращения и вывода всех доступных книг
    /// </summary>
    /// <returns></returns>
    internal int DisplayAllAvaliableBooks()
    {
        foreach (var book in Biblioteque.books)
        {
            if(book.Owner ==0) Console.WriteLine($"Название: {book.Name} Автор: {book.Author}, Состояние: {book.Condition}%");
        }
        Console.WriteLine();
        return Biblioteque.books.Where(book => book.Owner ==0).ToList().Count;
    }
}