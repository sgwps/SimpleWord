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


namespace SimpleWordAPI.Controllers;

[Route("get_collection")]
public class ViewCollectionController : Controller
{


    public IActionResult Get(string linkName)
    { //пропихнуть JSON
     
        Collection collection;

        System.Console.WriteLine(System.IO.Directory.GetCurrentDirectory());

        string path = "edf7f-eirik-raude.ttf";
        FontProgram fontProgramBold = FontProgramFactory.CreateFont("Fonts/FuturaPT-Bold.ttf");
        FontProgram fontProgramLight = FontProgramFactory.CreateFont("Fonts/FuturaPT-Medium.ttf");

        MemoryStream stream = new MemoryStream();
        PdfWriter writer = new PdfWriter(stream);
        var pdf = new PdfDocument(writer);
        //PdfFont pdffont = new PdfFont(iText.IO.Font.Constants.StandardFonts.TIMES_ROMAN);
        //PdfFont font = PdfFontFactory.AddFont(FontConstants.TIMES_ROMAN);
        PdfFont fontBold = PdfFontFactory.CreateFont(fontProgramBold);
        PdfFont fontLight = PdfFontFactory.CreateFont(fontProgramLight);
        var document = new Document(pdf);
        FontProvider fontProvider = new FontProvider();
        fontProvider.AddFont(iText.IO.Font.Constants.StandardFonts.TIMES_ROMAN);
        document.SetFontProvider(fontProvider);
        using (SqliteDBContext context = new SqliteDBContext()){
        collection = context.Collections.First<Collection>(i => i.LinkName == linkName);
        if (collection == null)
        {
            Response.StatusCode = 404;
            return NotFound();
        }
        
        
        //document.SetTopMargin(0);
        //document.SetLeftMargin(0);
        //document.SetRightMargin(0);
        document.SetBorderTop(Border.NO_BORDER);






        


        List<Card> cards = context.Cards.Where(i => i.Collection == collection).ToList<Card>();
        collection.Cards = cards;


        for (int i = 0; i < cards.Count; i++)
        {
            
            cards[i].Translations = context.Translations
                .Where(p => p.Card == cards[i])
                .ToList<Translation>();

            for (int j = 0; j < cards[i].Translations.Count; j++)
            {
                cards[i].Translations[j].Examples = context.Examples
                    .Where(p => p.Translation == cards[i].Translations[j])
                    .ToList<Example>();
            }
        }
        CollectionPdf pdfMaker = new CollectionPdf(collection, document);
        document = pdfMaker.GetPdf;
        
    
        }
        // тут ебаться с коллекцией
        document.Close(); // don't forget to close or the doc will be corrupt! ;)
        return new FileContentResult(stream.ToArray(), "application/pdf");
    }
}

