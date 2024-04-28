using GarageAdministration.WPF.Commons;
using GarageAdministration.WPF.Commons.Stores;

namespace GarageAdministration.WPF.Commands;

public class LoadGarageBlocksCommand: AsyncCommandBase
{
    private readonly GarageBlockStore _garageBlockStore;

    public LoadGarageBlocksCommand(GarageBlockStore garageBlockStore)
    {
        _garageBlockStore = garageBlockStore;
    }

    protected override async Task ExecuteAsync(object? parameter)
    {
        await _garageBlockStore.Load();
    }
}