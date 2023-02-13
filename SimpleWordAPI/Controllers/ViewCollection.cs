using Microsoft.AspNetCore.Mvc;

namespace SimpleWordAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ViewCollectionController : ControllerBase
{
    public JsonResult Get(string linkName){  //пропихнуть JSON
        throw new NotImplementedException();
    }
}