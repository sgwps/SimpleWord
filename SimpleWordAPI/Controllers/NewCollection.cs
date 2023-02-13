using Microsoft.AspNetCore.Mvc;

namespace SimpleWordAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class NewCollectionController : ControllerBase
{
    public ContentResult Get(){
        throw new NotImplementedException();
    }

    public StatusCodeResult Post(string collection){  //пропихнуть json
        throw new NotImplementedException();
    }


}