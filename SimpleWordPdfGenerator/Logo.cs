using iText.Layout;
using iText.Layout.Element;
using iText.Svg.Converter;

namespace SimpleWordPdfGenerator;

static class LogoAdder{
    public static void AddLogo(this Document document){
        Image image = SvgConverter.ConvertToImage(new FileStream("logo-light.svg", FileMode.Open), document.GetPdfDocument());
        image.SetFixedPosition(1, 20, document.GetPdfDocument().GetDefaultPageSize().GetHeight() - 80);
        image.ScaleToFit(70, 70);
        document.Add(image);
    }
}