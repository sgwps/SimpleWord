using Microsoft.AspNetCore.Mvc;
using SimpleWordModels;
using Newtonsoft.Json;
using SimpleWordAPI.DBContext;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using System.Net;
using System.Net.Http.Headers;
using System.Web.Http;

namespace SimpleWordAPI.Controllers;

[Route("get_collection")]
public class ViewCollectionController : Controller
{
    /*internal ViewCollectionController()
    {
        _context = context;
    }*/

    public IActionResult Get(string linkName)
    { //пропихнуть JSON
        Collection collection;
        using (var context = new SimpleWordDBContext())
        {
            collection = context.Collections.First<Collection>(i => i.LinkName == linkName);
            if (collection == null)
            {
                Response.StatusCode = 404;
                return NotFound();
            }
        }

        // Create the itext pdf
        MemoryStream stream = new MemoryStream();
        PdfWriter writer = new PdfWriter(stream);
        var pdf = new PdfDocument(writer);
        var document = new Document(pdf);
        document.Add(new Paragraph("Hello World!"));
        // тут ебаться с коллекцией
        document.Close(); // don't forget to close or the doc will be corrupt! ;)
        return new FileContentResult(stream.ToArray(), "application/pdf");
    }
}
