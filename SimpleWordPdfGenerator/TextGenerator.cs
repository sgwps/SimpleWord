using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Layout.Element;


namespace SimpleWordPdfGenerator;

static internal class TextElementFactory{
    public static Text Generate(string content, PdfFont font, int size){
        
        Text title = new Text($"{content}\n");
        title.SetFont(font);
        title.SetFontSize(size);
        return title;
    }


    public static Text Generare(string content, PdfFont font, int size, (int, int, int) color  ){
        
        Text title = new Text($"{content}\n");
        title.SetFont(font);
        title.SetFontSize(size);
        title.SetFontColor(new DeviceRgb(color.Item1, color.Item2, color.Item3));
        return title;
    }


    public static Text Generare(string? content, PdfFont font, FontSize size, (int, int, int) color  ){
        if (content is null) throw new ArgumentException("Null content value");
        Text title = new Text($"{content}\n");
        title.SetFont(font);
        int sizeInt = (int)size;
        title.SetFontSize(sizeInt);
        title.SetFontColor(new DeviceRgb(color.Item1, color.Item2, color.Item3));
        return title;
    }


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


static internal class ParagraphElementGenerator{
    public static Paragraph GetElement(string content, PdfFont font, int size){
        Paragraph title = new Paragraph($"{content}\n");
        title.SetFont(font);
        title.SetFontSize(size);
        return title;
    }
}
