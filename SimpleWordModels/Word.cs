using System.ComponentModel.DataAnnotations;

namespace SimpleWordModels;
public class Word
{
    public int Id {get; set;}

    [Required]
    public string? Origin {get; set;}

    [Required]
    public string? Translations {get; set;}

    [Required]
    public Collection? Collection {get; init;}
    public List<Example> Examples { get; set; } = new();
}
