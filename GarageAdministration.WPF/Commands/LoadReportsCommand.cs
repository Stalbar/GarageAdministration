using GarageAdministration.WPF.Commons;
using GarageAdministration.WPF.Commons.Stores;

namespace GarageAdministration.WPF.Commands;

public class LoadReportsCommand: AsyncCommandBase
{
    private readonly ReportsStore _reportsStore;

    public LoadReportsCommand(ReportsStore reportsStore)
    {
        _reportsStore = reportsStore;
    }

    protected override async Task ExecuteAsync(object? parameter)
    {
        await _reportsStore.Load();
    }
}