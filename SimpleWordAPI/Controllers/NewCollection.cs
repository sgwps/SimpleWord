using Microsoft.AspNetCore.Mvc;
using System;

namespace SimpleWordAPI.Controllers;
using SimpleWordAPI.DBContext;
using SimpleWordModels;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("new_collection")]
public class NewCollectionGetController : ControllerBase
{
    public ContentResult Get()
    {
        return Content(
            System.IO.File.ReadAllText(@"TestViews/Input.HTML", System.Text.Encoding.UTF8),
            "text/html"
        );
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
            return StatusCode(400);
        }
        catch (DbUpdateException)
        {
            return StatusCode(403);
        }
    }
}
