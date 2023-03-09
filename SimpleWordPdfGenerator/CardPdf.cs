using iText.Kernel.Colors;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using SimpleWordModels;

namespace SimpleWordPdfGenerator;

class CardPdf{
    Card _card;


    public CardPdf(Card card){
        _card = card;
    }


    public Document GetParagraph(Document document) {
        

        Cell comment = new Cell();
        comment.SetPaddingTop(6);
        comment.SetPaddingBottom(10);
        comment.SetPaddingLeft(6);
        Cell word = new Cell();
        word.SetPaddingLeft(8);
        word.SetPaddingBottom(8);
        word.SetPaddingTop(8);

        Paragraph wordParagraph = new Paragraph();
        //wordParagraph.SetMargins(0, 0, 0, 0);
        wordParagraph.SetPaddings(0, 6,0, 0);
        Text wordText = TextElementGenerator.GetElement(_card.Word, Fonts.Medium, 18, (10, 10, 10));
        wordParagraph.Add(wordText);
        wordParagraph.SetFixedLeading(16);
        word.Add(wordParagraph);
        word.SetBorderBottom(Border.NO_BORDER);
        word.SetBorderTop(Border.NO_BORDER);
        word.SetBorderLeft(Border.NO_BORDER);
        word.SetBorderRight(Border.NO_BORDER);

                Table table = new Table(2);
        table.SetBackgroundColor(new DeviceRgb(255, 204, 153));
        //table.SetBorderRadius(new BorderRadius(12));
        table.SetMargins(6, 12, 6, 12);  
        table.SetWidth(document.GetPdfDocument().GetDefaultPageSize().GetWidth() - 24);  
        table.AddCell(word);
        if (!(_card.Comment is null) && _card.Comment.Length != 0){
        word.SetBorderRight(new SolidBorder(new DeviceRgb(154, 41, 0), (float)0.5));
        /*else
        word.SetBorderRight(Border.NO_BORDER);*/
        
        Paragraph commentParagraph = new Paragraph();
        //Text textComment = TextElementGenerator.GetElement(_card.Comment, Fonts.Medium, 10, (10, 10, 10));


        commentParagraph.Add(TextElementGenerator.GetElement(_card.Comment ?? "", Fonts.Medium, 10, (154, 41, 0)));
        //commentParagraph.SetMargins(0, 0, 0, 0);
        comment.Add(commentParagraph);   
        comment.SetBorderBottom(Border.NO_BORDER);
        comment.SetBorderTop(Border.NO_BORDER);
        comment.SetBorderRight(Border.NO_BORDER);
        comment.SetBorderLeft(Border.NO_BORDER);
                table.AddCell(comment);

        }
        else{
            table.SetBorderRight(Border.NO_BORDER);

        }
        
        //table.AddCell(comment);


        document.Add(table);
        foreach (Translation i in _card.Translations){
            document = (new TranslationPdf(i)).GetPdf(document);
            if (i != _card.Translations[_card.Translations.Count - 1]){
                    SolidLine line = new SolidLine(1f);
                    line.SetColor(new DeviceRgb(154, 41, 0));
                    LineSeparator ls = new LineSeparator(line);
                    ls.SetMarginLeft(20);
                    ls.SetMarginRight(12);

                    document.Add(ls);
                }
        }
        return document;
        }
    }
