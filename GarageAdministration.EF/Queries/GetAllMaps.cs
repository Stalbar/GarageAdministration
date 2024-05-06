using GarageAdministration.Domain.Models;
using GarageAdministration.Domain.Queries;
using Microsoft.EntityFrameworkCore;

namespace GarageAdministration.EF.Queries;

public class GetAllMaps: IGetAllQuery<Map>
{
    private readonly GarageAdministrationDbContextFactory _contextFactory;

    public GetAllMaps(GarageAdministrationDbContextFactory contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task<IEnumerable<Map>> Execute()
    {
        await using var context = _contextFactory.Create();
        var maps = await context.Maps.ToListAsync();
        return maps.Select(m => new Map(m.Id, m.PathToImage));
    }
}