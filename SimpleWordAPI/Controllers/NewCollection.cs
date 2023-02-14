using Microsoft.AspNetCore.Mvc;
using System;
namespace SimpleWordAPI.Controllers;

[ApiController]
[Route("new_collection")]
public class NewCollectionGetController : ControllerBase
{
    public ContentResult Get(){
        return Content(System.IO.File.ReadAllText(@"TestViews/Input.HTML", System.Text.Encoding.UTF8), "text/html");
    }

    /*
    public StatusCodeResult Post(string collection){  //пропихнуть json
        throw new NotImplementedException();
    }
    */


}


[ApiController]
[Route("new_collection_post")]
public class NewCollectionPostController : ControllerBase
{
    public StatusCodeResult Post(){  //пропихнуть json
        Console.WriteLine("aaaaa");
        //Console.WriteLine(collection);
        return StatusCode(200);
    }



}