using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Layout.Element;
using SimpleWord.ColorThemes;
using SimpleWord.Font;

namespace SimpleWord.PdfGenerator;

static internal class TextElementFactory{
    


    public static Text Generare(string? content, PdfFont font, FontSize size, Color color  ){
        if (content is null) throw new ArgumentException("Null content value");
        Text title = new Text($"{content}\n");
        title.SetFont(font);
        int sizeInt = (int)size;
        title.SetFontSize(sizeInt);
        title.SetFontColor(color);
        return title;
    }

    
}

