using GarageAdministration.WPF.Commons;
using GarageAdministration.WPF.Services.Abstractions;
using GarageAdministration.WPF.ViewModels.ReportList;

namespace GarageAdministration.WPF.Commands;

public class NavigateToReportListViewCommand: CommandBase
{
    private readonly INavigationService _navigation;

    public NavigateToReportListViewCommand(INavigationService navigation)
    {
        _navigation = navigation;
    }

    public override void Execute(object? parameter)
    {
        _navigation.NavigateTo<ReportListViewModel>();
    }
}