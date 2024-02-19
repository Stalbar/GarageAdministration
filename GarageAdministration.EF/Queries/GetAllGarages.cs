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
            .Include(g => g.Position)
            .Include(g => g.Owner)
            .ToListAsync();
        return garages.Select(g =>
            new Garage(
                g.Id,
                new Position(g.Position!.Id, g.Position.XPosition, g.Position.YPosition),
                new Owner(g.Owner!.Id, g.Owner.Name, g.Owner.Surname, g.Owner.Patronymic)
            )
        );
    }
}