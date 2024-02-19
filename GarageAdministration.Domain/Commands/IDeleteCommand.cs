namespace GarageAdministration.Domain.Commands;

public interface IDeleteCommand
{
    Task Execute(int id);
}