using System;


namespace Biblioteque
{
    public static class ActionsHandler
    {

        public static void UserActions<T>(T? user) where T : User
        {
            switch (user)
            {
                case Customer customer:
                    CustomerActions(customer);
                    break;
                case Librarian librarian:
                    LibrarianActions(librarian);
                    break;
                case Admin admin:
                    AdminActions(admin);
                    break;
            }
        }
        /// <summary>
        /// Действия для пользователя
        /// </summary>
        /// <param name="customer"><Экземпляр пользователя/param>
        private static void CustomerActions(Customer customer)
        {
            Console.WriteLine("Ваши опции:");
            Console.WriteLine("1. Взять книгу");
            Console.WriteLine("2. Вернуть книгу");
            Console.WriteLine("3. Посмотреть взятые книги");
            Console.WriteLine("4. Выйти");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    TakeBook(customer);
                    break;
                case "2":
                    ReturnBook(customer);
                    break;
                case "3":
                    customer.GetCustomerBooks();
                    break;
                case "4":
                    ExitAccount();
                    break;
                default:
                    Console.WriteLine("Некорректный выбор. Пожалуйста, выберите снова.");
                    break;
            }
        }
        /// <summary>
        /// Действия для работника
        /// </summary>
        /// <param name="librarian">Экземпляр работника</param>
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
                    AddBook(librarian);
                    break;
                case "2":
                    Biblioteque.DisplayAllBooks();
                    break;
                case "3":
                    Biblioteque.DisplayAllUsers();
                    break;
                case "4":
                    ExitAccount();
                    break;
                default:
                    Console.WriteLine("Некорректный выбор. Пожалуйста, выберите снова.");
                    break;
            }
        }

        private static void AdminActions(Admin admin)
        {
            Console.WriteLine("Ваши опции:");
            Console.WriteLine("1. Добавить работника");
            Console.WriteLine("2. Выйти");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    AddNewLibrarian(admin);
                    break;
                case "2":
                    ExitAccount();
                    break;
                default:
                    Console.WriteLine("Некорректный выбор. Пожалуйста, выберите снова.");
                    break;
            }
        }

        /// <summary>
        /// Метод для взятия книги пользователем
        /// </summary>
        /// <param name="customer"></param>
        private static void TakeBook(Customer customer)
        {
            if (Biblioteque.DisplayAllAvaliableBooks() == 0)
            {
                Console.WriteLine("Доступных книг нет");
                return;
            };
            Console.WriteLine("Какую именно книгу вы хотите взять?");
            string bookNameToTake = Console.ReadLine().Trim();
            BookSearch searcher = new();
            List<Book> theoryBooks = searcher.SearchByName(Biblioteque.books, bookNameToTake);
            if (theoryBooks.Count != 0) customer.GetBook(theoryBooks[0]);
            else Console.WriteLine("Такой книги нет");
        }
        /// <summary>
        /// Метод для возвращения книги пользователем
        /// </summary>
        /// <param name="customer"></param>

        private static void ReturnBook(Customer customer)
        {
            if(customer.GetCustomerBooks() == 0)
            {
                return;
            }
            Console.WriteLine("Какую именно книгу вы хотите вернуть?");
            string bookToReturn = Console.ReadLine();
            BookSearch searcher = new();
            List<Book> theoryBooks = searcher.SearchByName(Biblioteque.books, bookToReturn);
            if (theoryBooks.Count != 0) customer.ReturnBook(theoryBooks[0]);
            else Console.WriteLine("У вас нет такой книги");
        }

        /// <summary>
        /// Метод для добавления книги в библиотеку
        /// </summary>
        /// <param name="librarian"></param>
        private static void AddBook(Librarian librarian)
        {
            Console.WriteLine("Введите данные книги, которую хотите добавить");
            Console.WriteLine("Название:");
            string name = Console.ReadLine();
            Console.WriteLine("Автор:");
            string author = Console.ReadLine();
            Console.WriteLine("Состояние:");
            double condition;
            double.TryParse(Console.ReadLine(), out condition);
            Book book = new(name, author, condition);
            librarian.AddBook(book);
        }
        /// <summary>
        /// Метод для добавления нового работника
        /// </summary>
        /// <param name="admin"></param>
        private static void AddNewLibrarian(Admin admin)
        {
            Console.WriteLine("Введите имя нового работника");
            string name = Console.ReadLine().Trim();
            admin.AddNewLibrarian(name);
        }

        private static void ExitAccount()
        {
            Console.WriteLine("Вы вышли из аккаунта");
            WholeSystem.exitAccount = true;
        }
    }

}
