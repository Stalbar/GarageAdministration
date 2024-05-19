using GarageAdministration.Domain.Commands;
using GarageAdministration.Domain.Models;

namespace GarageAdministration.EF.Commands;

public class CreateGarageBlockCommand: ICreateCommand<GarageBlock>
{
    private readonly GarageAdministrationDbContextFactory _contextFactory;

    public CreateGarageBlockCommand(GarageAdministrationDbContextFactory contextFactory)
    {
        _contextFactory = contextFactory;
    }


    public async Task Execute(GarageBlock entity)
    {
        await using var context = _contextFactory.Create();
        var garageBlockDto = new GarageBlock()
        {
            MapInfoId = entity.MapInfo.Id,
        };
        context.GarageBlock.Add(garageBlockDto);
        await context.SaveChangesAsync();
    }
}