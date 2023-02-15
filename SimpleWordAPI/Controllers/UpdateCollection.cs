using Microsoft.AspNetCore.Mvc;

namespace SimpleWordAPI.Controllers;

[ApiController]
[Route("update_collection")]
public class UpdateCollectionController : ControllerBase
{
    public ContentResult Get(string linkName){
        // нужную коллекцию собрать в json формата collectionUpdate schema
        // вернуть html, аналогчиный input.html, но в поле ввода должен быть это json как строка
        throw new NotImplementedException();
    }


}


[ApiController]
[Route("update_collection_post")]
public class UpdateCollectionControllerPost : ControllerBase
{

    public StatusCodeResult Post(string collection){  //пропихнуть JSON
        // достать коллекцию с соответвующим id, дальше аналогчино new collection
        throw new NotImplementedException();
    }
}