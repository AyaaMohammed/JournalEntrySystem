using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using JournalEntry.Data.Models;
using JournalEntry.Service.Abstracts;
using System.Linq;

namespace JournalEntry.Service.Implementation
{
    public class PdfService : IPdfService
    {
        public byte[] GenerateJournalPdf(JournalHeader journal)
        {
            var pdf = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);
                    page.DefaultTextStyle(x => x.FontSize(12));

                    page.Header().Text($"Journal Entry #{journal?.JournalID}")
                        .SemiBold().FontSize(20).AlignCenter();

                    page.Content().Column(col =>
                    {
                        col.Spacing(10);

                        col.Item().Text($"Date: {journal?.EntryDate:yyyy-MM-dd}");
                        col.Item().Text($"Description: {journal?.Description ?? "N/A"}");

                        col.Item().Table(table =>
                        {
                            table.ColumnsDefinition(cols =>
                            {
                                cols.ConstantColumn(150); // Account
                                cols.RelativeColumn();    // Debit
                                cols.RelativeColumn();    // Credit
                                cols.RelativeColumn();    // Description
                            });

                            // Header
                            table.Header(header =>
                            {
                                header.Cell().Text("Account").SemiBold();
                                header.Cell().Text("Debit").SemiBold();
                                header.Cell().Text("Credit").SemiBold();
                                header.Cell().Text("Description").SemiBold();
                            });

                            // Rows
                            if (journal?.JournalDetails != null && journal.JournalDetails.Any())
                            {
                                foreach (var d in journal.JournalDetails)
                                {
                                    table.Cell().Text(d?.Account?.NameEN ?? "N/A");
                                    table.Cell().Text(d?.Debit.ToString() ?? "0");
                                    table.Cell().Text(d?.Credit.ToString() ?? "0");
                                    table.Cell().Text(d?.LineDescription ?? "");
                                }
                            }
                            else
                            {
                                table.Cell().ColumnSpan(4).AlignCenter()
                                    .Text("No journal details available").Italic();
                            }
                        });
                    });

                    page.Footer()
                        .AlignCenter()
                        .Text(x =>
                        {
                            x.Span("Generated with QuestPDF - ").FontSize(10);
                            x.Span(System.DateTime.Now.ToString("g")).FontSize(10);
                        });
                });
            });

            return pdf.GeneratePdf();
        }
    }
}
