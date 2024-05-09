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
            .Include(c => c.Garage)
            .ThenInclude(g => g.Owner)
            .ToListAsync();
        return contributions.Select(c => new Contribution(
            c.Id,
            c.MembershipFee,
            c.ElectricityFee,
            new Garage(c.Garage!.Id,
                new Owner(c.Garage.Owner!.Id, c.Garage.Owner.Name, c.Garage.Owner.Surname, c.Garage.Owner.Patronymic),
                null, null),
            c.MembershipFeePaymentStatus,
            c.ElectricityFeePaymentStatus
        ));
    }
}