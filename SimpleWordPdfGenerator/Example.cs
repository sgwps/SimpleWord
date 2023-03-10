using iText.Layout.Element;
using SimpleWordModels;

namespace SimpleWordPdfGenerator;

class ExamplePdf : Example{

    public Paragraph PdfParagraph{
        get{
            Paragraph result = new Paragraph();
            result.SetPaddings(0, 24, 6, 20);
            result.SetMargins(0,0,0,0);

            result.Add(TextElementFactory.Generare(Origin, Fonts.Medium, FontSize.Normal, Colors.Accent));
            result.Add(TextElementFactory.Generare(ExampleTranslation, Fonts.Light, FontSize.SubText2, Colors.MainText));

            if (Comment != null) result.Add(TextElementFactory.Generare(Comment, Fonts.Light, FontSize.SubText2, Colors.SubText));
            if (Source != null) result.Add(TextElementFactory.Generare($"Source: {Source}", Fonts.Light, FontSize.SubText2, Colors.SubText));

            return result;
        }
    }
}