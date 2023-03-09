using iText.Kernel.Colors;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using SimpleWordModels;

namespace SimpleWordPdfGenerator;

class TranslationPdf{

    Translation _translation;

    public TranslationPdf(Translation translation){
        _translation = translation;
    }

    public Document GetPdf (Document document){
            Cell word = new Cell();
            word.SetPaddings(4,0,2,6);
            word.SetMargins(0,0,0,0);
            Paragraph wordParagraph = new Paragraph();
            wordParagraph.SetMargins(0, 0, 0, 0);
            wordParagraph.SetPaddings(0, 0, 0, 0);
            wordParagraph.SetFixedLeading(16);


            Text wordText = TextElementGenerator.GetElement(_translation.Value, Fonts.Medium, 16, (10, 10, 10));
            wordParagraph.Add(wordText);
            word.Add(wordParagraph);
            word.SetBorderBottom(Border.NO_BORDER);
            word.SetBorderTop(Border.NO_BORDER);
            word.SetBorderLeft(Border.NO_BORDER);
            word.SetBorderRight(Border.NO_BORDER);
            Table table = new Table(1);
            table.AddCell(word);

            if (!(_translation.Comment is null) && _translation.Comment.Length != 0){
            Cell comment = new Cell();
            comment.SetPaddings(0,0,0,0);
            comment.SetMargins(0,0,0,0);

            Paragraph commentParagraph = new Paragraph();

            commentParagraph.Add(TextElementGenerator.GetElement(_translation.Comment, Fonts.Medium, 8, (10, 10, 10)));
            commentParagraph.SetMargins(0, 0, 0, 0);
            commentParagraph.SetPaddings(0,0,0,6);
            comment.Add(commentParagraph);   
            comment.SetBorderBottom(Border.NO_BORDER);
            comment.SetBorderTop(Border.NO_BORDER);
            comment.SetBorderRight(Border.NO_BORDER);
            comment.SetBorderLeft(Border.NO_BORDER);
                        table.AddCell(comment);

            }
            table.SetMargins(6, 12, 6, 20);   
            table.SetPaddings(0,0,0,0);   
            table.SetBorderLeft(new SolidBorder(new DeviceRgb(154, 41, 0), (float)0.5));


            document.Add(table);
            foreach (Example i in _translation.Examples){
                document.Add((new ExamplePdf(i)).GetPdf);
            }
            return document;
    }
}