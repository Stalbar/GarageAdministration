using GarageAdministration.Domain.Commands;
using GarageAdministration.Domain.Models;
using GarageAdministration.EF.DTOs;

namespace GarageAdministration.EF.Commands;

public class CreatePositionCommand: ICreateCommand<GarageMapInfo>
{
    private readonly GarageAdministrationDbContextFactory _contextFactory;

    public CreatePositionCommand(GarageAdministrationDbContextFactory contextFactory)
    {
        _contextFactory = contextFactory;
    }
    
    public async Task Execute(GarageMapInfo entity)
    {
        await using var context = _contextFactory.Create();
        var garageMapInfoDto = new GarageMapInfoDto()
        {
            Top = entity.Top,
            Left = entity.Left,
            Width = entity.Width,
            Height = entity.Height
        };

        context.MapInfos.Add(garageMapInfoDto);
        await context.SaveChangesAsync();
    }
}