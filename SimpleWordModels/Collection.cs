using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
namespace SimpleWord.Models;

[Index(nameof(Collection.LinkName), IsUnique =true)]
public class Collection {
    private static bool ValidateISO639Standart (string value) {
        List<string> lines = File.ReadAllLines(@"../SimpleWordModels/Data/ISO639.csv")[1..].ToList<string>();
        foreach (string line in lines){
            if (line.Split(",")[0] == value) return true;
        }
        return false;
    }


    public string LanguageDecription{
        get{
            return $"{SourceLanguageFull} >>> {DestanationLanguageFull}";
        }
    }

    [JsonIgnore]
    public string SourceLanguageFull{
        get {
            List<string> lines = File.ReadAllLines(@"../SimpleWordModels/Data/ISO639.csv")[1..].ToList<string>();
            foreach (string line in lines)
                if (line.Split(",")[0] == sourceLanguage) return line.Split(",")[5];
            throw new ArgumentException();
        }
    }

    [JsonIgnore]
    public string DestanationLanguageFull{
        get {
            List<string> lines = File.ReadAllLines(@"../SimpleWordModels/Data/ISO639.csv")[1..].ToList<string>();
            foreach (string line in lines)
                if (line.Split(",")[0] == distanationLanguage) return line.Split(",")[5];
            throw new ArgumentException();
        }
    }



    /// <list type="bullet">
    /// <item> Первичный ключ (целое неотрицательное число.) </item>
    /// <item> Первичный ключ записи в таблице. При сооздании коллекции генерируется автоматически. </item>
    /// <item> Примечание.
    /// Поле "Id" автоматически определяется как первичный ключ. </item>
    /// </list>
    [JsonIgnore]
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
        set {
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
        set {
            if (value == null)
                throw new ArgumentException("The distanation language can't be empty");
            else if(!ValidateISO639Standart(value))
                throw new ArgumentException("Несоответствие стандрату ISO639");
            else
                distanationLanguage = value;
        }
    }

    string? name;
    /// <list type="bullet">
    /// <item> Название коллекции. </item>
    /// <item> Может содержать не более 200 симоволов. </item>
    /// </list>
    [Required]
    [StringLength(200, MinimumLength = 1)]
    public string? Name {get; set;}

    string? description;
    /// <list type="bullet">
    /// <item> Описание коллекции </item>
    /// <item> Может содержать не более 1000 символов </item>
    /// </list>
    [StringLength(1000)]
    public string? Description{get; set;}
    
    string? author;
    /// <list type="bullet">
    /// <item> Автор коллекции. </item>
    /// <item> Может содеражть не более 100 символов </item>
    /// </list>
    [StringLength(100)]
    public string? Author {get; set;}


    string? linkName;
    /// <list type="bullet">
    /// <item> Строка - уникальный идентификатор. </item>
    /// <item> Не более 30 символов. </item>
    /// <item> Может создержать только строчные латинские буквы (если в запросе содержатся заглавные, они преобразовываются в строчные), цифры и символ подчеркивания (ASCII-код 95). </item>
    /// </list>
    [Required]
    [StringLength(30)]
    public string? LinkName {
        get{
            return linkName;
        }
        set{
            linkName = value;
        }
    }

    /// <list type="bullet">
    /// <item> Все слова (карточки), содержащиеся в данной коллекции. </item>
    /// <item> Отношение "один ко многим" </item>
    /// </list>
    public List<Card> Cards {get; set; } = new();

}
