namespace GarageAdministration.Domain.Commands;

public interface IUpdateCommand<in T>
{
    Task Execute(T entity);
}