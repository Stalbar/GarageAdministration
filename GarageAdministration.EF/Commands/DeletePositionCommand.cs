using GarageAdministration.Domain.Commands;

namespace GarageAdministration.EF.Commands;

public class DeletePositionCommand: IDeleteCommand
{
    private readonly GarageAdministrationDbContextFactory _contextFactory;

    public DeletePositionCommand(GarageAdministrationDbContextFactory contextFactory)
    {
        _contextFactory = contextFactory;
    }


    public async Task Execute(int id)
    {
        await using var context = _contextFactory.Create();
        var positionDto = context.MapInfos.FirstOrDefault(p => p.Id == id)!;
        context.MapInfos.Remove(positionDto);
        await context.SaveChangesAsync();
    }
}