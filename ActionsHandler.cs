using System;

namespace Biblioteque
{
    /// <summary>
    /// Обработка действий для пользователей
    /// </summary>
    public static class ActionsHandler
    {
        /// <summary>
        /// Обобщенный метод для обработки действий пользователя
        /// </summary>
        /// <typeparam name="T">Тип пользователя</typeparam>
        /// <param name="user">Пользователь</param>
        public static void UserActions<T>(T user) where T : User
        {
            if (user is Customer customer)
            {
                CustomerActions(customer);
            }
            else if (user is Librarian librarian)
            {
                LibrarianActions(librarian);
            }
            // Другие типы пользователей могут быть добавлены по мере необходимости.
            // else if (user is SomeOtherUserType otherUserType)
            // {
            //     SomeOtherUserTypeActions(otherUserType);
            // }
        }

        /// <summary>
        /// Опции доступные для читателя
        /// </summary>
        /// <param name="customer">Читатель</param>
        private static void CustomerActions(Customer customer)
        {
            BookSearch bookSearch = new();
            Console.WriteLine("Ваши опции:");
            Console.WriteLine("1. Взять книгу");
            Console.WriteLine("2. Вернуть книгу");
            Console.WriteLine("3. Посмотреть взятые книги");
            Console.WriteLine("4. Выйти");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Какую именно книгу вы хотите взять?");
                    Biblioteque.DisplayAllAvaliableBooks();
                    string bookNameToTake = Console.ReadLine();
                    customer.GetBook(bookSearch.SearchByName(Biblioteque.books, bookNameToTake)[0]);
                    break;
                case "2":
                    Console.WriteLine("Какую именно книгу вы хотите вернуть?");
                    customer.GetCustomerBooks();
                    string bookToReturn = Console.ReadLine();
                    customer.ReturnBook(bookSearch.SearchByName(Biblioteque.books, bookToReturn)[0]);
                    break;
                case "3":
                    customer.GetCustomerBooks();
                    break;
                case "4":
                    Console.WriteLine("Вы вышли из аккаунта");
                    Program.flag = true;
                    break;
                    
                default:
                    Console.WriteLine("Некорректный выбор. Пожалуйста, выберите снова.");
                    break;
            }
        }

        /// <summary>
        /// Обработка действий для библиотекаря
        /// </summary>
        /// <param name="librarian">Библиотекарь</param>
        private static void LibrarianActions(Librarian librarian)
        {
            Console.WriteLine("Ваши опции:");
            Console.WriteLine("1. Добавить книгу");
            Console.WriteLine("2. Посмотреть все книги");
            Console.WriteLine("3. Посмотреть всех пользователей");
            Console.WriteLine("4. Выйти");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Введите данные книги, которую хотите добавить");
                    Console.WriteLine("Название:");
                    string name = Console.ReadLine();
                    Console.WriteLine("Автор:");
                    string author = Console.ReadLine();
                    Console.WriteLine("Состояние:");
                    double condition;
                    double.TryParse(Console.ReadLine(), out condition);
                    Book book = new(name, author, condition, true);
                    librarian.AddBook(book);
                    break;
                case "2":
                    Biblioteque.DisplayAllBooks();
                    break;
                case "3":
                    Biblioteque.DisplayAllUsers();
                    break;
                case "4":
                    Console.WriteLine("Вы вышли из аккаунта");
                    Program.flag = true;
                    return;
                default:
                    Console.WriteLine("Некорректный выбор. Пожалуйста, выберите снова.");
                    break;
            }
        }
    }
}
