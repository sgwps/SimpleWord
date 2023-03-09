using iText.Layout.Element;
using SimpleWordModels;

namespace SimpleWordPdfGenerator;

class ExamplePdf{

    Example _example;

    public ExamplePdf(Example example){
        _example = example;
    }

    public Paragraph GetPdf{
        get{
            Paragraph result = new Paragraph();
            result.SetPaddings(0, 24, 6, 20);
            result.SetMargins(0,0,0,0);
            result.Add(TextElementGenerator.GetElement(_example.Origin, Fonts.Medium, 12, (10, 10, 10)));
            result.Add(TextElementGenerator.GetElement(_example.ExampleTranslation, Fonts.Light, 8, (154, 41, 0)));
            if (_example.Comment != null) result.Add(TextElementGenerator.GetElement(_example.Comment, Fonts.Light, 8, (67, 67, 67)));
            if (_example.Source != null) result.Add(TextElementGenerator.GetElement($"Source: {_example.Source}", Fonts.Light, 8, (67, 67, 67)));
            return result;
        }
    }
}