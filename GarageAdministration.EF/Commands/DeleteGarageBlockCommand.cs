using GarageAdministration.Domain.Commands;

namespace GarageAdministration.EF.Commands;

public class DeleteGarageBlockCommand: IDeleteCommand
{
    private readonly GarageAdministrationDbContextFactory _contextFactory;

    public DeleteGarageBlockCommand(GarageAdministrationDbContextFactory contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task Execute(int id)
    {
        await using var context = _contextFactory.Create();
        var garageBlockDto = context.GarageBlock.FirstOrDefault(g => g.Id == id)!;
        context.GarageBlock.Remove(garageBlockDto);
        await context.SaveChangesAsync();
    }
}