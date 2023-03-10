using iText.Kernel.Colors;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using SimpleWordModels;

namespace SimpleWordPdfGenerator;

class CardPdf : Card{
    private Cell CommentCell{
        get{
            Cell cell = new Cell();
            cell.SetPaddingTop(6);
            cell.SetPaddingBottom(10);
            cell.SetPaddingLeft(6);

            cell.SetBorder(Border.NO_BORDER);
            cell.SetBorderLeft(new SolidBorder(Colors.Accent, (float)0.5));


            Paragraph paragraph = new Paragraph();

            paragraph.Add(TextElementFactory.Generare(Comment, Fonts.Medium, FontSize.SubText1, Colors.Accent));
            cell.Add(paragraph);   

            return cell;
        }
    }


    private Cell WordCell {
        get {
            Cell cell = new Cell();
            cell.SetPaddingTop(8);
            cell.SetPaddingBottom(8);
            cell.SetPaddingLeft(8);
            cell.SetPaddingRight(0);
            
            cell.SetBorder(Border.NO_BORDER);

            Paragraph paragraph = new Paragraph();
            paragraph.SetPaddings(0, 6, 0, 0);
            paragraph.SetFixedLeading(16);

            paragraph.Add(TextElementFactory.Generare(Word, Fonts.Medium, FontSize.AccentText1, Colors.MainText));
            cell.Add(paragraph);

            return cell;
        }
    }


    private Table Table(float width){
            Table table = new Table(2);
            table.SetMargins(6, 12, 6, 12); 
            table.SetWidth(width); 

            table.SetBorder(Border.NO_BORDER);
            table.SetBackgroundColor(Colors.Netural);  //было 255, 204, 153

            table.AddCell(WordCell);
            if (!(Comment is null) && Comment.Length != 0) {
                table.AddCell(CommentCell);
            }

            return table;
    }

    private LineSeparator Separator{
        get{
            SolidLine line = new SolidLine(1f);
            line.SetColor(Colors.Accent);
            LineSeparator separator = new LineSeparator(line);
            separator.SetMarginLeft(20);
            separator.SetMarginRight(12);
            return separator;
        }
    }





    


    public void AddPdfComponent(Document document) {
        
        document.Add(Table(document.GetPdfDocument().GetDefaultPageSize().GetWidth() - 24));
        foreach (Translation i in Translations.ToArray()[..^1]){
            ((TranslationPdf)i).AddPdfComponent(document);
            document.Add(Separator);
        }
        ((TranslationPdf)Translations.ToArray()[^1]).AddPdfComponent(document);
        }
    }
