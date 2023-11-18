using System;


namespace Biblioteque
{
	public class WholeSystem
	{
        public static bool exitAccount = false;
        private bool programRunning = true; // Костыль, чтобы выход корректно работал
        private User currentUser = null;

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
                    ActionsHandler.UserActions(currentUser);
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
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1. Войти");
            Console.WriteLine("2. Зарегистрироваться");
            Console.WriteLine("3. Выйти из программы");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    currentUser = AuthHandler.Login();
                    if (currentUser != null)
                    {
                        ActionsHandler.UserActions(currentUser);
                    }
                    break;
                case "2":
                    AuthHandler.Register();
                    break;
                case "3":
                    Console.WriteLine("До свидания!");
                    programRunning = false;
                    break;
                default:
                    Console.WriteLine("Некорректный выбор. Пожалуйста, выберите снова.");
                    break;
            }
        }
    }
}

