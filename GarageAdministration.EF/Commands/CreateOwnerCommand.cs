using GarageAdministration.Domain.Commands;
using GarageAdministration.Domain.Models;


namespace GarageAdministration.EF.Commands;

public class CreateOwnerCommand: ICreateCommand<Owner>
{
    private readonly GarageAdministrationDbContextFactory _contextFactory;

    public CreateOwnerCommand(GarageAdministrationDbContextFactory contextFactory)
    {
        _contextFactory = contextFactory;
    }
    
    public async Task Execute(Owner entity)
    {
        await using var context = _contextFactory.Create();
        var ownerDto = new Owner()
        {
            Name = entity.Name,
            Surname = entity.Surname,
            Patronymic = entity.Patronymic
        };
        context.Owners.Add(ownerDto);
        await context.SaveChangesAsync();
        entity.Id = ownerDto.Id;
    }
}