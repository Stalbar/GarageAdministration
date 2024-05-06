using GarageAdministration.Domain.Commands;
using GarageAdministration.Domain.Models;

namespace GarageAdministration.EF.Commands;

public class UpdateMapCommand: IUpdateCommand<Map>
{
    private readonly GarageAdministrationDbContextFactory _contextFactory;

    public UpdateMapCommand(GarageAdministrationDbContextFactory contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task Execute(Map entity)
    {
        await using var context = _contextFactory.Create();
        var mapDto = context.Maps.FirstOrDefault(m => m.Id == entity.Id)!;
        mapDto.PathToImage = entity.PathToImage;
        await context.SaveChangesAsync();
    }
}