using GarageAdministration.WPF.Commons;
using GarageAdministration.WPF.Commons.Stores;

namespace GarageAdministration.WPF.Commands;

public class LoadOwnersCommand: AsyncCommandBase
{
    private OwnersStore _ownersStore;

    public LoadOwnersCommand(OwnersStore ownersStore)
    {
        _ownersStore = ownersStore;
    }

    protected override async Task ExecuteAsync(object? parameter)
    {
        await _ownersStore.Load();
    }
}