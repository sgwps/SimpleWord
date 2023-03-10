using Microsoft.AspNetCore.Mvc;
using SimpleWordModels;
using Newtonsoft.Json;
using SimpleWordAPI.DBContext;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Kernel.Font;
using iText.Layout.Font;
using iText.Layout.Borders;
using iText.Svg.Converter;
using iText.IO.Font;
using iText.IO;
using iText.Kernel.Geom;
using System.Net;
using System.Net.Http.Headers;
using System.Web.Http;
using iText.Layout.Properties;
using iText.Kernel.XMP;
using iText.Kernel.Colors;
using SimpleWordAPI.DBContext;
using SimpleWordPdfGenerator; 
using SimpleWordDatabase.ListParser;


namespace SimpleWordAPI.Controllers;

[Route("get_collection")]
public class ViewCollectionController : Controller
{


    public IActionResult Get(string linkName)
    { //пропихнуть JSON
        MemoryStream stream = new MemoryStream();
        PdfWriter writer = new PdfWriter(stream);
        var pdf = new PdfDocument(writer);       
        var document = new Document(pdf);
        FontProvider fontProvider = new FontProvider();
        fontProvider.AddFont(iText.IO.Font.Constants.StandardFonts.TIMES_ROMAN);
        document.SetFontProvider(fontProvider);
        using (SqliteDBContext context = new SqliteDBContext()){
            CollectionParser collection = (CollectionParser) context.Collections.First<Collection>(i => i.LinkName == linkName);
            if (collection == null)
            {
                Response.StatusCode = 404;
                return NotFound();
            }
            collection.SetLists(context);
            ((CollectionPdf)(Collection)collection).AddContent(document);
        
    
        }
        // тут ебаться с коллекцией
        document.Close(); // don't forget to close or the doc will be corrupt! ;)
        return new FileContentResult(stream.ToArray(), "application/pdf");
    }
}

