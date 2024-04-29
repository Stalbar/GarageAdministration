using System.Windows.Input;
using GarageAdministration.WPF.Commons;
using GarageAdministration.WPF.Commons.Stores;
using GarageAdministration.WPF.Services.Abstractions;
using GarageAdministration.WPF.ViewModels.EditBlock;
using GarageAdministration.WPF.ViewModels.GarageMap;

namespace GarageAdministration.WPF.Commands;

public class NavigateToEditGarageBlockCommand: CommandBase
{
    private readonly INavigationService _navigation;
    private readonly GarageMapCanvasBlockItemViewModel _garageMapCanvasBlockItemViewModel;
    private readonly GarageBlockStore _garageBlockStore;
    private readonly GaragesStore _garagesStore;
    private readonly GarageMapInfoStore _garageMapInfoStore;
    private readonly ICommand _deleteCommand;
    public NavigateToEditGarageBlockCommand(INavigationService navigation, GarageMapCanvasBlockItemViewModel garageMapCanvasBlockItemViewModel, GarageBlockStore garageBlockStore, GaragesStore garagesStore, GarageMapInfoStore garageMapInfoStore, ICommand deleteCommand)
    {
        _navigation = navigation;
        _garageMapCanvasBlockItemViewModel = garageMapCanvasBlockItemViewModel;
        _garageBlockStore = garageBlockStore;
        _garagesStore = garagesStore;
        _garageMapInfoStore = garageMapInfoStore;
        _deleteCommand = deleteCommand;
    }

    public override void Execute(object? parameter)
    {
        var garageBlock = _garageMapCanvasBlockItemViewModel.GarageBlock;
        var editGarageViewModel = new EditBlockViewModel(garageBlock, _garageBlockStore, _garagesStore, _garageMapInfoStore, _navigation, _deleteCommand);
        _navigation.NavigateTo(editGarageViewModel);
    }
}