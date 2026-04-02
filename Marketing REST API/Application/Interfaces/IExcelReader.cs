namespace MarketingRESTAPI.Application.Interfaces;

public interface IExcelReader
{
    List<Dictionary<string, string>> Read(string filePath);
}