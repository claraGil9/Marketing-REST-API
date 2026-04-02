using MarketingRESTAPI.Domain.Entities;

namespace MarketingRESTAPI.Application.Interfaces;

public interface IPdfGenerator
{
    byte[] GeneratePdf(Lead lead, Sector sector);
}