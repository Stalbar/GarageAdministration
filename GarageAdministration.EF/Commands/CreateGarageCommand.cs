using GarageAdministration.Domain.Commands;
using GarageAdministration.Domain.Models;
using GarageAdministration.EF.DTOs;

namespace GarageAdministration.EF.Commands;

public class CreateGarageCommand: ICreateCommand<Garage>
{
    private readonly GarageAdministrationDbContextFactory _contextFactory;

    public CreateGarageCommand(GarageAdministrationDbContextFactory contextFactory)
    {
        _contextFactory = contextFactory;
    }
    
    public async Task Execute(Garage entity)
    {
        await using var context = _contextFactory.Create();
        GarageDto garageDto = new GarageDto()
        {
            MapInfoId = entity.MapInfo.Id,
            OwnerId = entity.Owner.Id
        };
        context.Garages.Add(garageDto);
        await context.SaveChangesAsync();
    }
}