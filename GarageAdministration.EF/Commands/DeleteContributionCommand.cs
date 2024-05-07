using GarageAdministration.Domain.Commands;

namespace GarageAdministration.EF.Commands;

public class DeleteContributionCommand: IDeleteCommand
{
    private readonly GarageAdministrationDbContextFactory _contextFactory;

    public DeleteContributionCommand(GarageAdministrationDbContextFactory contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task Execute(int id)
    {
        await using var context = _contextFactory.Create();
        var contributionDto = context.Contributions.FirstOrDefault(c => c.Id == id)!;
        context.Contributions.Remove(contributionDto);
        await context.SaveChangesAsync();
    }
}