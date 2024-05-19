using GarageAdministration.Domain.Models;
using GarageAdministration.Domain.Queries;
using Microsoft.EntityFrameworkCore;

namespace GarageAdministration.EF.Queries;

public class GetAllOwners: IGetAllQuery<Owner>
{
    private readonly GarageAdministrationDbContextFactory _contextFactory;

    public GetAllOwners(GarageAdministrationDbContextFactory contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task<IEnumerable<Owner>> Execute()
    {
        await using var context = _contextFactory.Create();
        var owners = await context.Owners
            .Include(o => o.Garages)
                .ThenInclude(g => g.Contribution)
            .ToListAsync();
        return owners;
    }
}