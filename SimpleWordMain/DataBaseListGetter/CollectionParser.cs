
using System.Data.Entity;
using SimpleWordModels;
using SimpleWordAPI.DBContext;

namespace SimpleWordDatabase.ListParser;

static 
class CollectionParser {
    static public void SetLists(this Collection collection, SimpleWordDbContextAbstract context){
        List<Card> cards = context.Cards.Where(i => i.Collection == collection).ToList<Card>();
        collection.Cards = cards;
        collection.Cards.ForEach(i => (i).SetList(context));
        
    }

    static public void SetList(this Card card, SimpleWordDbContextAbstract context){
        card.Translations = context.Translations.Where(p => p.Card == card).ToList<Translation>();
        card.Translations.ForEach(i => (i).SetList(context));
    }


    static public void SetList(this Translation translation, SimpleWordDbContextAbstract context){
        translation.Examples = context.Examples
                    .Where(p => p.Translation == translation)
                    .ToList<Example>();
    }
}


