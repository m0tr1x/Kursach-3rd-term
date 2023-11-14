

namespace Biblioteque
{
    class Program
    {

        static void Main()
        {
            DataHandler.LoadData(); //Загружаем данные при старте программы
            AppDomain.CurrentDomain.ProcessExit += DataHandler.OnExit; // Подисываемся на событие закрытия приложения
            Console.WriteLine("Добро пожаловать в библиотеку");
            User currentUser = null;
            //Смотрим логнился ли пользователь
            
                while (true)
                {
                if (currentUser == null)
                {
                    Console.WriteLine("Выберите действие:");
                    Console.WriteLine("1. Войти");
                    Console.WriteLine("2. Зарегистрироваться");
                    Console.WriteLine("3. Выйти из программы");

                    string choice = Console.ReadLine();//Выбор действия
                                                       //Перебираем варианты
                    switch (choice)
                    {
                        case "1":
                            //Логинимся
                            currentUser = AuthHandler.Login();
                            if (currentUser == null) break;
                            else
                            {
                                ActionsHandler.UserActions(currentUser);
                            }
                            break;
                        //Регистрация
                        case "2":
                            AuthHandler.Register();
                            break;
                        //Выход
                        case "3":
                            Console.WriteLine("До свидания!");
                            return;
                        default:
                            Console.WriteLine("Некорректный выбор. Пожалуйста, выберите снова.");
                            break;
                    }
                }
                // Пользователь залогинен, выполняем его действия
                else ActionsHandler.UserActions(currentUser);


            }

        }
    }
}

