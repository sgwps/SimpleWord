using System.ComponentModel.DataAnnotations;

namespace SimpleWordModels;
public class Word
{
    /// <list type="bullet">
    /// <item> Первичный ключ (целое неотрицательное число.) </item>
    /// <item> Первичный ключ записи в таблице. При сооздании коллекции генерируется автоматически. </item>
    /// <item> Примечание.
    /// Поле "Id" автоматически определяется как первичный ключ. </item>
    /// </list>
    public int Id {get; set;}

    string? origin;
    /// <list type="bullet">
    /// <item> Введённое слово </item>
    /// <item> Может содержать не более 50 символов </item>
    /// </list>
    [Required]
    public string? Origin {
        get {
            return origin;
        }
        set{
            if (value == null)
                throw new ArgumentException("The word can't be empty");
            else if (value.Length > 50)
                throw new ArgumentException("Too many symbols");
            else
                origin = value;
        }
    }

    string? translation;
    /// <list type="bullet">
    /// <item> Перевод введённого слова </item>
    /// <item> Может содержать не более 50 символов </item>
    /// </list>
    [Required]
    public string? Translations {
        get {
            return translation;
        }
        set{
            if (value == null)
                throw new ArgumentException("The word can't be empty");
            else if (value.Length > 50)
                throw new ArgumentException("Too many symbols");
            else
                translation = value;
        }
    }

    string? comment;
    /// <list type="bullet">
    /// <item> Комментраий к слову </item>
    /// <item> Может содержать не более 500 символов </item>
    /// </list>
    public string? Comment{
        get{
            return comment;
        }
        set{
            if (value == null)
                comment = "";
            else if (value.Length > 500)
                throw new ArgumentException("Too many symbols");
            else
                comment = value;
        }
    }


    /// <list type="bullet">
    /// <item> Коллекция, сожержащая введённое слово </item>
    /// </list>
    [Required]
    public Collection? Collection {get; init;}

    /// <list type="bullet">
    /// <item> Пример для данного слова </item>
    /// </list>
    public List<Example> Examples { get; set; } = new();
}

