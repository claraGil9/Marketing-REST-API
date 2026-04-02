using MarketingRESTAPI.Application.Interfaces;
using MarketingRESTAPI.Domain.Entities;
using MarketingRESTAPI.Domain.Enums;

using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace MarketingRESTAPI.Infraestructure.Generators;

public class PdfGenerator : IPdfGenerator
{
    public byte[] GeneratePdf(Lead lead, Sector sector)
    {
        var language = lead.PreferredLanguage;
        var sectorName = sector.Names.GetValueOrDefault(language, "");
        var offer = sector.Offers.GetValueOrDefault(language, "");

        var greeting = language switch
        {
            Language.ES => "Propuesta Comercial",
            Language.EN => "Business Proposal",
            Language.AR => "عرض تجاري",
            _ => "Business Proposal"
        };

        var document = Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Margin(30);
                page.Content().Column(col =>
                {
                    // Front page
                    col.Item().Text(greeting).FontSize(24).Bold();
                    col.Item().Text(lead.CompanyName).FontSize(18);
                    col.Item().Text(DateTime.UtcNow.ToString("yyyy-MM-dd"));

                    col.Item().PaddingVertical(10).LineHorizontal(1);

                    // 🔹 SECTOR
                    col.Item().Text($"Sector: {sectorName}").Bold();
                    col.Item().Text(offer);

                    // Contact info
                    col.Item().Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                        });

                        table.Cell().Text("Contact");
                        table.Cell().Text(lead.ContactPerson);

                        table.Cell().Text("Email");
                        table.Cell().Text(lead.Email);

                        table.Cell().Text("Budget");
                        table.Cell().Text(lead.Budget.ToString("C"));
                    });
                });
            });
        });
        return document.GeneratePdf();
    }
}