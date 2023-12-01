using System;


namespace Biblioteque
{
    public class ActionsHandler
    {
        private MessagesToUser _messagesToUser { get; set; }
        private AuthHandler _authHandler { get; set; }

        public ActionsHandler(MessagesToUser messagesToUser, AuthHandler authHandler)
        {
            _messagesToUser = messagesToUser;
            _authHandler = authHandler;
        }
        

        public void SetUserActions<T>(T? user) where T : User
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
        /// <param name="customer"><Экземпляр пользователя</param>
        private void CustomerActions(Customer customer)
        {
            _messagesToUser.SendCustomerText();

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
                    _messagesToUser.SendErr();
                    break;
            }
        }

        

        /// <summary>
        /// Действия для работника
        /// </summary>
        /// <param name="librarian">Экземпляр работника</param>
        private void LibrarianActions(Librarian librarian)
        {
            _messagesToUser.SendLibrarianActions();

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    AddBook(librarian);
                    break;
                case "2":
                    _messagesToUser.DisplayAllBooks();
                    break;
                case "3":
                    _messagesToUser.DisplayAllUsers();
                    break;
                case "4":
                    ExitAccount();
                    break;
                default:
                    _messagesToUser.SendErr();
                    break;
            }
        }

       


        private void AdminActions(Admin admin)
        {
            _messagesToUser.SendAdminActions();

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    AddNewLibrarian();
                    break;
                case "2":
                    ExitAccount();
                    break;
                default:
                    _messagesToUser.SendErr();
                    break;
            }
        }

        

        /// <summary>
        /// Метод для взятия книги пользователем
        /// </summary>
        /// <param name="customer"></param>
        private void TakeBook(Customer customer)
        {
            if (_messagesToUser.DisplayAllAvaliableBooks() == 0)
            {
                _messagesToUser.SendEmptyBooks();
                return;
            };
            _messagesToUser.GetBookName();
            string bookNameToTake = Console.ReadLine().Trim();
            BookSearch searcher = new();
            List<Book> theoryBooks = searcher.SearchByName(Biblioteque.books, bookNameToTake);
            if (theoryBooks.Count != 0) customer.GetBook(theoryBooks[0]);
            else _messagesToUser.SendEmptyBooks();
        }

        


        /// <summary>
        /// Метод для возвращения книги пользователем
        /// </summary>
        /// <param name="customer"></param>

        private void ReturnBook(Customer customer)
        {
            if(customer.GetCustomerBooks() == 0)
            {
                return;
            }
            _messagesToUser.GetBookName();
            string bookToReturn = Console.ReadLine();
            BookSearch searcher = new();
            List<Book> theoryBooks = searcher.SearchByName(Biblioteque.books, bookToReturn);
            if (theoryBooks.Count != 0) customer.ReturnBook(theoryBooks[0]);
            else _messagesToUser.SendEmptyBooks();
        }

        

        /// <summary>
        /// Метод для добавления книги в библиотеку
        /// </summary>
        /// <param name="librarian"></param>
        private void AddBook(Librarian librarian)
        {
           
            _messagesToUser.GetBookName();
            string name = Console.ReadLine();
            _messagesToUser.GetAuthorName();
            string author = Console.ReadLine();
            _messagesToUser.GetCondition();
            double condition;
            double.TryParse(Console.ReadLine(), out condition);
            Book book = new(name, author, condition);
            librarian.AddBook(book);
        }
        /// <summary>
        /// Метод для добавления нового работника
        /// </summary>
        /// <param name="admin"></param>
        private void AddNewLibrarian()
        {
            _messagesToUser.GetName();
            string? workername = Console.ReadLine();
            _authHandler.Register(workername);
        }

        

        private void ExitAccount()
        {
            _messagesToUser.SendExitAccountMessage();
            Boostraper.exitAccount = true;
        }

        
    }

}
