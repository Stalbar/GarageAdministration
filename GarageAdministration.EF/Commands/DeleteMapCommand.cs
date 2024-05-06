using GarageAdministration.Domain.Commands;

namespace GarageAdministration.EF.Commands;

public class DeleteMapCommand: IDeleteCommand
{
    private readonly GarageAdministrationDbContextFactory _contextFactory;

    public DeleteMapCommand(GarageAdministrationDbContextFactory contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task Execute(int id)
    {
        await using var context = _contextFactory.Create();
        var mapDto = context.Maps.FirstOrDefault(g => g.Id == id)!;
        context.Maps.Remove(mapDto);
        await context.SaveChangesAsync();
    }
}