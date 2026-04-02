using ClosedXML.Excel;
using MarketingRESTAPI.Application.Interfaces;

namespace MarketingRESTAPI.Infraestructure.FileReaders;

public class ExcelReader : IExcelReader
{
    public List<Dictionary<string, string>> Read(string filePath)
    {
        var excelList = new List<Dictionary<string, string>>();

        using var workbook = new XLWorkbook(filePath);
        foreach (var worksheet in workbook.Worksheets)
        {
            var rows = worksheet.RowsUsed().ToList();
            var headers = rows.First().Cells().Select(c => c.GetString()).ToList();
            //var rows_1 = worksheet.RangeUsed().RowsUsed().ToList();

            foreach (var row in rows.Skip(1))
            {
                var rowValues = new Dictionary<string, string>();
                for (int i = 1; i <= headers.Count; i++)
                {
                    var value = row.Cell(i).GetString();
                    rowValues[headers[i - 1]] = value;
                }
                excelList.Add(rowValues);
            }
        }
        return excelList;
    }
}