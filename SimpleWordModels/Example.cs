using System.ComponentModel.DataAnnotations;

namespace SimpleWordModels;

public class Example{
    /// <list type="bullet">
    /// <item> Первичный ключ (целое неотрицательное число.) </item>
    /// <item> Первичный ключ записи в таблице. При сооздании коллекции генерируется автоматически. </item>
    /// <item> Примечание.
    /// Поле "Id" автоматически определяется как первичный ключ. </item>
    /// </list>
    [Required]
    public int Id{get; init;}

    /// <list type="bullet">
    /// <item> Экземпляр класса Word </item>
    /// </list>
    [Required]
    public Word? Word {get; init;}

    string? origin;
    /// <list type="bullet">
    /// <item> Пример использования слова </item>
    /// <item> Может содержать не более 400 символов </item>
    /// </list>
    [Required]
    public string? Origin{
        get{
            return origin;
        }
        set{
            if (value == null)
                throw new ArgumentException("The example of using the word can't be empty");
            else if (value.Length > 400)
                throw new ArgumentException("Too many symbols");
            else
                origin = value;
        }
    }

    string? translation;
    /// <list type="bullet">
    /// <item> Перевод примера (Origin) </item>
    /// <item> Может содержать не более 400 символов </item>
    /// </list>
    [Required]
    public string? Translations{
        get{
            return translation;
        }
        set{
            if (value == null)
                throw new ArgumentException("The translation of the example of using the word can't be empty");
            else if (value.Length > 400)
                throw new ArgumentException("Too many symbols");
            else
                translation = value;
        }
    }

    string? source;
    /// <list type="bullet">
    /// <item> Источник, откуда взят пример </item>
    /// <item> Может содержать не более 200 символов </item>
    /// </list>
    public string? Source{
        get{
            return source;
        }
        set{
            if (value == null)
                source = "";
            else if (value.Length > 200)
                throw new ArgumentException("Too many symbols");
            else
                source = value;
        }
    }
}