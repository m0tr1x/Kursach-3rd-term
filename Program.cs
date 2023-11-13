

namespace Biblioteque
{
    class Program
    {

        static void Main()
        {
            DataHandler.LoadData(); //Загружаем данные при старте программы
            AppDomain.CurrentDomain.ProcessExit += DataHandler.OnExit; // Подисываемся на событие закрытия приложения
        }
    }
}

