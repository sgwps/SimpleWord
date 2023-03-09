using iText.IO.Font;
using iText.Kernel.Font;

namespace SimpleWordPdfGenerator;

static internal class Fonts{
    private static PdfFont GetFont(string Font){
        FontProgram fontProgram = FontProgramFactory.CreateFont($"Fonts/FuturaPT-{Font}.ttf");
        return PdfFontFactory.CreateFont(fontProgram);
    }

    public static PdfFont Medium{
        get{
            return GetFont("Medium");
        }
    } 


    public static PdfFont Bold{
        get{
            return GetFont("Bold");
        }
    } 


    public static PdfFont Book{
        get{
            return GetFont("Book");
        }
    } 


    public static PdfFont Light{
        get{
            return GetFont("Light");
        }
    } 
} 