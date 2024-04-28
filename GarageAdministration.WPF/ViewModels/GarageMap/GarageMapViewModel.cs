using System.Windows.Input;
using GarageAdministration.WPF.Commands;
using GarageAdministration.WPF.Commons.Stores;
using GarageAdministration.WPF.Commons.ViewModels;
using GarageAdministration.WPF.Services.Abstractions;

namespace GarageAdministration.WPF.ViewModels.GarageMap;

public class GarageMapViewModel: ViewModelBase
{
    public GarageMapCanvasViewModel GarageMapCanvasViewModel { get; }

    public ICommand NavigateToCreateGarageViewCommand { get; }
    public ICommand NavigateToCreateBlockViewCommand { get; }
    
    public GarageMapViewModel(GaragesStore garagesStore, INavigationService navigation, GarageMapInfoStore garageMapInfoStore, OwnersStore ownersStore, GarageBlockStore garageBlockStore)
    {
        NavigateToCreateBlockViewCommand = new NavigateToCreateBlockViewCommand(navigation);
        NavigateToCreateGarageViewCommand = new NavigateToCreateGarageViewCommand(navigation);
        GarageMapCanvasViewModel = new GarageMapCanvasViewModel(garagesStore, navigation, garageMapInfoStore, ownersStore, garageBlockStore);
    }
}