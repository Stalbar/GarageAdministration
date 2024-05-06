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
            .ToListAsync();
        return garages.Select(g =>
            new Garage(
                g.Id,
                new Owner(g.Owner!.Id, g.Owner.Name, g.Owner.Surname, g.Owner.Patronymic),
                new MapInfo(g.MapInfo!.Id, g.MapInfo.Top, g.MapInfo.Left, g.MapInfo.Width, g.MapInfo.Height, g.MapInfo.Angle, g.MapInfo.ZIndex),
                new Map(g.Map!.Id, g.Map.PathToImage)
            )
        );
    }
}