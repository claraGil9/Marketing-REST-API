using MarketingRESTAPI.Domain.Entities;

public interface ILeadRepository
{
    Task<List<Lead>> GetAllAsync();
}

public interface ISectorRepository
{
    Task<List<Sector>> GetAllAsync();
}