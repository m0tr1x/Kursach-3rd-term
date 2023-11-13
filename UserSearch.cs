
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
    public  List<User> SearchByName(List<User> users, string name)
    {
        List<User> foundUsers = users.Where(user => user.Name.ToLower().Contains(name.ToLower())).ToList();
        return foundUsers;
    }

    public static List<User> SearchByRole(List<User> users, string role)
    {
        List<User> foundUsers = users.Where(user => user.Role.ToLower() == role.ToLower()).ToList();
        return foundUsers;
    }
}
