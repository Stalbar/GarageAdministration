using GarageAdministration.Domain.Commands;
using GarageAdministration.Domain.Models;

namespace GarageAdministration.EF.Commands;

public class UpdateGarageCommand: IUpdateCommand<Garage>
{
    private readonly GarageAdministrationDbContextFactory _contextFactory;

    public UpdateGarageCommand(GarageAdministrationDbContextFactory contextFactory)
    {
        _contextFactory = contextFactory;
    }
    
    public async Task Execute(Garage entity)
    {
        await using var context = _contextFactory.Create();
        var garageDto = context.Garages.FirstOrDefault(g => g.Id == entity.Id)!;
        garageDto.MapInfoId = entity.MapInfo.Id;
        await context.SaveChangesAsync();
    }
}