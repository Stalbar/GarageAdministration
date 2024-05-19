using GarageAdministration.Domain.Models;
using GarageAdministration.Domain.Queries;
using Microsoft.EntityFrameworkCore;

namespace GarageAdministration.EF.Queries;

public class GetAllMapInfos: IGetAllQuery<MapInfo>
{
    private readonly GarageAdministrationDbContextFactory _contextFactory;

    public GetAllMapInfos(GarageAdministrationDbContextFactory contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task<IEnumerable<MapInfo>> Execute()
    {
        await using var context = _contextFactory.Create();
        var mapInfos = await context.MapInfos.ToListAsync();
        return mapInfos;
    }
}