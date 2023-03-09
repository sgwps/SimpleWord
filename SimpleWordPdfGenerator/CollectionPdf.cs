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

public class CollectionPdf
{
    private Collection _collection;

    Document _document;

    public CollectionPdf(Collection collection, Document document)
    {
        _collection = collection;
        _document = document;
    }

    public (Paragraph, Paragraph, Paragraph) Header
    {
        get
        {
            // lang-s
            Text title = TextElementGenerator.GetElement(_collection.Name, Fonts.Bold, 26, (245,245,220));
            Text author = TextElementGenerator.GetElement("by " + _collection.Author, Fonts.Light, 12, (255, 162, 122));
            Text language = TextElementGenerator.GetElement(_collection.LanguageDecription, Fonts.Light, 12, (255, 162, 122));



            Paragraph centered = new Paragraph();
            centered.SetPaddings(-6, 0, 12, 12);
            centered.SetMarginTop(0);

            centered.SetMarginBottom(0);
            centered.SetBackgroundColor(new DeviceRgb(154, 41, 0));
            centered.SetTextAlignment(TextAlignment.CENTER);
            centered.SetBorder(Border.NO_BORDER);

            Paragraph titleParagraph = new Paragraph();
            titleParagraph.SetPaddings(6, 0, 0, 12);
            titleParagraph.SetMarginTop(-_document.GetTopMargin());
            titleParagraph.SetMarginBottom(0);
            titleParagraph.SetBackgroundColor(new DeviceRgb(154, 41, 0));
            titleParagraph.SetTextAlignment(TextAlignment.CENTER);
            titleParagraph.SetBorder(Border.NO_BORDER);

            titleParagraph.Add(title);
            centered.Add(author);
            centered.Add(language);
            centered.SetFixedLeading(20);


            Paragraph decription = ParagraphElementGenerator.GetElement(
                _collection.Description,
                Fonts.Book,
                12
            );
            decription.SetFixedLeading(12);
            decription.SetBackgroundColor(new DeviceRgb(245,245,220));
            decription.SetMarginTop(0);
            decription.SetFontColor(new DeviceRgb(154, 41, 0));
            decription.SetPaddings(8, 12, 12, 12);
            


            return (titleParagraph, centered, decription);
        }
    }


    public Document GetPdf{
        get{
            (Paragraph, Paragraph, Paragraph) header = Header;
            _document.SetRightMargin(0);
            _document.SetLeftMargin(0);
            _document.Add(header.Item1);
            _document.Add(header.Item2);
            


            _document.Add(header.Item3);
            Image image = SvgConverter.ConvertToImage(new FileStream("logo-light.svg", FileMode.Open), _document.GetPdfDocument());
    
            image.SetFixedPosition(1, 20, _document.GetPdfDocument().GetDefaultPageSize().GetHeight() - 80);
            image.ScaleToFit(70, 70);
            _document.Add(image);
            //_document.Add(new AreaBreak(AreaBreakType.NEXT_AREA));
            

            foreach (Card i in _collection.Cards){
                _document = (new CardPdf(i)).GetParagraph(_document);
            }
            return _document;
        }
    }

}
