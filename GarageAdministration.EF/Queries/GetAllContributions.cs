using GarageAdministration.Domain.Models;
using GarageAdministration.Domain.Queries;
using Microsoft.EntityFrameworkCore;

namespace GarageAdministration.EF.Queries;

public class GetAllContributions : IGetAllQuery<Contribution>
{
    private readonly GarageAdministrationDbContextFactory _contextFactory;

    public GetAllContributions(GarageAdministrationDbContextFactory contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task<IEnumerable<Contribution>> Execute()
    {
        await using var context = _contextFactory.Create();
        var contributions = await context.Contributions
            .ToListAsync();
        return contributions;
    }
}