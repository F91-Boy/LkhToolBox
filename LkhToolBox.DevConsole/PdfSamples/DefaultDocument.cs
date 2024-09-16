using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LkhToolBox.DevConsole.PdfSamples
{
    public static class DefaultDocument
    {
        public static Document GenerateDocument()
        {
            var document = QuestPDF.Fluent.Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(pageSize: PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(20));


                    page.Header()
                    .Text("你好 PDF! 我变了")
                    .SemiBold().FontSize(36).FontColor(Colors.Blue.Medium);

                    page.Content()
                    .PaddingVertical(1, Unit.Centimetre)
                    .Column(x =>
                    {
                        x.Spacing(20);

                        x.Item().Text(Placeholders.LoremIpsum());
                        x.Item().Image(Placeholders.Image(200, 100));
                    });

                    page.Footer()
                    .AlignCenter()
                    .Text(x =>
                    {
                        x.Span("Page ");
                        x.CurrentPageNumber();
                    });

                });

            });

            return document;
        }
    }
}
