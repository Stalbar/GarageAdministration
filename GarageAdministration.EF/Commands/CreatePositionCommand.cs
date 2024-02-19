using GarageAdministration.Domain.Commands;
using GarageAdministration.Domain.Models;
using GarageAdministration.EF.DTOs;

namespace GarageAdministration.EF.Commands;

public class CreatePositionCommand: ICreateCommand<Position>
{
    private readonly GarageAdministrationDbContextFactory _contextFactory;

    public CreatePositionCommand(GarageAdministrationDbContextFactory contextFactory)
    {
        _contextFactory = contextFactory;
    }
    
    public async Task Execute(Position entity)
    {
        await using var context = _contextFactory.Create();
        PositionDto positionDto = new PositionDto()
        {
            XPosition = entity.XPosition,
            YPosition = entity.YPosition
        };

        context.Positions.Add(positionDto);
        await context.SaveChangesAsync();
    }
}