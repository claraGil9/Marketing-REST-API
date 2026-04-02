using MarketingRESTAPI.Application.DTOs;

namespace MarketingRESTAPI.Application.Interfaces;

public interface IMailingService
{
    Task<List<EmailDto>> SendEmailsAsync();
}