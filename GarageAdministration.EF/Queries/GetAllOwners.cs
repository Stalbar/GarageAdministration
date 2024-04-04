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
        var owners = await context.Owners.ToListAsync();
        return owners.Select(o => 
            new Owner(
                o.Id, 
                o.Name, 
                o.Surname, 
                o.Patronymic
            )
        );
    }
}