using Microsoft.AspNetCore.Mvc;
using System;

namespace SimpleWordAPI.Controllers;
using SimpleWordAPI.DBContext;
using SimpleWordModels;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

[Route("new_collection")]
public class NewCollectionGetController : Controller
{

    /*internal NewCollectionGetController(SimpleWordDBContext context)
    {
        _context = context;
    }*/
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
    private readonly SimpleWordDBContext _context;

    /*internal NewCollectionPostController(SimpleWordDBContext context)
    {
        _context = context;
    }*/
    // в доках - new collection
    // Request.Form.Keys["msg"] - нужная строка
    // эту строку в json, обработать
    // сохранить в бд
    // string -> json -> dict
    [HttpPost]
    public StatusCodeResult Post()
    { //пропихнуть json
        using (var context = new SimpleWordDBContext())
        {
            string data = Request.Form["msg"];
            try
            {
                Collection json = JsonSerializer.Deserialize<Collection>(data);
                context.Collections.Add(json);
                context.SaveChanges();
                return StatusCode(200);
            }
            catch (JsonException)
            {
                return StatusCode(401);
            }
            catch (DbUpdateException)
            {
                return StatusCode(403);
            }
        }
    }
}
