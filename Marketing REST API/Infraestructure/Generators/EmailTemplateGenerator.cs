using MarketingRESTAPI.Application.Interfaces;
using MarketingRESTAPI.Domain.Entities;
using MarketingRESTAPI.Domain.Enums;

namespace MarketingRESTAPI.Infraestructure.Generators;

public class EmailTemplateGenerator : IEmailTemplateGenerator
{
    public string GenerateEmailTemplate(Lead lead, Sector sector)
    {
        var language = lead.PreferredLanguage;

        var greeting = language switch
        {
            Language.ES => "Hola",
            Language.EN => "Hello",
            Language.AR => "مرحبا",
            _ => "Hello"
        };

        var sectorName = sector.Names.GetValueOrDefault(language, "");
        var offer = sector.Offers.GetValueOrDefault(language, "");

        return $@"
        <html>
            <body>
                <p>{greeting} {lead.ContactPerson},</p>
                <p>We have a special proposal for <strong>{lead.CompanyName}</strong>.</p>
                <p><strong>Sector:</strong> {sectorName}</p>
                <p>{offer}</p>
            </body>
        </html>";
    }
}