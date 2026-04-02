using MarketingRESTAPI.Domain.Enums;

namespace MarketingRESTAPI.Domain.Entities;

public class Sector
{
    public int Id { get; set; }

    // Using a dictionaries for multiple language scalability
    public Dictionary<Language, string> Names { get; set; } = new();
    public Dictionary<Language, string> Offers { get; set; } = new();
}