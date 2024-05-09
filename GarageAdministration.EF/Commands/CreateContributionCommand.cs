using GarageAdministration.Domain.Commands;
using GarageAdministration.Domain.Models;
using GarageAdministration.EF.DTOs;

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
        var contributionDto = new ContributionDto()
        {
            MembershipFee = entity.ElectricityFee,
            ElectricityFee = entity.MembershipFee,
            GarageId = entity.Garage.Id,
            ElectricityFeePaymentStatus = entity.ElectricityFeePaymentStatus,
            MembershipFeePaymentStatus = entity.MembershipFeePaymentStatus,
        };
        context.Contributions.Add(contributionDto);
        await context.SaveChangesAsync();
    }
}