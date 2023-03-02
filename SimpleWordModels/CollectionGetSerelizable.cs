namespace SimpleWordModels;

//[Serializable]
class CollectionGetSerializable {
    //  чих
    public string SourceLanguage {get; private set;}

    public string DistanationLanguage {get; private set;}

    public string Name {get; private set;}

    public string? Description{get; private set;}

    public string? Author {get; private set;}

    public List<Card> Cards {get; private set; } = new();



    internal CollectionGetSerializable(Collection collection){
        SourceLanguage = collection.SourceLanguage;
        DistanationLanguage = collection.DistanationLanguage;
        Name = collection.Name;
        Description = collection.Description;
        Author = collection.Author;
        Cards = collection.Cards;

    }


}