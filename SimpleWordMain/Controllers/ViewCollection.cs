using Microsoft.AspNetCore.Mvc;
using SimpleWord.Models;
using Newtonsoft.Json;
using SimpleWord.DBContext;
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
using SimpleWord.PdfGenerator;
using SimpleWord.ModelsExtention;
using System.Xml.Serialization;
using SimpleWord.ColorThemes;

namespace SimpleWordAPI.Controllers;

[Route("get_collection")]
public class ViewCollectionController : Controller
{
    public IActionResult Get(string linkName)
    { //пропихнуть JSON
        MemoryStream stream = new MemoryStream();
        PdfWriter writer = new PdfWriter(stream);
        PdfDocument pdf = new PdfDocument(writer);
        ColorTheme colorTheme = new ColorTheme();
        using (FileStream fs = new FileStream("ColorThemes/Brick.xml", FileMode.Open))
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ColorTheme));
            colorTheme = (ColorTheme) xmlSerializer.Deserialize(fs) ?? new ColorTheme();
        }
        var document = new Document(pdf);
        using (SqliteDBContext context = new SqliteDBContext())
        {
            Collection collection = context.Collections.First<Collection>(
                i => i.LinkName == linkName
            );
            if (collection == null)
            {
                Response.StatusCode = 404;
                return NotFound();
            }
            collection.SetLists(context);
            (new CollectionPdf(collection, colorTheme)).AddContent(document);
        }
        document.Close(); // don't forget to close or the doc will be corrupt! ;)
        return new FileContentResult(stream.ToArray(), "application/pdf");
    }
}
