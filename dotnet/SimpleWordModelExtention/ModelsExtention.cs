using System.Data.Entity;
using SimpleWord.Models;
using SimpleWord.DBContext;

namespace SimpleWord.ModelsExtention;

static public class CollectionParser {
    static public void SetLists(this Collection collection, SimpleWordDbContext context){
        List<Card> cards = context.Cards.Where(i => i.CollectionId == collection.Id).ToList<Card>();
        collection.Cards = cards;
        collection.Cards.ForEach(i => (i).SetList(context));
        
    }

    static public void SetList(this Card card, SimpleWordDbContext context){
        card.Translations = context.Translations.Where(p => p.CardId == card.Id).ToList<Translation>();
        card.Translations.ForEach(i => (i).SetList(context));
    }


    static public void SetList(this Translation translation, SimpleWordDbContext context){
        translation.Examples = context.Examples
                    .Where(p => p.TranslationId == translation.Id)
                    .ToList<Example>();
    }
}


