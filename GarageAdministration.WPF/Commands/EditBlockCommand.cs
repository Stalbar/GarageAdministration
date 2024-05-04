using GarageAdministration.WPF.Commons;
using GarageAdministration.WPF.Commons.Stores;
using GarageAdministration.WPF.Services.Abstractions;
using GarageAdministration.WPF.ViewModels.EditBlock;
using GarageAdministration.WPF.ViewModels.GarageMap;

namespace GarageAdministration.WPF.Commands;

public class EditBlockCommand: AsyncCommandBase
{
    private readonly EditBlockViewModel _editBlockViewModel;
    private readonly GarageBlockStore _garageBlockStore;
    private readonly GarageMapInfoStore _garageMapInfoStore;
    private readonly INavigationService _navigation;
    
    public EditBlockCommand(EditBlockViewModel editBlockViewModel, GarageBlockStore garageBlockStore, GarageMapInfoStore garageMapInfoStore, INavigationService navigation)
    {
        _editBlockViewModel = editBlockViewModel;
        _garageBlockStore = garageBlockStore;
        _garageMapInfoStore = garageMapInfoStore;
        _navigation = navigation;
    }

    protected override async Task ExecuteAsync(object? parameter)
    {
        var garageBlock = _editBlockViewModel.CreateBlockMapViewModel.CreatedGarageBlock;
        await _garageMapInfoStore.Update(garageBlock.MapInfo);
        await _garageBlockStore.Update(garageBlock);
        _navigation.NavigateTo<GarageMapViewModel>();
    }
}