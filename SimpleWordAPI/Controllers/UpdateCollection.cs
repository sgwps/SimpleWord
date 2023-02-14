using Microsoft.AspNetCore.Mvc;

namespace SimpleWordAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UpdateCollectionController : ControllerBase
{
    public ContentResult Get(string linkName){
        throw new NotImplementedException();
    }

    public StatusCodeResult Post(string collection){  //пропихнуть JSON
        throw new NotImplementedException();
    }
}