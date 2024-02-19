using GarageAdministration.Domain.Commands;
using GarageAdministration.Domain.Models;

namespace GarageAdministration.EF.Commands;

public class UpdateOwnerCommand: IUpdateCommand<Owner>
{
    private readonly GarageAdministrationDbContextFactory _contextFactory;

    public UpdateOwnerCommand(GarageAdministrationDbContextFactory contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task Execute(Owner entity)
    {
        await using var context = _contextFactory.Create();
        var ownerDto = context.Owners.FirstOrDefault(o => o.Id == entity.Id)!;
        ownerDto.Name = entity.Name;
        ownerDto.Surname = entity.Surname;
        ownerDto.Patronymic = entity.Patronymic;
        await context.SaveChangesAsync();
    }
}