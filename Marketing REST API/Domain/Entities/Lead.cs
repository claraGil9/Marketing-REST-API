using MarketingRESTAPI.Domain.Enums;

namespace MarketingRESTAPI.Domain.Entities;

public class Lead
{
    public int Id { get; set; }
    public string CompanyName { get; set; } = string.Empty;
    public string ContactPerson { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public int SectorId { get; set; }
    public decimal Budget { get; set; }
    public bool IsActive { get; set; }
    public Language PreferredLanguage { get; set; }     // Added to help tracing the sector's language
}