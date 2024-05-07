using System.IO;
using System.Windows.Forms;
using System.Windows.Input;
using GarageAdministration.WPF.Commands;
using GarageAdministration.WPF.Commons.Stores;
using GarageAdministration.WPF.Commons.ViewModels;
using GarageAdministration.WPF.Services.Abstractions;

namespace GarageAdministration.WPF.ViewModels.GarageMap;

public class GarageMapViewModel: ViewModelBase
{
    private readonly GarageMapSearchTextStore _garageMapSearchTextStore;
    private string _searchText = "";
    public GarageMapCanvasViewModel GarageMapCanvasViewModel { get; }

    public ICommand NavigateToCreateGarageViewCommand { get; }
    public ICommand NavigateToCreateBlockViewCommand { get; }

    public string SearchText
    {
        get => _garageMapSearchTextStore.SearchText;
        set
        {
            _garageMapSearchTextStore.SearchText = value;
            OnPropertyChanged(nameof(SearchText));
        }
    }
    
    public GarageMapViewModel(GaragesStore garagesStore, INavigationService navigation, GarageMapInfoStore garageMapInfoStore, OwnersStore ownersStore, GarageBlockStore garageBlockStore, GarageMapSearchTextStore garageMapSearchTextStore)
    {
        NavigateToCreateBlockViewCommand = new NavigateToCreateBlockViewCommand(navigation);
        NavigateToCreateGarageViewCommand = new NavigateToCreateGarageViewCommand(navigation);
        GarageMapCanvasViewModel = new GarageMapCanvasViewModel(garagesStore, navigation, garageMapInfoStore, ownersStore, garageBlockStore, garageMapSearchTextStore);
        _garageMapSearchTextStore = garageMapSearchTextStore;
    }
}