using Microsoft.AspNetCore.Mvc;
using System;

namespace SimpleWordAPI.Controllers;
using SimpleWordAPI.DBContext;
using SimpleWordModels;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;

[Route("new_collection")]
public class NewCollectionGetController : Controller
{
    public IActionResult Get()
    {
        
        return View();
    }
}

static class ManageController
{
    public static SqliteDBContext _context = new SqliteDBContext();
}


[Route("new_collection_post")]
public class NewCollectionPostController : Controller
{
    // в доках - new collection
    // Request.Form.Keys["msg"] - нужная строка
    // эту строку в json, обработать
    // сохранить в бд
    // string -> json -> dict
    [HttpPost]
    public StatusCodeResult Post()
    { //пропихнуть json
        string data = Request.Form["msg"];
        try
        {
            Collection json = JsonConvert.DeserializeObject<Collection>(data);
            ManageController._context.Collections.Add(json);
            ManageController._context.SaveChanges();
            return StatusCode(200);
        }
        catch (JsonReaderException)
        {
            return StatusCode(401);
        }
        catch (DbUpdateException)
        {
            return StatusCode(403);
        }
    }
}
