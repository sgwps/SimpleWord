using Microsoft.AspNetCore.Mvc;
using System;
namespace SimpleWordAPI.Controllers;
using SimpleWordAPI.DBContext;
using SimpleWordModels;

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
        Collection c = new Collection();
        c.SourceLanguage = "rus";
        c.DistanationLanguage = "end";

        c.Name = "test";
        c.LinkName = "rrrrr";
        ManageController._context.Collections.Add(c);
        ManageController._context.SaveChanges();
        Console.WriteLine(Request);
        foreach (string key in Request.Form.Keys)
        {
            Console.WriteLine(key);
            Console.WriteLine(Request.Form[key]);

        }        
        Console.WriteLine("aaaaa");
        return StatusCode(200);
    }



}