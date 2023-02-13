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

    string? sourceLanguage;
    /// <list type="bullet">
    /// <item> Язык слов и фраз, описанных в карточках коллекции. </item>
    /// <item> Обязательно соответствие стандарту ISO 639-3. </item>
    /// </list>
    [Required]
    public string? SourceLanguage {
        get{
            return sourceLanguage;
        }
        init{
            if (value == null)
                throw new ArgumentException("The source language can't be empty");
            else if (ValidateISO639Standart(value))
                sourceLanguage = value;
            else
                throw new ArgumentException("Несоответствие стандарту ISO639");
        }
    }

    string? distanationLanguage;
    /// <list type="bullet">
    /// <item> Язык, на котором описаны переводы слов и фраз коллекции. </item>
    /// <item> Обязательно соответствие стандарту ISO 639-3. </item>
    /// </list>
    [Required]
    public string? DistanationLanguage {
        get{
            return distanationLanguage;
        }
        init{
            if (value == null)
                throw new ArgumentException("The distanation language can't be empty");
            else if(ValidateISO639Standart(value))
                throw new ArgumentException("Несоответствие стандрату ISO639");
            else
                distanationLanguage = value;
        }
    }

    string? name;
    /// <list type="bullet">
    /// <item> Название коллекции. </item>
    /// <item> Может содержать не более 200 симоволов. валидартор? </item>
    /// </list>
    [Required]
    public string? Name {
        get{
            return name;
        }
        set{
            if (value == null)
                throw new ArgumentException("The name of the collection can't be empty");
            else if (value.Length > 200)
                throw new ArgumentException("Too many symbols");
            else
                name = value;
        }
    }
    
    string? author;
    /// <list type="bullet">
    /// <item> Автор коллекции. </item>
    /// <item> Может содеражть не более 100 символов </item>
    /// </list>
    public string? Author {
        get{
            return author;
        }
        set{
            if (value == null)
                author = "";
            else if (value.Length > 100)
                throw new ArgumentException("Too many symbols");
            else
                author = value;
        }
    }

    /// <list type="bullet">
    /// <item> Лист слов, которые добовляются в коллекцию. </item>
    /// </list>
    public List<Word> Words {get; set; } = new();

    string? description;
    /// <list type="bullet">
    /// <item> Описание коллекции </item>
    /// <item> Может содержать не более 1000 символов </item>
    /// </list>
    [Required]
    public string? Description{
        get{
            return description;
        }
        set{
            if (value == null)
                throw new ArgumentException("The description of the collection can't be empty");
            else if (value.Length > 1000)
                throw new ArgumentException("Too many symbols");
            else
                description = value;
        }
    }

    string? linkName;
    /// <list type="bullet">
    /// <item> Язык, на котором описаны переводы слов и фраз коллекции. </item>
    /// <item> Обязательно соответствие стандарту ISO 639-3. </item>
    /// </list>
    [Required] // [Index] ??? 
    public string? LinkName {
        get{
            return linkName;
        }
        set{
            if (value == null)
                throw new ArgumentException("The link to the collection can't be empty"); // ????
            else if (value.Length > 30)
                throw new ArgumentException("Too many symbols");
            else
                linkName = value;
        }
    }
}
