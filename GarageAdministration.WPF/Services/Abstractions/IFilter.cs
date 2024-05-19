namespace GarageAdministration.WPF.Services.Abstractions;

public interface IFilter<T>
{
    IEnumerable<T> ApplyFilter(IEnumerable<T> sequence);
}