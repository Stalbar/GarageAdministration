using System.IO;
using System.Windows.Forms;
using System.Windows.Input;
using GarageAdministration.WPF.Commands;
using GarageAdministration.WPF.Commons.Stores;
using GarageAdministration.WPF.Commons.ViewModels;
using GarageAdministration.WPF.Services.Abstractions;

namespace GarageAdministration.WPF.ViewModels.GarageMap;

public class GarageMapViewModel : ViewModelBase
{
    private readonly GarageMapSearchTextStore _garageMapSearchTextStore;
    public GarageMapCanvasViewModel GarageMapCanvasViewModel { get; }

    public ICommand NavigateToCreateGarageViewCommand { get; }
    public ICommand NavigateToCreateBlockViewCommand { get; }
    public ICommand NavigateToCreateMapViewCommand { get; }

    public string SearchText
    {
        get => _garageMapSearchTextStore.SearchText;
        set
        {
            _garageMapSearchTextStore.SearchText = value;
            OnPropertyChanged(nameof(SearchText));
        }
    }

    public GarageMapViewModel(GaragesStore garagesStore, INavigationService navigation,
        GarageMapInfoStore garageMapInfoStore, OwnersStore ownersStore, GarageBlockStore garageBlockStore,
        GarageMapSearchTextStore garageMapSearchTextStore, ContributionsStore contributionsStore)
    {
        NavigateToCreateBlockViewCommand = new NavigateToCreateBlockViewCommand(navigation);
        NavigateToCreateGarageViewCommand = new NavigateToCreateGarageViewCommand(navigation);
        NavigateToCreateMapViewCommand = new NavigateToCreateMapViewCommand(navigation);
        GarageMapCanvasViewModel = new GarageMapCanvasViewModel(garagesStore, navigation, garageMapInfoStore,
            ownersStore, garageBlockStore, garageMapSearchTextStore, contributionsStore);
        _garageMapSearchTextStore = garageMapSearchTextStore;
    }
}