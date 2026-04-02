using MarketingRESTAPI.Domain.Entities;

namespace MarketingRESTAPI.Application.Interfaces;

public interface IEmailTemplateGenerator
{
    string GenerateEmailTemplate(Lead lead, Sector sector);
}