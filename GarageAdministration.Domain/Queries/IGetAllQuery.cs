namespace GarageAdministration.Domain.Queries;

public interface IGetAllQuery<T>
{
    Task<IEnumerable<T>> Execute();
}