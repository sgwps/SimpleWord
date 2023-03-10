using Microsoft.AspNetCore.Mvc;
using System;

namespace SimpleWordAPI.Controllers;
using SimpleWord.DBContext;
using SimpleWord.Models;
using System.Text.Json;
using System.Text.Json.Serialization;
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
    
    [HttpPost]
    public StatusCodeResult Post()
    { //пропихнуть json
        using (var context = new PostgreSQLContext())
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
