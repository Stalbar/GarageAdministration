using GarageAdministration.WPF.Commons;
using GarageAdministration.WPF.Commons.Stores;
using GarageAdministration.WPF.Services.Abstractions;
using GarageAdministration.WPF.ViewModels.EditGarage;
using GarageAdministration.WPF.ViewModels.GarageMap;

namespace GarageAdministration.WPF.Commands;

public class NavigateToEditGarageViewCommand: CommandBase
{
    private readonly INavigationService _navigation;
    private readonly GarageMapCanvasItemViewModel _garageMapCanvasItemViewModel;
    private readonly GaragesStore _garagesStore;
    private readonly OwnersStore _ownersStore;
    private readonly GarageMapInfoStore _garageMapInfoStore;
    private readonly GarageBlockStore _garageBlockStore;

    public NavigateToEditGarageViewCommand(INavigationService navigation, GarageMapCanvasItemViewModel garageMapCanvasItemViewModel, GaragesStore garagesStore, OwnersStore ownersStore, GarageMapInfoStore garageMapInfoStore, GarageBlockStore garageBlockStore)
    {
        _navigation = navigation;
        _garageMapCanvasItemViewModel = garageMapCanvasItemViewModel;
        _garagesStore = garagesStore;
        _ownersStore = ownersStore;
        _garageMapInfoStore = garageMapInfoStore;
        _garageBlockStore = garageBlockStore;
    }

    public override void Execute(object? parameter)
    {
        var garage = _garageMapCanvasItemViewModel.Garage;
        var editGarageViewModel = new EditGarageViewModel(garage, _garagesStore, _garageMapInfoStore, _ownersStore, _navigation, _garageBlockStore);
        _navigation.NavigateTo(editGarageViewModel);
    }
}