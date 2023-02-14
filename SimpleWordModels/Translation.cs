using System.ComponentModel.DataAnnotations;

namespace SimpleWordModels;

public class Translation{
    /// <list type="bullet">
    /// <item> Первичный ключ (целое неотрицательное число.) </item>
    /// <item> Первичный ключ записи в таблице. При сооздании коллекции генерируется автоматически. </item>
    /// <item> Примечание.
    /// Поле "Id" автоматически определяется как первичный ключ. </item>
    /// </list>
    public int Id{get; init;}


    /// <summary>
    /// Карточка, к которой относится перевод.
    /// </summary>
    [Required]
    public Card? Card {get; init;}


    /// <list type="bullet">
    /// <item> Вариант перевода для соответвующего слова. </item>
    /// <item> Может содержать не более 50 символов. </item>
    /// </list>
    [Required]
    [StringLength(50)]
    public string? Value {get; set;}


    /// <list type="bullet">
    /// <item> Комментарий автора коллекции к данному варианту перевода. </item>
    /// <item> Может содержать не более 500 символов. </item>
    /// </list>
    [StringLength(500)]
    public string? Comment {get; set;}


    /// <list type="bullet">
    /// <item> Все примеры использования, относящиеся к данному переводу. </item>
    /// <item> Отношение "один ко многим" </item>
    /// </list>
    public List<Example> Examples {get; set;} = new();

}