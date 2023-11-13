
/// <summary>
/// Абстрактный класс для пользователя, который может быть либо работником, либо читателем
/// </summary>
abstract class User
{
    // Поле для хранения роли пользователя
    public string Role { get; }

    // ФИО пользователя
    private string _name;
    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    // Конструктор класса User
    public User(string role, string name)
    {
        Role = role;
        Name = name;
    }
}
