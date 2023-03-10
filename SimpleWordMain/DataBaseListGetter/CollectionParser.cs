
using System.Data.Entity;
using SimpleWordModels;
using SimpleWordAPI.DBContext;

namespace SimpleWordDatabase.ListParser;


class CollectionParser : Collection{
    public void SetLists(SimpleWordDbContextAbstract context){
        List<Card> cards = context.Cards.Where(i => i.Collection == this).ToList<Card>();
        Cards = cards;
        Cards.ForEach(i => ((CardParser)i).SetList(context));
        
    }
}

class CardParser : Card{
    public void SetList(SimpleWordDbContextAbstract context){
        Translations = context.Translations.Where(p => p.Card == this).ToList<Translation>();
        Translations.ForEach(i => ((TranslationParser)i).SetList(context));
    }
}


class TranslationParser : Translation{
    public void SetList(SimpleWordDbContextAbstract context){
        Examples = context.Examples
                    .Where(p => p.Translation == this)
                    .ToList<Example>();
    }
}