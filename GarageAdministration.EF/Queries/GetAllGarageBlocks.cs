using GarageAdministration.Domain.Models;
using GarageAdministration.Domain.Queries;
using Microsoft.EntityFrameworkCore;

namespace GarageAdministration.EF.Queries;

public class GetAllGarageBlocks : IGetAllQuery<GarageBlock>
{
    private readonly GarageAdministrationDbContextFactory _contextFactory;

    public GetAllGarageBlocks(GarageAdministrationDbContextFactory contextFactory)
    {
        _contextFactory = contextFactory;
    }
    
    public async Task<IEnumerable<GarageBlock>> Execute()
    {
        await using var context = _contextFactory.Create();
        var garageBlocks = await context.GarageBlock
            .Include(g => g.MapInfo)
            .ToListAsync();
        return garageBlocks;
    }
}