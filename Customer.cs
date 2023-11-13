namespace Biblioteque
{
    /// <summary>
    /// Читатель
    /// </summary>
    class Customer : User
    {
        private List<Book> _takenBooks;
        public Customer(string name, string password) : base("Читатель", name, password) { _takenBooks = new List<Book>(); }
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

}