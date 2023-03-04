using Microsoft.AspNetCore.Mvc;
using SimpleWordModels;
using Newtonsoft.Json;
using SimpleWordAPI.DBContext;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Kernel.Font;
using iText.Layout.Font;
using iText.IO.Font;
using iText.IO;
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

        System.Console.WriteLine(System.IO.Directory.GetCurrentDirectory());

        string path = "edf7f-eirik-raude.ttf";
        FontProgram fontProgram = FontProgramFactory.CreateFont(path);
        MemoryStream stream = new MemoryStream();
        PdfWriter writer = new PdfWriter(stream);
        var pdf = new PdfDocument(writer);
        //PdfFont pdffont = new PdfFont(iText.IO.Font.Constants.StandardFonts.TIMES_ROMAN);
        //PdfFont font = PdfFontFactory.AddFont(FontConstants.TIMES_ROMAN);
        PdfFont font = PdfFontFactory.CreateFont(fontProgram);
        var document = new Document(pdf);
        FontProvider fontProvider = new FontProvider();
        fontProvider.AddFont(iText.IO.Font.Constants.StandardFonts.TIMES_ROMAN);
        document.SetFontProvider(fontProvider);

        using (var context = new SqliteDBContext())
        {
            collection = context.Collections.First<Collection>(i => i.LinkName == linkName);
            if (collection == null)
            {
                Response.StatusCode = 404;
                return NotFound();
            }
        
        

        // Create the itext pdf
        Paragraph paragraph = new Paragraph("Collection: ");
        //document.Add(new Text("привет").SetFont(font));
        paragraph.SetFont(font);
        document.Add(paragraph);
        List list = new List();
        list.SetFont(font);
        list.Add($"\tSource Language: {collection.SourceLanguage}");
        list.Add($"\tDestination Language: {collection.DistanationLanguage}");
        list.Add($"\tName: {collection.Name}");
        list.Add($"\tDescription: {collection.Description}");
        list.Add($"\tAuthor: {collection.Author}");
        list.Add($"\tLink Name: {collection.LinkName}");
        list.Add($"\tName: {collection.Name}");
        list.Add("\tCards:");
        document.Add(list);
        List list1 = new List();
        list1.SetFont(font);
        List<Card> cards = context.Cards.Where(i => i.Collection == collection).ToList<Card>();
        
        for (int i = 0; i < cards.Count; i++){
            System.Console.WriteLine(i);
            list1.Add($"\t\tWord: {cards[i].Word}");
            list1.Add($"\t\tComment: {cards[i].Comment}");
            list1.Add($"\t\tTranslation:");
            List<Translation> translations = context.Translations.Where(p => p.Card == cards[i]).ToList<Translation>();
            for (int j = 0; j < translations.Count; j++){
                list1.Add($"\t\t\tValue: {translations[j].Value}");
                list1.Add($"\t\t\tComment: {translations[j].Comment}");
                List<Example> examples = context.Examples.Where(p => p.Translation == translations[i]).ToList<Example>();
                for (int k = 0; k < examples.Count; k++){
                    list1.Add($"\t\t\t\tOrigin: " + examples[k].Origin);
                    list1.Add($"\t\t\t\tExample translation: {examples[k].ExampleTranslation}");
                    list1.Add($"\t\t\t\tComment: {examples[k].Comment}");
                    list1.Add($"\t\t\t\tSource: {examples[k].Source}");
                    //System.Console.WriteLine(examples[k].Origin + " " + examples[k].ExampleTranslation + " " + examples[k].Comment + " " + examples[k].Source);
                }
            }
        }
        document.Add(list1);
        }
        // тут ебаться с коллекцией
        document.Close(); // don't forget to close or the doc will be corrupt! ;)
        return new FileContentResult(stream.ToArray(), "application/pdf");
    }
}
