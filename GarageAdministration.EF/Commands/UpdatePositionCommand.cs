using GarageAdministration.Domain.Commands;
using GarageAdministration.Domain.Models;

namespace GarageAdministration.EF.Commands;

public class UpdatePositionCommand: IUpdateCommand<MapInfo>
{
    private readonly GarageAdministrationDbContextFactory _contextFactory;

    public UpdatePositionCommand(GarageAdministrationDbContextFactory contextFactory)
    {
        _contextFactory = contextFactory;
    }


    public async Task Execute(MapInfo entity)
    {
        await using var context = _contextFactory.Create();
        var mapInfoDto = context.MapInfos.FirstOrDefault(p => p.Id == entity.Id)!;
        mapInfoDto.Id = entity.Id;
        mapInfoDto.Top = entity.Top;
        mapInfoDto.Left = entity.Left;
        
        context.MapInfos.Update(mapInfoDto);
        await context.SaveChangesAsync();
    }
}