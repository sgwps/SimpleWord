using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleWordModels;

public class Collection {
    private static bool ValidateISO639Standart (string value) => throw new NotImplementedException();


    /// <list type="bullet">
    /// <item> Первичный ключ (целое неотрицательное число.) </item>
    /// <item> Первичный ключ записи в таблице. При сооздании коллекции генерируется автоматически. </item>
    /// <item> Примечание.
    /// Поле "Id" автоматически определяется как первичный ключ. </item>
    /// </list>
    public int Id {get; set;}  


    /// <list type="bullet">
    /// <item> Язык слов и фраз, описанных в карточках коллекции. </item>
    /// <item> Обязательно соответствие стандарту ISO 639-3. </item>
    /// <item> !!!Валидатор в сеттере???? </item>
    /// </list>
    [Required]
    [StringLength(3, MinimumLength = 3)]
    public string? SourceLanguage {get; set;}


    /// <list type="bullet">
    /// <item> Язык, на котором описаны переводы слов и фраз коллекции. </item>
    /// <item> Обязательно соответствие стандарту ISO 639-3. </item>
    /// <item> !!!Валидатор в сеттере???? </item>
    /// </list>
    [Required]
    [StringLength(3, MinimumLength = 3)]
    public string? DestinationLanguage {get; set;}


    /// <list type="bullet">
    /// <item> Название коллекции. </item>
    /// <item> Может содержать не более 200 симоволов. валидартор? </item>
    /// </list>
    [Required]
    [StringLength(200, MinimumLength = 1)]

    public string? Name {get; set;}


    /// <list type="bullet">
    /// <item> Описание коллекции. </item>
    /// <item> Может содержать не более 1000 симоволов. валидатор? </item>
    /// </list>
    [Required]
    [StringLength(1000, MinimumLength = 1)]
    public string? Description {get; set;}


    /// <list type="bullet">
    /// <item> Автор коллекции. </item>
    /// <item> Может содержать не более 100 симоволов. валидатор? </item>
    /// </list>
    [Required]
    [StringLength(100, MinimumLength = 1)]
    public string? Author {get; set;}

    /// <list type="bullet">
    /// <item> Все слова, содержащиеся в данной коллекции. </item>
    /// <item> Отношение "один ко многим" </item>
    /// </list>
    public List<Word> Words {get; set;} = new();


    /// <list type="bullet">
    /// <item> Все слова, содержащиеся в данной коллекции. </item>
    /// <item> Отношение "один ко многим" </item>
    /// </list>
    [Index(IsUnique=true)]
    [Required]
    public string? LinkName {get; set;}
}