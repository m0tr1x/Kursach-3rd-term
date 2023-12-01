using System;
using System.Collections.Generic;
namespace Biblioteque
{
	public static class DataHandler
	{


        /// <summary>
        /// Метод для загрузки данных
        /// </summary>
        public static void LoadData()
        {
            Biblioteque.books = Repository.LoadBooks("books.txt");
            Biblioteque.users = Repository.LoadUsers("users.txt");
        }

        /// <summary>
        /// Метод для обновления данных
        /// </summary>
        public static void UpdateData()
        {
            Repository.SaveUsers(Biblioteque.users, "users.txt");
            Repository.SaveBooks(Biblioteque.books, "books.txt");
        }

        /// <summary>
        /// Событие, которое при выходе из программы обновляет списки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void OnExit(object sender, EventArgs e)
        {
            UpdateData(); // Обновление данных при закрытии программы
        }

    }
}

