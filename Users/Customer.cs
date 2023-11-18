namespace Biblioteque
{
    /// <summary>
    /// Читатель
    /// </summary>
    public class Customer : User
    {
        private List<Book> _takenBooks;
        public Customer(string name, string password, int id) : base("Читатель", name, password, id) { UpdateBooks(); }
        /// <summary>
        /// Метод для взятия книги в библиотеке
        /// </summary>
        /// <param name="book"> экземпляр книги</param>


        public void UpdateBooks()
        {
            this._takenBooks = Biblioteque.books.Where(book => book.Owner == this.Id).ToList();
        }
        public void GetBook(Book book)
        {
            if (book.Owner == 0)
            {
                _takenBooks.Add(book);
                book.MarkAsTaken(this);
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
        /// <summary>
        /// Метод для того, чтобы узнать какие книги есть у пользователя
        /// </summary>
        public int GetCustomerBooks()
        {
            if(this._takenBooks.Count != 0)
            {
                foreach (var book in this._takenBooks)
                {
                    Console.WriteLine($"Книга: {book.Name} от {book.Author}");
                }
            }
            else
            {
                Console.WriteLine("У вас нет книг");
            }
            return _takenBooks.Count();

        }
    }

}