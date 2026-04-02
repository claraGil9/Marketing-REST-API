using MarketingRESTAPI.Application.Interfaces;
using MarketingRESTAPI.Domain.Entities;
using MarketingRESTAPI.Domain.Enums;
using MarketingRESTAPI.Shared.Constants;

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

        var greeting = Translations.GetGreeting(language);

        var document = Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Margin(30);
                page.Content().Column(col =>
                {
                    // Header
                    col.Item().Text(greeting).FontSize(26).Bold().FontColor(Colors.Blue.Darken2);
                    col.Item().Text(lead.CompanyName).FontSize(18).SemiBold();
                    col.Item().Text(DateTime.UtcNow.ToString("yyyy-MM-dd")).FontSize(10).FontColor(Colors.Grey.Medium);

                    col.Item().PaddingVertical(10).LineHorizontal(1);

                    // 🔹 SECTOR
                    col.Item().Text($"{Translations.GetSectorLabel(language)}: {sectorName}").FontSize(16).Bold();
                    col.Item().Text(offer).FontSize(12);

                    col.Item().PaddingVertical(10).LineHorizontal(1);

                    // Contact info
                    col.Item().Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                        });

                        table.Cell().Text(Translations.GetContactLabel(language));
                        table.Cell().Text(lead.ContactPerson);

                        table.Cell().Text(Translations.GetEmailtLabel(language));
                        table.Cell().Text(lead.Email);

                        table.Cell().Text(Translations.GetBudgetLabel(language));
                        table.Cell().Text(lead.Budget.ToString("C"));
                    });
                });
            });
        });
        return document.GeneratePdf();
    }
}