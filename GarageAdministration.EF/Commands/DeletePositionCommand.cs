using GarageAdministration.Domain.Commands;
using GarageAdministration.EF.DTOs;
using Microsoft.EntityFrameworkCore;

namespace GarageAdministration.EF.Commands;

public class DeletePositionCommand: IDeleteCommand
{
    private readonly GarageAdministrationDbContextFactory _contextFactory;

    public DeletePositionCommand(GarageAdministrationDbContextFactory contextFactory)
    {
        _contextFactory = contextFactory;
    }


    public async Task Execute(int id)
    {
        await using var context = _contextFactory.Create();
        var positionDto = context.Positions.FirstOrDefault(p => p.Id == id)!;
        context.Positions.Remove(positionDto);
        await context.SaveChangesAsync();
    }
}