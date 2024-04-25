using GarageAdministration.Domain.Models;
using GarageAdministration.Domain.Queries;
using Microsoft.EntityFrameworkCore;

namespace GarageAdministration.EF.Queries;

public class GetAllMapInfos: IGetAllQuery<GarageMapInfo>
{
    private readonly GarageAdministrationDbContextFactory _contextFactory;

    public GetAllMapInfos(GarageAdministrationDbContextFactory contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task<IEnumerable<GarageMapInfo>> Execute()
    {
        await using var context = _contextFactory.Create();
        var mapInfos = await context.MapInfos.ToListAsync();
        return mapInfos.Select(m => new GarageMapInfo(m.Id, m.Top, m.Left, m.Width, m.Height));
    }
}