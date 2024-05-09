using GarageAdministration.Domain.Commands;
using GarageAdministration.Domain.Models;

namespace GarageAdministration.EF.Commands;

public class UpdateContributionCommand: IUpdateCommand<Contribution>
{
    private readonly GarageAdministrationDbContextFactory _contextFactory;

    public UpdateContributionCommand(GarageAdministrationDbContextFactory contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task Execute(Contribution entity)
    {
        await using var context = _contextFactory.Create();
        var contributionDto = context.Contributions.FirstOrDefault(c => c.Id == entity.Id)!;
        contributionDto.MembershipFee = entity.ElectricityFee;
        contributionDto.ElectricityFee = entity.MembershipFee;
        contributionDto.GarageId = entity.Garage.Id;
        contributionDto.ElectricityFeePaymentStatus = entity.ElectricityFeePaymentStatus;
        contributionDto.MembershipFeePaymentStatus = entity.MembershipFeePaymentStatus;
        await context.SaveChangesAsync();
    }
}