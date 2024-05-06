using System.Windows.Input;
using GarageAdministration.WPF.Commands;
using GarageAdministration.WPF.Commons.Stores;
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

    public MainWindowViewModel(INavigationService navService, GaragesStore garagesStore,
        GarageMapInfoStore garageMapInfoStore, OwnersStore ownersStore, GarageBlockStore garageBlockStore,
        MapsStore mapsStore)

    {
        Navigation = navService;
        NavigateToOwnersListCommand = new NavigateToOwnersListCommand(Navigation);
        NavigateToGarageMapViewCommand = new NavigateToGarageMapViewCommand(Navigation);
        NavigateToReportListViewCommand = new NavigateToReportListViewCommand(Navigation);
        new LoadGaragesCommand(garagesStore).Execute(null);
        new LoadOwnersCommand(ownersStore).Execute(null);
        new LoadMapInfosCommand(garageMapInfoStore).Execute(null);
        new LoadGarageBlocksCommand(garageBlockStore).Execute(null);
        new LoadMapsCommand(mapsStore).Execute(null);
    }
}