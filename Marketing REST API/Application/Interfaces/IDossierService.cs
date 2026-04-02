namespace MarketingRESTAPI.Application.Interfaces;

public interface IDossierService
{
    Task<byte[]?> GenerateDossierAsync(int leadId);
}