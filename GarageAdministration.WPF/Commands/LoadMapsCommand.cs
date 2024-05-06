using GarageAdministration.WPF.Commons;
using GarageAdministration.WPF.Commons.Stores;

namespace GarageAdministration.WPF.Commands;

public class LoadMapsCommand: AsyncCommandBase
{
    private readonly MapsStore _mapsStore;

    public LoadMapsCommand(MapsStore mapsStore)
    {
        _mapsStore = mapsStore;
    }

    protected override async Task ExecuteAsync(object? parameter)
    {
        await _mapsStore.Load();
    }
}