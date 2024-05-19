using GarageAdministration.Domain.Models;
using GarageAdministration.Domain.Queries;
using Microsoft.EntityFrameworkCore;

namespace GarageAdministration.EF.Queries;

public class GetAllReports: IGetAllQuery<Report>
{
    private readonly GarageAdministrationDbContextFactory _contextFactory;

    public GetAllReports(GarageAdministrationDbContextFactory contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task<IEnumerable<Report>> Execute()
    {
        await using var context = _contextFactory.Create();
        var reports = await context.Reports.ToListAsync();
        return reports;
    }
}