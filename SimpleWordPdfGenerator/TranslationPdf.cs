using iText.Kernel.Colors;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using SimpleWord.ColorThemes;
using SimpleWord.Font;
using SimpleWord.Models;

namespace SimpleWord.PdfGenerator;

class TranslationPdf {
    Translation _translation;
    ColorTheme _colorTheme;
    public TranslationPdf(Translation translation, ColorTheme colorTheme){
        _translation = translation;
        _colorTheme = colorTheme;
    }

    public Cell ValueCell{
        get{
            Cell cell = new Cell();
            cell.SetPaddings(4,0,2,6);
            cell.SetMargins(0,0,0,0);
            cell.SetBorder(Border.NO_BORDER);


            Paragraph paragraph = new Paragraph();
            paragraph.SetMargins(0, 0, 0, 0);
            paragraph.SetPaddings(0, 0, 0, 0);
            paragraph.SetFixedLeading(16);            

            Text text = TextElementFactory.Generare(_translation.Value, FontSet.Medium, FontSize.AccentText2, _colorTheme.MainText);

            paragraph.Add(text);
            cell.Add(paragraph);

            return cell;
        }
    }


    public Cell CommentCell{
        get{
            Cell cell = new Cell();
            cell.SetPaddings(0,0,0,0);
            cell.SetMargins(0,0,0,0);
            cell.SetBorder(Border.NO_BORDER);

            Paragraph paragraph = new Paragraph();
            paragraph.SetMargins(0, 0, 0, 0);
            paragraph.SetPaddings(0,0,0,6);

            paragraph.Add(TextElementFactory.Generare(_translation.Comment, FontSet.Medium, FontSize.SubText2, _colorTheme.MainText));
            cell.Add(paragraph);   

            return cell;
        }
    }

    public Table Table{
        get{
            Table table = new Table(1);
            table.SetMargins(6, 12, 6, 20);   
            table.SetPaddings(0,0,0,0);  

            table.SetBorder(Border.NO_BORDER);
            table.SetBorderLeft(new SolidBorder(_colorTheme.Accent, (float)0.5));


            table.AddCell(ValueCell);
            if (!(_translation.Comment is null) && _translation.Comment.Length != 0){
                table.AddCell(CommentCell);
            }

            return table;
        }
    }

    public void AddPdfComponent (Document document){
        document.Add(Table);
        foreach (Example i in _translation.Examples){
            document.Add((new ExamplePdf(i, _colorTheme)).PdfParagraph);
        }
    }


}