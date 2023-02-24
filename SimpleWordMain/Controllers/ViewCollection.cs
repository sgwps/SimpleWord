using Microsoft.AspNetCore.Mvc;
using SimpleWordModels;
using Newtonsoft.Json;
using SimpleWordAPI.DBContext;

namespace SimpleWordAPI.Controllers;

[Route("get_collection")]
public class ViewCollectionController : Controller
{
    private readonly SimpleWordDBContext _context = SimpleWordDBContext.context;

    /*internal ViewCollectionController()
    {
        _context = context;
    }*/

    public JsonResult Get(string linkName)
    { //пропихнуть JSON
        using (var context = new SimpleWordDBContext())
        {
            Collection collection = context.Collections.First<Collection>(
                i => i.LinkName == linkName
            );
            List<Card> cards = context.Cards.Where(i => i.Collection == collection).ToList<Card>();
            collection.Cards = cards;
            for (int i = 0; i < collection.Cards.Count; i++)
            {
                //collection.Cards[i].Collection = null;
                collection.Cards[i].Translations = context.Translations
                    .Where(j => j.Card == collection.Cards[i])
                    .ToList<Translation>();
                for (int j = 0; j < collection.Cards[i].Translations.Count; j++)
                {
                    //collection.Cards[i].Translations[j].Card = null;

                    collection.Cards[i].Translations[j].Examples = context.Examples
                        .Where(k => k.Translation == collection.Cards[i].Translations[j])
                        .ToList<Example>();
                    for (int k = 0; k < collection.Cards[i].Translations[j].Examples.Count; k++)
                    {
                        //collection.Cards[i].Translations[j].Examples[k].Translation =  null;
                    }
                }
            }
            return new JsonResult(collection);
        }
    }
}
