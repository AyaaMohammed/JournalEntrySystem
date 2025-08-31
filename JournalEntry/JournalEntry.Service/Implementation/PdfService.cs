using DinkToPdf;
using DinkToPdf.Contracts;
using JournalEntry.Data.Models;
using JournalEntry.Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JournalEntry.Service.Implementation
{
    public class PdfService : IPdfService
    {
        private readonly IConverter _converter;

        public PdfService(IConverter converter)
        {
            _converter = converter;
        }

        public byte[] GenerateJournalPdf(JournalHeader journal)
        {
            var html = $@"
            <html>
            <head>
            <style>
                table {{ width:100%; border-collapse: collapse; }}
                th, td {{ border:1px solid black; padding:5px; text-align:left; }}
            </style>
            </head>
            <body>
                <h2>Journal Entry #{journal.JournalID}</h2>
                <p>Date: {journal.EntryDate:yyyy-MM-dd}</p>
                <p>Description: {journal.Description}</p>
                <table>
                    <thead>
                        <tr>
                            <th>Account</th>
                            <th>Debit</th>
                            <th>Credit</th>
                            <th>Description</th>
                        </tr>
                    </thead>
                    <tbody>
                        {string.Join("", journal.JournalDetails.Select(d => $"<tr><td>{d.Account.NameEN}</td><td>{d.Debit}</td><td>{d.Credit}</td><td>{d.LineDescription}</td></tr>"))}
                    </tbody>
                </table>
            </body>
            </html>";

            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings = { PaperSize = PaperKind.A4, Orientation = Orientation.Portrait },
                Objects = { new ObjectSettings { HtmlContent = html } }
            };

            return _converter.Convert(doc);
        }
    }
}
