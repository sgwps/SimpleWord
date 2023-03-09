using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Layout.Element;


namespace SimpleWordPdfGenerator;

static internal class TextElementGenerator{
    public static Text GetElement(string content, PdfFont font, int size){
        
        Text title = new Text($"{content}\n");
        title.SetFont(font);
        title.SetFontSize(size);
        return title;
    }


    public static Text GetElement(string content, PdfFont font, int size, (int, int, int) color  ){
        
        Text title = new Text($"{content}\n");
        title.SetFont(font);
        title.SetFontSize(size);
        title.SetFontColor(new DeviceRgb(color.Item1, color.Item2, color.Item3));
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
