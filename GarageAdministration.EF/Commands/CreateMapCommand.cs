using GarageAdministration.Domain.Commands;
using GarageAdministration.Domain.Models;


namespace GarageAdministration.EF.Commands;

public class CreateMapCommand: ICreateCommand<Map>
{
    private readonly GarageAdministrationDbContextFactory _contextFactory;

    public CreateMapCommand(GarageAdministrationDbContextFactory contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task Execute(Map entity)
    {
        await using var context = _contextFactory.Create();
        var mapDto = new Map()
        {
            PathToImage = entity.PathToImage,
            Name = entity.Name,
        };
        context.Maps.Add(mapDto);
        await context.SaveChangesAsync();
    }
}