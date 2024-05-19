using GarageAdministration.Domain.Models;
using GarageAdministration.Domain.Queries;
using Microsoft.EntityFrameworkCore;

namespace GarageAdministration.EF.Queries;

public class GetAllGarages : IGetAllQuery<Garage>
{
    private readonly GarageAdministrationDbContextFactory _contextFactory;

    public GetAllGarages(GarageAdministrationDbContextFactory contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task<IEnumerable<Garage>> Execute()
    {
        await using var context = _contextFactory.Create();
        var garages = await context.Garages
            .Include(g => g.MapInfo)
            .Include(g => g.Owner)
            .Include(g => g.Map)
            .Include(g => g.Contribution)
            .ToListAsync();
        return garages;
    }
}