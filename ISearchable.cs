
/// <summary>
/// Интерфейс для поиска
/// </summary>
/// <typeparam name="T">Тип данных</typeparam>
interface ISearchable<T>
{
    /// <summary>
    /// Метод для поиска по имени
    /// </summary>
    /// <param name="items">Список с данными</param>
    /// <param name="result">Нужный результат</param>
    /// <returns></returns>
     List<T> SearchByName(List<T> items, string result);
}
