

namespace Biblioteque
{
    class Program
    {

        static void Main()
        {
            DataHandler.LoadData(); //Загружаем данные при старте программы
            AppDomain.CurrentDomain.ProcessExit += DataHandler.OnExit; // Подисываемся на событие закрытия приложения
            Console.WriteLine("Добро пожаловать в библиотеку");
            while(true)
            {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Войти");
                Console.WriteLine("2. Зарегистрироваться");
                Console.WriteLine("3. Выйти из программы");

                string choice = Console.ReadLine();//Выбор действия

                switch (choice)
                {
                    case "1":
                        AuthHandler.Login();
                        break;
                    case "2":
                        AuthHandler.Register();
                        break;
                    case "3":
                        Console.WriteLine("До свидания!");
                        return;
                    default:
                        Console.WriteLine("Некорректный выбор. Пожалуйста, выберите снова.");
                        break;
                }
            }
        }
    }
}

