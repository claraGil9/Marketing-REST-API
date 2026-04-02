using MarketingRESTAPI.Application.Interfaces;
using MarketingRESTAPI.Infraestructure.Data;
using MarketingRESTAPI.Domain.Entities;
using System.Runtime.CompilerServices;

namespace MarketingRESTAPI.Infraestructure.Repositories;

public class SectorRepository : ISectorRepository
{
    private readonly List<Sector> _sectors;

    public SectorRepository(IExcelReader reader)
    {
        var rows = reader.Read("Data/sectors (2).xlsx");
        _sectors = DataMapper.MapSectors(rows);
    }

    public Task<List<Sector>> GetAllAsync()
    {
        return Task.FromResult(_sectors);
    }
}