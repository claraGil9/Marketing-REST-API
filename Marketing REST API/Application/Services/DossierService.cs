using MarketingRESTAPI.Application.Interfaces;
using MarketingRESTAPI.Domain.Entities;

namespace MarketingRESTAPI.Application.Services;

public class DossierService : IDossierService
{
    private readonly ILeadRepository _leadRepository;
    private readonly ISectorRepository _sectorRepository;
    private readonly IPdfGenerator _pdfGenerator;

    public DossierService(
        ILeadRepository leadRepository,
        ISectorRepository sectorRepository,
        IPdfGenerator pdfGenerator)
    {
        _leadRepository = leadRepository;
        _sectorRepository = sectorRepository;
        _pdfGenerator = pdfGenerator;
    }

    public async Task<byte[]?> GenerateDossierAsync(int leadId)
    {
        var leads = await _leadRepository.GetAllAsync();
        var sectors = await _sectorRepository.GetAllAsync();

        var lead = leads.FirstOrDefault(l => l.Id == leadId);
        if (lead == null)
            return null;

        var sector = sectors.FirstOrDefault(s => s.Id == lead.SectorId);
        if (sector == null)
            return null;

        return _pdfGenerator.GeneratePdf(lead, sector);
    }
}