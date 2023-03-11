using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SimpleWord.Models;
public class Card
{
    /// <list type="bullet">
    /// <item> Первичный ключ (целое неотрицательное число.) </item>
    /// <item> Первичный ключ записи в таблице. При сооздании коллекции генерируется автоматически. </item>
    /// </list>
    [JsonIgnore]
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
    [JsonIgnore]
    public Collection? Collection {get; set;}

    /// <list type="bullet">
    /// <item> Комментарий автора коллекции к данной карточке. </item>
    /// <item> Может содержать не более 500 симоволов. </item>
    /// <item> Не обязателен. </item>
    /// </list>
    [StringLength(500)]
    public string? Comment {get; set;}

    List<Translation> translations = new();
    public List<Translation> Translations { get{return translations;} set{
        translations = value;
        foreach(Translation i in translations){
            i.Card = this;
        }
    } } 

    int collection_id;
    public int CollectionId{
        get {if (Collection is null) return collection_id; return Collection.Id;}
        set {
            collection_id = value;
        }
    }
}
