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
        string html = 
            @"<!DOCTYPE html>
<html lang= " + ((char)34) + " ru " + ((char)34) + @" >
<head>
<meta charset= " + ((char)34) + @" UTF-8 " + ((char)34) + @" >
<title>Отправка сообщений - jQuery</title>
            <script src=" + ((char)34) + @"//code.jquery.com/jquery-1.8.3.js  " + ((char)34) + @"></script>
            </head>
            <body>

            <form onsubmit=" + ((char)34) + @"Send();return false " + ((char)34) + @">
            <label for=" + ((char)34) + @"request" + ((char)34) + @">Запрос:</label>
            <input id=" + ((char)34) + @"request " + ((char)34) + @" required>
            <input type=" + ((char)34) + @"submit" + ((char)34) + @" value=" + ((char)34) + @"Send" + ((char)34) + @">
            </form>
            <div id=" + ((char)34) + @"result " + ((char)34) + @"></div>

            <script>
            function Send(){
            console.log(" + ((char)34) + @"test" + ((char)34) + @");
            $.ajax({
            type: " + ((char)34) + @"POST" + ((char)34) + @",
            url:" + ((char)34) + @"/new_collection_post" + ((char)34) + @",
            data: {
            " + ((char)34) + @"msg" + ((char)34) + @": jQuery('#request').val()}
            })}
            </script>

            </body>
            </html>";
        return Content(
            html,
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
