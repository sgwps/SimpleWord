using iText.Layout.Element;
using SimpleWord.Models;
using SimpleWord.ColorThemes;
using SimpleWord.Font;

namespace SimpleWord.PdfGenerator;

class ExamplePdf{

    Example _example;
    ColorTheme _colorTheme;

    public Paragraph PdfParagraph{
        get{
            Paragraph result = new Paragraph();
            result.SetPaddings(0, 24, 6, 20);
            result.SetMargins(0,0,0,0);
            result.SetFixedLeading(12);

            result.Add(TextElementFactory.Generare(_example.Origin, FontSet.Medium, FontSize.Normal, _colorTheme.Accent));
            result.Add(TextElementFactory.Generare(_example.ExampleTranslation, FontSet.Book, FontSize.SubText1, _colorTheme.MainText));

            if (_example.Comment != null) result.Add(TextElementFactory.Generare(_example.Comment, FontSet.Light, FontSize.SubText1, _colorTheme.SubText));
            if (_example.Source != null) result.Add(TextElementFactory.Generare($"Source: {_example.Source}", FontSet.Light, FontSize.SubText1, _colorTheme.SubText));

            return result;
        }
    }

    public ExamplePdf(Example example, ColorTheme colorTheme){
        _example = example;
        _colorTheme = colorTheme;
    }
}