using System.Windows.Input;
using GarageAdministration.Domain.Models;
using GarageAdministration.WPF.Commands;
using GarageAdministration.WPF.Commons.Stores;
using GarageAdministration.WPF.Commons.ViewModels;
using GarageAdministration.WPF.Services.Abstractions;
using GarageAdministration.WPF.Services.Implementations.Filters;

namespace GarageAdministration.WPF.ViewModels.GarageMap;

public class GarageMapViewModel : ViewModelBase
{
    private readonly GarageMapSearchTextStore _garageMapSearchTextStore;
    private readonly SelectedMapStore _selectedMapStore;
    private readonly GarageMapSelectedFilterStore _garageMapSelectedFilterStore;
    private List<Map> _maps;
    private List<IFilter<GarageMapCanvasItemViewModel>> _filters;
    public IFilter<GarageMapCanvasItemViewModel> SelectedFilter
    {
        get => _garageMapSelectedFilterStore.Filter;
        set
        {
            _garageMapSelectedFilterStore.Filter = value;
            OnPropertyChanged(nameof(SelectedFilter));
        }
    }

    public IEnumerable<IFilter<GarageMapCanvasItemViewModel>> Filters
    {
        get => _filters;
        set
        {
            _filters = value.ToList();
            OnPropertyChanged(nameof(Filters));
        }
    }
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
            OnPropertyChanged(nameof(CanAddGarage));
        }
    }

    public bool CanAddGarage => SelectedMap is not null;

    public GarageMapViewModel(GaragesStore garagesStore, INavigationService navigation,
        GarageMapInfoStore garageMapInfoStore, OwnersStore ownersStore, GarageBlockStore garageBlockStore,
        GarageMapSearchTextStore garageMapSearchTextStore, ContributionsStore contributionsStore,
        SelectedMapStore selectedMapStore, MapsStore mapsStore, GarageMapSelectedFilterStore garageMapSelectedFilterStore)

    {
        Filters = new IFilter<GarageMapCanvasItemViewModel>[]
        {
            new GarageMapNoFilter(),
            new GarageMapElectricityFeeFilter(),
            new GarageMapMembershipFeeFilter()
        };
        _garageMapSelectedFilterStore = garageMapSelectedFilterStore;
        _garageMapSelectedFilterStore.SelectedFilterChanged += GarageMapSelectedFilterStoreOnSelectedFilterChanged;
        _garageMapSelectedFilterStore.Filter = Filters.First();
        NavigateToCreateBlockViewCommand = new NavigateToCreateBlockViewCommand(navigation);
        NavigateToCreateGarageViewCommand = new NavigateToCreateGarageViewCommand(navigation);
        NavigateToCreateMapViewCommand = new NavigateToCreateMapViewCommand(navigation);
        GarageMapCanvasViewModel = new GarageMapCanvasViewModel(garagesStore, navigation, garageMapInfoStore,
            ownersStore, garageBlockStore, garageMapSearchTextStore, contributionsStore, selectedMapStore, garageMapSelectedFilterStore);
        _garageMapSearchTextStore = garageMapSearchTextStore;
        _selectedMapStore = selectedMapStore;
        Maps = mapsStore.Maps;
    }

    private void GarageMapSelectedFilterStoreOnSelectedFilterChanged()
    {
        OnPropertyChanged(nameof(SelectedFilter));
    }
}