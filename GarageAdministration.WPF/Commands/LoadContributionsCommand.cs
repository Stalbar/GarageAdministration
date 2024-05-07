using GarageAdministration.WPF.Commons;
using GarageAdministration.WPF.Commons.Stores;

namespace GarageAdministration.WPF.Commands;

public class LoadContributionsCommand: AsyncCommandBase
{
    private readonly ContributionsStore _contributionsStore;

    public LoadContributionsCommand(ContributionsStore contributionsStore)
    {
        _contributionsStore = contributionsStore;
    }

    protected async override Task ExecuteAsync(object? parameter)
    {
        await _contributionsStore.Load();
    }
}