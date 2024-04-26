using GarageAdministration.Domain.Commands;
using GarageAdministration.Domain.Models;
using GarageAdministration.EF.DTOs;

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
        var MapInfoDto = new MapInfoDto()
        {
            Top = entity.Top,
            Left = entity.Left,
            Width = entity.Width,
            Height = entity.Height
        };

        context.MapInfos.Add(MapInfoDto);
        await context.SaveChangesAsync();
    }
}