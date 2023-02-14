using System.ComponentModel.DataAnnotations;

namespace SimpleWordModels;
public class Card
{
    /// <list type="bullet">
    /// <item> Первичный ключ (целое неотрицательное число.) </item>
    /// <item> Первичный ключ записи в таблице. При сооздании коллекции генерируется автоматически. </item>
    /// <item> Примечание.
    /// Поле "Id" автоматически определяется как первичный ключ. </item>
    /// </list>
    public int Id{get; init;}



    /// <list type="bullet">
    /// <item> Слово или фраза на исходном языке. </item>
    /// <item> Может содержать не более 50 симоволов. </item>
    /// <item> Обязателен. </item>
    /// </list>
    [Required]
    [StringLength(50)]
    public string? Word {get; set;}


    /// <summary> 
    /// Коллекция, содержащая данную карточку.
    /// </summary>
    [Required]
    public Collection? Collection {get; init;}

    /// <list type="bullet">
    /// <item> Комментарий автора коллекции к данной карточке. </item>
    /// <item> Может содержать не более 500 симоволов. </item>
    /// <item> Не обязателен. </item>
    /// </list>
    [StringLength(500)]
    public string? Comment {get; set;}


    public List<Translation> Translations { get; set; } = new();
}
