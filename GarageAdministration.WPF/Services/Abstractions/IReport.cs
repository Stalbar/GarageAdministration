namespace GarageAdministration.WPF.Services.Abstractions;

public interface IReport
{
    IEnumerable<byte> Generate();
}