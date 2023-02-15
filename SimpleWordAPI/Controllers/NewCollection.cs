using Microsoft.AspNetCore.Mvc;
using System;
namespace SimpleWordAPI.Controllers;
using SimpleWordAPI.DBContext;
using SimpleWordModels;
using Newtonsoft.Json;

[ApiController]
[Route("new_collection")]
public class NewCollectionGetController : ControllerBase
{
    public ContentResult Get(){
        return Content(System.IO.File.ReadAllText(@"TestViews/Input.HTML", System.Text.Encoding.UTF8), "text/html");
    }

   
}


static class ManageController
{
    public static SqliteDBContext _context = new SqliteDBContext();

}



[ApiController]
[Route("new_collection_post")]
public class NewCollectionPostController : ControllerBase
{
    // в доках - new collection
    // Request.Form.Keys["msg"] - нужная строка
    // эту строку в json, обработать
    // сохранить в бд
    // string -> json -> dict

    public StatusCodeResult Post(){  //пропихнуть json
        string data = Request.Form["msg"];
        dynamic json = JsonConvert.DeserializeObject(data); 
        Collection collection = new Collection();
        collection.LinkName = json["LinkName"];
        collection.SourceLanguage = json["sourceLanguage"];
        collection.DistanationLanguage = json["destinationLanguage"];
        collection.Name = json["name"];
        collection.Description = json["description"];
        collection.Author = json["author"];
        ManageController._context.Collections.Add(collection);
        foreach (dynamic i in json["cards"]){
            Card card = new Card();
            card.Word = i["origin"];
            card.Comment = i["comments"];
            card.Collection = collection;
            ManageController._context.Cards.Add(card);
            
        }
        ManageController._context.SaveChanges();

        return StatusCode(200);
    }



}