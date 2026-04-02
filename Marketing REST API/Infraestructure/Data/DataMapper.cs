using MarketingRESTAPI.Domain.Entities;
using MarketingRESTAPI.Domain.Enums;
using MarketingRESTAPI.Shared.Helpers;

namespace MarketingRESTAPI.Infraestructure.Data;

public static class DataMapper
{
    public static List<Lead> MapLeads(List<Dictionary<string, string>> rows)
    {
        var leads = new List<Lead>();
        var random = new Random();

        foreach (var row in rows)
        {
            try
            {
                var lead = new Lead
                {
                    Id = int.TryParse(row["ID"], out var id) ? id : 0,                              // Lead ID == 0 => no lead found
                    CompanyName = row["Company_Name"]?.Trim() ?? string.Empty,
                    ContactPerson = row["Contact_Person"]?.Trim() ?? string.Empty,
                    Email = row["Email"]?.Trim() ?? string.Empty,
                    SectorId = int.TryParse(row["Sector_ID"], out var sectorId) ? sectorId : 0,     // Sector ID == 0 => no sector found
                    Budget = DataNormalizer.NormalizeBudget(row["Budget"]),
                    IsActive = DataNormalizer.NormalizeIsActive(row["IsActive"]),
                    PreferredLanguage = DataNormalizer.NormalizeLanguage(row["Lang_Code"])
                };

                if (lead.Id != 0 && lead.SectorId != 0 && !string.IsNullOrEmpty(lead.Email))
                    leads.Add(lead);
            }
            catch (Exception ex)
            {
            }
        }
        return leads;
    }

    public static List<Sector> MapSectors(List<Dictionary<string, string>> rows)
    {
        var sectors = new List<Sector>();
        foreach (var row in rows)
        {
            try
            {
                var sector = new Sector
                {
                    Id = int.TryParse(row["Sector_ID"], out var id) ? id : 0,
                    Names = new Dictionary<Language, string>
                    {
                        { Language.ES, row.GetValueOrDefault("Name_ES", "") },
                        { Language.ES, row.GetValueOrDefault("Name_EN", "") },
                        { Language.ES, row.GetValueOrDefault("Name_AR", "") }
                    },
                    Offers = new Dictionary<Language, string>
                    {
                        { Language.ES, row.GetValueOrDefault("Offer_ES", "") },
                        { Language.ES, row.GetValueOrDefault("Offer_EN", "") },
                        { Language.ES, row.GetValueOrDefault("Offer_AR", "") }
                    }
                };
                sectors.Add(sector);
            }
            catch { }
        }
        return sectors;
    }
}