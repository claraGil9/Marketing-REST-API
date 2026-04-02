using MarketingRESTAPI.Application.Interfaces;
using MarketingRESTAPI.Infraestructure.Data;
using MarketingRESTAPI.Domain.Entities;
using System.Runtime.CompilerServices;

namespace MarketingRESTAPI.Infraestructure.Repositories;

public class LeadRepository : ILeadRepository
{
    private readonly List<Lead> _leads;

    public LeadRepository(IExcelReader reader)
    {
        var rows = reader.Read("Infraestructure/Data/Files/leads (2).xlsx");
        _leads = DataMapper.MapLeads(rows);
    }

    public Task<List<Lead>> GetAllAsync()
    {
        return Task.FromResult(_leads);
    }
}