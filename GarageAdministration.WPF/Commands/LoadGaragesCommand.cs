using GarageAdministration.WPF.Commons;
using GarageAdministration.WPF.Commons.Stores;

namespace GarageAdministration.WPF.Commands;

public class LoadGaragesCommand: AsyncCommandBase
{
    private readonly GaragesStore _garagesStore;

    public LoadGaragesCommand(GaragesStore garagesStore)
    {
        _garagesStore = garagesStore;
    }

    protected override async Task ExecuteAsync(object? parameter)
    {
        await _garagesStore.Load();
    }
}