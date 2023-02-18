using Microsoft.AspNetCore.Mvc;
using SimpleWordModels;
using Newtonsoft.Json;
namespace SimpleWordAPI.Controllers;

[ApiController]
[Route("get_collection")]
public class ViewCollectionController : ControllerBase
{
    public JsonResult Get(string linkName){  //пропихнуть JSON
        Collection collection = ManageController._context.Collections.First<Collection>(i => i.LinkName == linkName);
        List<Card> cards = ManageController._context.Cards.Where(i => i.Collection == collection).ToList<Card>();
        collection.Cards = cards;
        for (int i = 0; i < collection.Cards.Count; i++){
            //collection.Cards[i].Collection = null;
            collection.Cards[i].Translations = ManageController._context.Translations.Where(j => j.Card == collection.Cards[i]).ToList<Translation>();
            for (int j = 0; j < collection.Cards[i].Translations.Count; j++){
                //collection.Cards[i].Translations[j].Card = null;

                collection.Cards[i].Translations[j].Examples = ManageController._context.Examples.Where(k => k.Translation == collection.Cards[i].Translations[j]).ToList<Example>();
                for (int k = 0; k < collection.Cards[i].Translations[j].Examples.Count; k ++){
                    //collection.Cards[i].Translations[j].Examples[k].Translation =  null;
                }
            }
        }
        return new JsonResult(collection);
    }
}