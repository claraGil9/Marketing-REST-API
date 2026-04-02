using Microsoft.AspNetCore.Mvc;
using MarketingRESTAPI.Application.Interfaces;

namespace MarketingRESTAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MailingController : ControllerBase
{
    private readonly IMailingService _mailingService;

    public MailingController(IMailingService mailingService)
    {
        _mailingService = mailingService;
    }

    [HttpPost("send")]
    public async Task<IActionResult> Send()
    {
        var result = await _mailingService.SendEmailsAsync();
        return Ok(result);
    }
}