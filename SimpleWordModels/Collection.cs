using System.ComponentModel.DataAnnotations;
namespace SimpleWordModels;

public class Collection {
    public int Id {get; set;}  //Key by default

    [Required]
    public string? OriginLanguage {get; init;}

    [Required]
    public string? FinalLanguage {get; init;}

    [Required]
    public string? Name {get; set;}
    [Required]
    public string? Author {get; set;}
    public List<Word> Words {get; set;} = new();
    [Required]
    public string? ShortName {get; set;}
}