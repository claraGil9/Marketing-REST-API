using MarketingRESTAPI.Application.DTOs;
using MarketingRESTAPI.Application.Interfaces;
using MarketingRESTAPI.Domain.Entities;

namespace MarketingCampaignAPI.Application.Services;

public class MailingService : IMailingService
{
    private readonly ILeadRepository _leadRepository;
    private readonly ISectorRepository _sectorRepository;
    private readonly IEmailTemplateGenerator _templateGenerator;

    public MailingService(
        ILeadRepository leadRepository,
        ISectorRepository sectorRepository,
        IEmailTemplateGenerator templateGenerator )
    {
        _leadRepository = leadRepository;
        _sectorRepository = sectorRepository;
        _templateGenerator = templateGenerator;
    }

    public async Task<List<EmailDto>> SendEmailsAsync()
    {
        var leads = await _leadRepository.GetAllAsync();
        var sectors = await _sectorRepository.GetAllAsync();

        // Filters
        var emails = new List<EmailDto>();
        var filteredLeads = leads.Where(l => l.IsActive && l.Budget >= 10000).ToList();

        foreach (var lead in filteredLeads)
        {
            var sector = sectors.FirstOrDefault(s => s.Id == lead.SectorId);
            if (sector == null)
                continue;

            var body = _templateGenerator.GenerateEmailTemplate(lead, sector);
            var email = new EmailDto
            {
                To = lead.Email,
                Subject = $"Proposal for {lead.CompanyName}",
                Body = body
            };
            emails.Add(email);
        }
        return emails;
    }
}