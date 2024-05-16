using System.Windows.Input;
using GarageAdministration.Domain.Models;
using GarageAdministration.WPF.Commands;
using GarageAdministration.WPF.Commons.Stores;
using GarageAdministration.WPF.Commons.ViewModels;
using GarageAdministration.WPF.Services.Abstractions;

namespace GarageAdministration.WPF.ViewModels.GarageMap;

public class GarageMapViewModel : ViewModelBase
{
    private readonly GarageMapSearchTextStore _garageMapSearchTextStore;
    private readonly SelectedMapStore _selectedMapStore;
    private List<Map> _maps;
    public GarageMapCanvasViewModel GarageMapCanvasViewModel { get; }

    public ICommand NavigateToCreateGarageViewCommand { get; }
    public ICommand NavigateToCreateBlockViewCommand { get; }
    public ICommand NavigateToCreateMapViewCommand { get; }

    public IEnumerable<Map> Maps
    {
        get => _maps;
        set
        {
            _maps = value.ToList();
            OnPropertyChanged(nameof(Maps));
        }
    }
    
    public string SearchText
    {
        get => _garageMapSearchTextStore.SearchText;
        set
        {
            _garageMapSearchTextStore.SearchText = value;
            OnPropertyChanged(nameof(SearchText));
        }
    }

    public Map? SelectedMap
    {
        get => _selectedMapStore.Map;
        set
        {
            _selectedMapStore.Map = value;
            OnPropertyChanged(nameof(SelectedMap));
        }
    }

    public GarageMapViewModel(GaragesStore garagesStore, INavigationService navigation,
        GarageMapInfoStore garageMapInfoStore, OwnersStore ownersStore, GarageBlockStore garageBlockStore,
        GarageMapSearchTextStore garageMapSearchTextStore, ContributionsStore contributionsStore,
        SelectedMapStore selectedMapStore, MapsStore mapsStore)

    {
        NavigateToCreateBlockViewCommand = new NavigateToCreateBlockViewCommand(navigation);
        NavigateToCreateGarageViewCommand = new NavigateToCreateGarageViewCommand(navigation);
        NavigateToCreateMapViewCommand = new NavigateToCreateMapViewCommand(navigation);
        GarageMapCanvasViewModel = new GarageMapCanvasViewModel(garagesStore, navigation, garageMapInfoStore,
            ownersStore, garageBlockStore, garageMapSearchTextStore, contributionsStore, selectedMapStore);
        _garageMapSearchTextStore = garageMapSearchTextStore;
        _selectedMapStore = selectedMapStore;
        Maps = mapsStore.Maps;
    }
}