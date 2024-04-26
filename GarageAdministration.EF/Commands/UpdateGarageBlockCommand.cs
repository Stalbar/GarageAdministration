using GarageAdministration.Domain.Commands;
using GarageAdministration.Domain.Models;

namespace GarageAdministration.EF.Commands;

public class UpdateGarageBlockCommand: IUpdateCommand<GarageBlock>
{
    private readonly GarageAdministrationDbContextFactory _contextFactory;

    public UpdateGarageBlockCommand(GarageAdministrationDbContextFactory contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task Execute(GarageBlock entity)
    {
        await using var context = _contextFactory.Create();
        var garageBlockDto = context.GarageBlock.FirstOrDefault(g => g.Id == entity.Id)!;
        garageBlockDto.MapInfoId = entity.MapInfo.Id;
        await context.SaveChangesAsync();
    }
}