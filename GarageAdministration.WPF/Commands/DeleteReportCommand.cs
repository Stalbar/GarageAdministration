using GarageAdministration.WPF.Commons;
using GarageAdministration.WPF.Commons.Stores;
using GarageAdministration.WPF.ViewModels.ReportList;

namespace GarageAdministration.WPF.Commands;

public class DeleteReportCommand: AsyncCommandBase
{
    private readonly ReportListItemViewModel _reportListItemViewModel;
    private readonly ReportsStore _reportsStore;
    
    public DeleteReportCommand(ReportListItemViewModel reportListItemViewModel, ReportsStore reportsStore)
    {
        _reportListItemViewModel = reportListItemViewModel;
        _reportsStore = reportsStore;
    }

    protected override async Task ExecuteAsync(object? parameter)
    {
        var report = _reportListItemViewModel.Report;
        await _reportsStore.Delete(report.Id);
    }
}