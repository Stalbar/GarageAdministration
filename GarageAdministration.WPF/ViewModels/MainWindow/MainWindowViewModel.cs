using System.Windows.Input;
using GarageAdministration.WPF.Commands;
using GarageAdministration.WPF.Commons;
using GarageAdministration.WPF.Commons.ViewModels;
using GarageAdministration.WPF.Services.Abstractions;

namespace GarageAdministration.WPF.ViewModels.MainWindow;

public class MainWindowViewModel : ViewModelBase
{
    private INavigationService _navigation;
    
    public INavigationService Navigation
    {
        get => _navigation;
        set
        {
            _navigation = value;
            OnPropertyChanged(nameof(Navigation));
        }
    }
    
    public ICommand NavigateToOwnersListCommand { get; }
    public ICommand NavigateToGarageMapViewCommand { get; }
    public ICommand NavigateToReportListViewCommand { get; }
    public MainWindowViewModel(INavigationService navService)
    {
        Navigation = navService;
        NavigateToOwnersListCommand = new NavigateToOwnersListCommand(Navigation);
        NavigateToGarageMapViewCommand = new NavigateToGarageMapViewCommand(Navigation);
        NavigateToReportListViewCommand = new NavigateToReportListViewCommand(Navigation);
    }
}