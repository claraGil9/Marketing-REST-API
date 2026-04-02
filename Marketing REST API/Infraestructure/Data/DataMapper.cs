using MarketingRESTAPI.Domain.Entities;
using MarketingRESTAPI.Domain.Enums;
using System.Reflection.Metadata.Ecma335;

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
                    Budget = decimal.TryParse(row["Budget"], out var budget) ? budget : 0,
                    IsActive = row["Is_Active"] == "true" || row["Is_Active"] == "1",
                    PreferredLanguage = 0
                };

                if (!string.IsNullOrEmpty(lead.Email))
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