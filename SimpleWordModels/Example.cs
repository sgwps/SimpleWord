using System.ComponentModel.DataAnnotations;

namespace SimpleWordModels;

public class Example{
    public int Id{get; init;}

    [Required]
    public Word? Word {get; init;}

    [Required]
    public string? Origin {get; set;}

    [Required]
    public string? Translations {get; set;}
}