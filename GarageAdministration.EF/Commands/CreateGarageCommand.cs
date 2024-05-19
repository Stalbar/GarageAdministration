using GarageAdministration.Domain.Commands;
using GarageAdministration.Domain.Models;

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
        var garageDto = new Garage()
        {
            MapInfoId = entity.MapInfo.Id,
            OwnerId = entity.Owner.Id,
            MapId = entity.Map.Id,
            ContributionId = entity.Contribution.Id
        };
        context.Garages.Add(garageDto);
        await context.SaveChangesAsync();
    }
}