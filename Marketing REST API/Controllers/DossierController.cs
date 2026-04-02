using Microsoft.AspNetCore.Mvc;
using MarketingRESTAPI.Application.Interfaces;

namespace MarketingCampaignAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DossierController : ControllerBase
{
    private readonly IDossierService _dossierService;

    public DossierController(IDossierService dossierService)
    {
        _dossierService = dossierService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var pdf = await _dossierService.GenerateDossierAsync(id);
        if (pdf == null)
            return NotFound();

        return File(pdf, "application/pdf", $"dossier_{id}.pdf");
    }
}