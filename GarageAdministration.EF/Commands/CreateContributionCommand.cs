using GarageAdministration.Domain.Commands;
using GarageAdministration.Domain.Models;

namespace GarageAdministration.EF.Commands;

public class CreateContributionCommand: ICreateCommand<Contribution>
{
    private readonly GarageAdministrationDbContextFactory _contextFactory;

    public CreateContributionCommand(GarageAdministrationDbContextFactory contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task Execute(Contribution entity)
    {
        await using var context = _contextFactory.Create();
        var contributionDto = new Contribution()
        {
            MembershipFee = entity.ElectricityFee,
            ElectricityFee = entity.MembershipFee,
            ElectricityFeePaymentStatus = entity.ElectricityFeePaymentStatus,
            MembershipFeePaymentStatus = entity.MembershipFeePaymentStatus,
        };
        context.Contributions.Add(contributionDto);
        await context.SaveChangesAsync();
    }
}