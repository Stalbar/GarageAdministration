using GarageAdministration.Domain.Commands;
using GarageAdministration.Domain.Models;

namespace GarageAdministration.EF.Commands;

public class UpdatePositionCommand: IUpdateCommand<Position>
{
    private readonly GarageAdministrationDbContextFactory _contextFactory;

    public UpdatePositionCommand(GarageAdministrationDbContextFactory contextFactory)
    {
        _contextFactory = contextFactory;
    }


    public async Task Execute(Position entity)
    {
        await using var context = _contextFactory.Create();
        var positionDto = context.Positions.FirstOrDefault(p => p.Id == entity.Id)!;
        positionDto.Id = entity.Id;
        positionDto.XPosition = entity.XPosition;
        positionDto.YPosition = entity.YPosition;
        context.Positions.Update(positionDto);
        await context.SaveChangesAsync();
    }
}