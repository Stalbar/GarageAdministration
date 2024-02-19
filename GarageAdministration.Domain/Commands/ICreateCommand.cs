namespace GarageAdministration.Domain.Commands;

public interface ICreateCommand<in T>
{
    Task Execute(T entity);
}