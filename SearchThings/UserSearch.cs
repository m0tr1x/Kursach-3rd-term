namespace Biblioteque
{

    /// <summary>
    /// Класс для поиска пользователей
    /// </summary>
    class UserSearch : ISearchable<User>
    {
        /// <summary>
        /// Реализуем интерфейс для поиска по имени
        /// </summary>
        /// <param name="users">Список </param>
        /// <param name="name">Требуемое имя</param>
        /// <returns></returns>
        public List<User> SearchByName(List<User> users, string name)
        {
            List<User> foundUsers = users.Where(user => user.Name.ToLower().Contains(name.ToLower())).ToList();
            return foundUsers;
        }
        /// <summary>
        /// Метод для поиска пользователей по id
        /// </summary>
        /// <param name="users"></param>
        /// <param name="id"></param>
        /// <returns></returns>

        public User SearchById(List<User> users, int id)
        {
            return users.FirstOrDefault(user => (user.Id == id));
        }

        public static List<User> SearchByRole(List<User> users, string role)
        {
            List<User> foundUsers = users.Where(user => user.Role.ToLower() == role.ToLower()).ToList();
            return foundUsers;
        }
    }

}