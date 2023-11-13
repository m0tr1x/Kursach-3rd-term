
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
