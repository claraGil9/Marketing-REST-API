using ClosedXML.Excel;
using MarketingRESTAPI.Application.Interfaces;
using MarketingRESTAPI.Domain.Entities;

namespace MarketingRESTAPI.Infraestructure.FileReaders;

public class ExcelReader : IExcelReader
{
    public List<Dictionary<string, string>> Read(string filePath)
    {
        var excelList = new List<Dictionary<string, string>>();
        try
        {
            using var workbook = new XLWorkbook(filePath);
            if (workbook == null)
                throw new FileNotFoundException("Excel file not found");

            foreach (var worksheet in workbook.Worksheets)
            {
                var rows = worksheet.RowsUsed().ToList();
                var headers = rows.First()
                                  .Cells()
                                  .Select(c => c.GetString().Trim())
                                  .ToList();

                foreach (var row in rows.Skip(1))
                {
                    var rowValues = new Dictionary<string, string>();
                    for (int i = 0; i < headers.Count; i++)
                    {
                        var value = row.Cell(i + 1).GetString();
                        rowValues[headers[i]] = value;
                    }
                    excelList.Add(rowValues);
                }
            }
        }
        catch (Exception ex) 
        {
            Console.WriteLine(ex.Message);
        }
        return excelList;
    }
}