

namespace Biblioteque
{
    /// <summary>
    /// Класс библиотекаря
    /// </summary>
    public class Librarian : User
    {
        public Librarian(string name, string password, int id) : base("Работник", name, password, id) { }
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
}

