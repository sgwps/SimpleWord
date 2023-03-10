using iText.Kernel.Colors;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using SimpleWordModels;

namespace SimpleWordPdfGenerator;

class TranslationPdf : Translation{

    public Cell ValueCell{
        get{
            Cell cell = new Cell();
            cell.SetPaddings(4,0,2,6);
            cell.SetMargins(0,0,0,0);

            Paragraph paragraph = new Paragraph();
            paragraph.SetMargins(0, 0, 0, 0);
            paragraph.SetPaddings(0, 0, 0, 0);
            paragraph.SetFixedLeading(16);

            paragraph.SetBorder(Border.NO_BORDER);
            

            Text text = TextElementFactory.Generare(Value, Fonts.Medium, FontSize.AccentText2, (10, 10, 10));

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

            paragraph.Add(TextElementFactory.Generare(Comment, Fonts.Medium, FontSize.SubText2, Colors.MainText));
            cell.Add(paragraph);   

            return cell;
        }
    }

    public Table Table{
        get{
            Table table = new Table(1);
            table.SetMargins(6, 12, 6, 20);   
            table.SetPaddings(0,0,0,0);  

            table.SetBorderLeft(new SolidBorder(Colors.Accent, (float)0.5));


            table.AddCell(ValueCell);
            if (!(Comment is null) && Comment.Length != 0){
                table.AddCell(CommentCell);
            }

            return table;
        }
    }

    public void AddPdfComponent (Document document){
        document.Add(Table);
        foreach (Example i in Examples){
            document.Add(((ExamplePdf)i).PdfParagraph);
        }
    }
}