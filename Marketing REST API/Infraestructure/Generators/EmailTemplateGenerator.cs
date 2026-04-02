using MarketingRESTAPI.Application.Interfaces;
using MarketingRESTAPI.Domain.Entities;
using MarketingRESTAPI.Domain.Enums;
using MarketingRESTAPI.Shared.Constants;

namespace MarketingRESTAPI.Infraestructure.Generators;

public class EmailTemplateGenerator : IEmailTemplateGenerator
{
    public string GenerateEmailTemplate(Lead lead, Sector sector)
    {
        var language = lead.PreferredLanguage;

        var greeting = Translations.GetGreeting(language);
        var intro = Translations.GetEmailIntro(language, lead.CompanyName);
        var sectorLabel = Translations.GetSectorLabel(language);
        var sectorName = sector.Names.GetValueOrDefault(language, "");
        var offer = sector.Offers.GetValueOrDefault(language, "");

        return $@"
        <html>
        <body style='font-family: Arial, sans-serif; background-color:#f4f4f4; padding:20px;'>

            <table width='100%' cellpadding='0' cellspacing='0'>
                <tr>
                    <td align='center'>
                        <table width='600' style='background:white; padding:20px; border-radius:8px;'>

                            <tr>
                                <td>
                                    <h2 style='color:#333;'>{greeting} {lead.ContactPerson},</h2>

                                    <p style='color:#555; font-size:14px;'>
                                        {intro}
                                    </p>

                                    <hr/>

                                    <p><strong>{sectorLabel}:</strong> {sectorName}</p>

                                    <p style='color:#444;'>
                                        {offer}
                                    </p>

                                    <br/>

                                    <a href='#' style='
                                        display:inline-block;
                                        padding:10px 20px;
                                        background:#007BFF;
                                        color:white;
                                        text-decoration:none;
                                        border-radius:5px;'>
                                        View Proposal
                                    </a>

                                </td>
                            </tr>

                        </table>
                    </td>
                </tr>
            </table>

        </body>
        </html>";
    }
}