namespace MarketingRESTAPI.Application.DTOs;

public class EmailDto
{
    public string To { get; set; } = string.Empty;
    public string From { get; set; } = "example_email@techtitute.com";
    public string Subject { get; set; } = string.Empty;
    public string Body { get; set; } = string.Empty;
}