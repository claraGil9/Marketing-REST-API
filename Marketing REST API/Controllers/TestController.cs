using Microsoft.AspNetCore.Mvc;
using MarketingRESTAPI.Application.Interfaces;

namespace MarketingRESTAPI.Controllers;

[ApiController]
[Route("api/test")]
public class TestController : ControllerBase
{
    private readonly ILeadRepository _leadRepository;
    private readonly ISectorRepository _sectorRepository;

    public TestController(ILeadRepository leadRepository, ISectorRepository sectorRepository)
    {
        _leadRepository = leadRepository;
        _sectorRepository = sectorRepository;
    }

    [HttpGet("leads")]
    public async Task<IActionResult> GetLeads()
    {
        var leads = await _leadRepository.GetAllAsync();
        return Ok(leads);
    }

    [HttpGet("sectors")]
    public async Task<IActionResult> GetSectors()
    {
        var sectors = await _sectorRepository.GetAllAsync();
        return Ok(sectors);
    }
}