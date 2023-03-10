using SimpleWordModels;
using iText.Layout;
using iText.Layout.Element;
using iText.Kernel.Colors;
using iText.Layout.Properties;
using iText.Layout.Borders;
using iText.Kernel.Pdf.Canvas;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Kernel.Pdf;
using iText.Svg.Converter;

namespace SimpleWordPdfGenerator;

public class CollectionPdf : Collection
{
    private Paragraph Title(float topMargin){
            Paragraph titleParagraph = new Paragraph();

            titleParagraph.SetPaddings(6, 0, 0, 12);
            titleParagraph.SetMarginTop(topMargin);
            titleParagraph.SetMarginBottom(0);
            titleParagraph.SetTextAlignment(TextAlignment.CENTER);
            titleParagraph.SetBorder(Border.NO_BORDER);

            titleParagraph.SetBackgroundColor(Colors.Accent);

            Text titleText = TextElementFactory.Generare(Name, Fonts.Bold, FontSize.Title, Colors.BackgroundAccent);

            titleParagraph.Add(titleText);

            return titleParagraph;
    }

    private Paragraph SubTitle{
        get{
            Paragraph paragraph = new Paragraph();

            paragraph.SetPaddings(-6, 0, 12, 12);
            paragraph.SetMarginTop(0);
            paragraph.SetMarginBottom(0);
            paragraph.SetTextAlignment(TextAlignment.CENTER);
            paragraph.SetBorder(Border.NO_BORDER);
            paragraph.SetFixedLeading(20);

            paragraph.SetBackgroundColor(Colors.Accent);
            
            Text authorText = TextElementFactory.Generare($"by {Author}", Fonts.Light, FontSize.Normal, Colors.Netural);
            Text languageText = TextElementFactory.Generare(LanguageDecription, Fonts.Light, FontSize.Normal, Colors.Netural);

            paragraph.Add(authorText);
            paragraph.Add(languageText);

            return paragraph;
        }
    }

    private Paragraph DescriptionParagraph{
        get {
            Paragraph paragraph = new Paragraph();

            paragraph.SetPaddings(8, 12, 12, 12);
            paragraph.SetMarginTop(0);
            paragraph.SetFixedLeading(12);

            paragraph.SetBackgroundColor(Colors.BackgroundAccent);
            
            Text descriptionText = TextElementFactory.Generare(Description, Fonts.Book, FontSize.Normal, Colors.Accent);

            paragraph.Add(descriptionText);

            return paragraph;
        }
    }


   

    

    public void AddContent(Document document){
            document.SetLeftMargin(0);
            document.SetRightMargin(0);

            document.Add(Title(- document.GetTopMargin()));
            document.Add(SubTitle);
            document.Add(DescriptionParagraph);
            document.AddLogo();
            document.SetBackgroundColor(Colors.BackgroundMain);

            foreach (Card i in Cards){
                ((CardPdf)i).AddPdfComponent(document);
            }
    }

}
