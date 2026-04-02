using MarketingRESTAPI.Domain.Entities;
using MarketingRESTAPI.Domain.Enums;
using MarketingRESTAPI.Shared.Helpers;

namespace MarketingRESTAPI.Infraestructure.Data;

public static class DataMapper
{
    public static List<Lead> MapLeads(List<Dictionary<string, string>> rows)
    {
        var leads = new List<Lead>();

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
                    IsActive = DataNormalizer.NormalizeIsActive(row["Is_Active"]),
                    PreferredLanguage = DataNormalizer.NormalizeLanguage(row["Lang_Code"])
                };

                if (lead.Id != 0 && lead.SectorId != 0 && !string.IsNullOrEmpty(lead.Email))
                    leads.Add(lead);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error mapping row: {ex.Message}");
                continue;
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
                var names = new Dictionary<Language, string>();
                names[Language.ES] = row.GetValueOrDefault("Name_ES", "");
                names[Language.EN] = row.GetValueOrDefault("Name_EN", "");
                names[Language.AR] = row.GetValueOrDefault("Name_AR", "");

                var offers = new Dictionary<Language, string>();
                offers[Language.ES] = row.GetValueOrDefault("Offer_ES", "");
                offers[Language.EN] = row.GetValueOrDefault("Offer_EN", "");
                offers[Language.AR] = row.GetValueOrDefault("Offer_AR", "");

                var sector = new Sector
                {
                    Id = int.TryParse(row["Sector_ID"], out var id) ? id : 0,
                    Names = names,
                    Offers = offers

                };
                sectors.Add(sector);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error mapping row: {ex.Message}");
                continue;
            }
        }
        Console.WriteLine(sectors);
        return sectors;
    }
}