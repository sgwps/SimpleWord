using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SimpleWord.Models;

public class Example{
    /// <list type="bullet">
    /// <item> Первичный ключ (целое неотрицательное число.) </item>
    /// <item> Первичный ключ записи в таблице. При сооздании коллекции генерируется автоматически. </item>
    /// <item> Примечание.
    /// Поле "Id" автоматически определяется как первичный ключ. </item>
    /// </list>
    [Required]
    [JsonIgnore]
    public int Id{get; init;}

    /// <list type="bullet">
    /// <item> Экземпляр класса Word </item>
    /// </list>
    [Required]
    [JsonIgnore]
    public Translation? Translation {get; set;}

    string? origin;
    /// <list type="bullet">
    /// <item> Пример использования слова </item>
    /// <item> Может содержать не более 400 символов </item>
    /// </list>
    [Required]
    [StringLength(400)]
    public string? Origin{get; set; }

    string? translation;
    /// <list type="bullet">
    /// <item> Перевод данного примера </item>
    /// </list>
    [Required]
    [StringLength(400)]
    public string? ExampleTranslation{get; set;}

    /// <list type="bullet">
    /// <item> Комментарий автора коллекции к данному примеру использования. </item>
    /// <item> Может содержать не более 500 симоволов. </item>
    /// <item> Не обязателен. </item>
    /// </list>
    [StringLength(500)]
    public string? Comment {get; set;}

    /// <list type="bullet">
    /// <item> Источник, откуда взят пример </item>
    /// <item> Может содержать не более 200 символов </item>
    /// </list>
    [StringLength(200)]
    public string? Source{ get; set; }

}