using System;
using System.Collections.Generic;
using System.IO;

namespace Biblioteque
{
    /// <summary>
    /// Класс для сохранения и загрузки пользователей и книг
    /// </summary>
    class Repository
    {
        /// <summary>
        /// Метод для загрузки пользователей
        /// </summary>
        /// <param name="filePath">Путь к файлу</param>
        /// <returns></returns>
        public static List<User> LoadUsers(string filePath)
        {
            List<User> users = new();

            try
            {
                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    string[] userData = line.Split(',');

                    string name = userData[0];
                    string role = userData[1];
                    string password = userData[2];
                    int id = int.Parse(userData[3]);

                    if (role == "Читатель")
                    {
                        users.Add(new Customer(name, password,id));
                    }
                    else if (role == "Работник")
                    {
                        users.Add(new Librarian(name, password, id));
                    }
                    else if(role == "Администратор")
                    {
                        users.Add(new Admin(name,password,id));
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine($"Ошибка чтения файла: {e.Message}");
            }

            return users;
        }

        /// <summary>
        /// Метод для загрузки списка книг из файлов
        /// </summary>
        /// <param name="filePath">Путь к файлу</param>
        /// <returns></returns>
        public static List<Book> LoadBooks(string filePath)
        {
            List<Book> books = new();

            try
            {
                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    string[] bookData = line.Split(',');

                    string name = bookData[0];
                    string author = bookData[1];
                    double condition = double.Parse(bookData[2]);
                    int owner = int.Parse(bookData[3]);

                    books.Add(new Book(name, author, condition, owner));
                }
            }
            catch (IOException e)
            {
                Console.WriteLine($"Ошибка чтения файла: {e.Message}");
            }

            return books;
        }

        /// <summary>
        /// Метод для сохранения пользователей в файл
        /// </summary>
        /// <param name="users">Список пользователей</param>
        /// <param name="filePath">Путь к файлу</param>
        public static void SaveUsers(List<User> users, string filePath)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (User user in users)
                    {
                        writer.WriteLine($"{user.Name},{user.Role},{user.Password},{user.Id}");
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine($"Ошибка сохранения файла: {e.Message}");
            }
        }

        /// <summary>
        /// Метод для сохранения списка книг в файл
        /// </summary>
        /// <param name="books">Список книг</param>
        /// <param name="filePath">Путь к файлу</param>
        public static void SaveBooks(List<Book> books, string filePath)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (Book book in books)
                    {
                        writer.WriteLine($"{book.Name},{book.Author},{book.Condition}, {book.Owner}");
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine($"Ошибка сохранения файла: {e.Message}");
            }
        }
    }
}
