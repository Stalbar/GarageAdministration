using GarageAdministration.Domain.Commands;
using GarageAdministration.Domain.Models;

namespace GarageAdministration.EF.Commands;

public class CreatePositionCommand: ICreateCommand<MapInfo>
{
    private readonly GarageAdministrationDbContextFactory _contextFactory;

    public CreatePositionCommand(GarageAdministrationDbContextFactory contextFactory)
    {
        _contextFactory = contextFactory;
    }
    
    public async Task Execute(MapInfo entity)
    {
        await using var context = _contextFactory.Create();
        var mapInfoDto = new MapInfo()
        {
            Top = entity.Top,
            Left = entity.Left,
            Width = entity.Width,
            Height = entity.Height,
            Angle = entity.Angle,
            ZIndex = entity.ZIndex,
        };

        context.MapInfos.Add(mapInfoDto);
        await context.SaveChangesAsync();
    }
}