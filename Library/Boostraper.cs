using System;


namespace Biblioteque
{
	public class Boostraper
	{
        public static bool exitAccount = false;
        private bool programRunning = true; // Костыль, чтобы выход корректно работал
        private User? currentUser = null;
        private MessagesToUser _messagesToUser;
        private AuthHandler _authHandler;
        private ActionsHandler _actionsHandler;

        public Boostraper()
        {
            _messagesToUser = new MessagesToUser();
            _authHandler = new AuthHandler(_messagesToUser);
            _actionsHandler = new ActionsHandler(_messagesToUser, _authHandler);
        }

        /// <summary>
        /// Метод для запуска логики
        /// </summary>
        public void Run()
        {
            DataHandler.LoadData();
            AppDomain.CurrentDomain.ProcessExit += DataHandler.OnExit; //Подписываемся на событие выхода

            Console.WriteLine("Добро пожаловать в библиотеку");

            while (programRunning)
            {
                if (currentUser == null)
                {
                    HandleGuestActions();
                }
                else if (!exitAccount)
                {
                    _actionsHandler.SetUserActions(currentUser);
                }
                else
                {
                    currentUser = null;
                }
            }
        }

        /// <summary>
        /// Обрабатываем действия неавторизованного гостя
        /// </summary>
        private void HandleGuestActions()
        {
            
            _messagesToUser.SendUnauthorizedGuestMessages();

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    currentUser = _authHandler.Login();
                    if (currentUser != null)
                    {
                        _actionsHandler.SetUserActions(currentUser);
                    }
                    break;
                case "2":
                    _authHandler.Register();
                    break;
                case "3":
                    _messagesToUser.SendGoodbye();
                    programRunning = false;
                    break;
                default:
                    _messagesToUser.SendErr();
                    break;
            }
        }

        
    }
}

