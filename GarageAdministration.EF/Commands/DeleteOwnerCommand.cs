using GarageAdministration.Domain.Commands;

namespace GarageAdministration.EF.Commands;

public class DeleteOwnerCommand: IDeleteCommand
{
    private readonly GarageAdministrationDbContextFactory _contextFactory;

    public DeleteOwnerCommand(GarageAdministrationDbContextFactory contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task Execute(int id)
    {
        await using var context = _contextFactory.Create();
        var ownerDto = context.Owners.FirstOrDefault(o => o.Id == id)!;
        context.Owners.Remove(ownerDto);
        await context.SaveChangesAsync();
    }
}