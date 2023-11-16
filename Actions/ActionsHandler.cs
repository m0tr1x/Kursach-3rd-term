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
        public static void UserActions<T>(T user,bool exitWish) where T : User
        {
            if (user is Customer customer)
            {
                CustomerActions(customer, exitWish);
            }
            else if (user is Librarian librarian)
            {
                LibrarianActions(librarian, exitWish);
            }
            // Другие типы пользователей могут быть добавлены по мере необходимости.
            else if (user is Admin admin)
            {
                 AdminActions(admin, exitWish);
            }
        }

        /// <summary>
        /// Опции доступные для читателя
        /// </summary>
        /// <param name="customer">Читатель</param>
        private static void CustomerActions(Customer customer, bool exitWish)
        {
            BookSearch bookSearch = new();
            Console.WriteLine("Ваши опции:");
            Console.WriteLine("1. Взять книгу");
            Console.WriteLine("2. Вернуть книгу");
            Console.WriteLine("3. Посмотреть взятые книги");
            Console.WriteLine("4. Выйти");

            string choice = Console.ReadLine();
            List<Book> theoryBooks;
            //Перебираем варианты действий для пользователя
            switch (choice)
            {
                //Взятие книги
                case "1":
                    Console.WriteLine("Какую именно книгу вы хотите взять?");
                    Biblioteque.DisplayAllAvaliableBooks();
                    string bookNameToTake = Console.ReadLine();
                    theoryBooks = bookSearch.SearchByName(Biblioteque.books, bookNameToTake);
                    if (theoryBooks.Count != 0) customer.GetBook(theoryBooks[0]);
                    else Console.WriteLine("Такой книги нет");
                    break;
                //Возвращение книги
                case "2":
                    Console.WriteLine("Какую именно книгу вы хотите вернуть?");
                    customer.GetCustomerBooks();
                    string bookToReturn = Console.ReadLine();
                    theoryBooks = bookSearch.SearchByName(Biblioteque.books, bookToReturn);
                    if (theoryBooks.Count != 0) customer.ReturnBook(theoryBooks[0]);
                    else Console.WriteLine("У вас нет такой книги");
                    break;
                //Вывод всех книг пользователя
                case "3":
                    customer.GetCustomerBooks();
                    break;
                //Выход
                case "4":
                    Console.WriteLine("Вы вышли из аккаунта");
                    exitWish = true;
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
        private static void LibrarianActions(Librarian librarian, bool exitWish)
        {
            Console.WriteLine("Ваши опции:");
            Console.WriteLine("1. Добавить книгу");
            Console.WriteLine("2. Посмотреть все книги");
            Console.WriteLine("3. Посмотреть всех пользователей");
            Console.WriteLine("4. Выйти");

            string choice = Console.ReadLine();
            //Перебираем варианты действий для библиотекаря
            switch (choice)
            {
                //Добавление книги
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
                //Выводим на экран все книги в ней
                case "2":
                    Biblioteque.DisplayAllBooks();
                    break;
                //Выводим на экран всех пользователей
                case "3":
                    Biblioteque.DisplayAllUsers();
                    break;
                //Выходим
                case "4":
                    Console.WriteLine("Вы вышли из аккаунта");
                   
                    break;
                default:
                    Console.WriteLine("Некорректный выбор. Пожалуйста, выберите снова.");
                    break;
            }
        }
        private static void AdminActions(Admin admin, bool exitWish)
        {
            Console.WriteLine("Ваши опции:");
            Console.WriteLine("1. Добавить работника");
            Console.WriteLine("2. Выйти");
            string choice = Console.ReadLine();
            //Перебираем варианты действий для admina
            switch (choice)
            {
                //Добавляем учетку для нового работника
                case "1":
                    Console.WriteLine("Введите имя нового работника");
                    string name = Console.ReadLine().Trim();
                    admin.AddNewLibrarian(name);
                    break;
                //Выходим
                case "2":
                    Console.WriteLine("Вы вышли из аккаунта");
                    break;
                default:
                    Console.WriteLine("Некорректный выбор. Пожалуйста, выберите снова.");
                    break;
            }
        }
    }
}
