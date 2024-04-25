using GarageAdministration.WPF.Commons;
using GarageAdministration.WPF.Commons.Stores;

namespace GarageAdministration.WPF.Commands;

public class LoadMapInfosCommand: AsyncCommandBase
{
    private readonly GarageMapInfoStore _mapInfoStore;

    public LoadMapInfosCommand(GarageMapInfoStore mapInfoStore)
    {
        _mapInfoStore = mapInfoStore;
    }

    protected override async Task ExecuteAsync(object? parameter)
    {
        await _mapInfoStore.Load();
    }
}