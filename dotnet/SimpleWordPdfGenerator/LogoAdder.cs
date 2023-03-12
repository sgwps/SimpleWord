using iText.Layout;
using iText.Layout.Element;
using iText.Svg.Converter;
using System.Xml;
using SimpleWord.ColorThemes;
namespace SimpleWord.PdfGenerator;

static class LogoAdder{
    public static void AddLogo(this Document document, ColorTheme theme){
        Image image = SvgConverter.ConvertToImage(new FileStream(Environment.GetEnvironmentVariable("METADATA_PATH")[1..^1] + "/" + theme.LogoFile, FileMode.Open), document.GetPdfDocument());
        image.SetFixedPosition(1, 20, document.GetPdfDocument().GetDefaultPageSize().GetHeight() - 80);
        image.ScaleToFit(70, 70);
        document.Add(image);
    }

}