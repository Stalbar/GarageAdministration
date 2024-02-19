using GarageAdministration.Domain.Commands;

namespace GarageAdministration.EF.Commands;

public class DeleteGarageCommand: IDeleteCommand
{
    private readonly GarageAdministrationDbContextFactory _contextFactory;

    public DeleteGarageCommand(GarageAdministrationDbContextFactory contextFactory)
    {
        _contextFactory = contextFactory;
    }
    
    public async Task Execute(int id)
    {
        await using var context = _contextFactory.Create();
        var garageDto = context.Garages.FirstOrDefault(g => g.Id == id)!;
        context.Garages.Remove(garageDto);
        await context.SaveChangesAsync();
    }
}