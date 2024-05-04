using GarageAdministration.WPF.Commons;
using GarageAdministration.WPF.Commons.Stores;
using GarageAdministration.WPF.Services.Abstractions;
using GarageAdministration.WPF.ViewModels.CreateBlock;
using GarageAdministration.WPF.ViewModels.GarageMap;

namespace GarageAdministration.WPF.Commands;

public class CreateBlockCommand: AsyncCommandBase
{
    private readonly CreateBlockViewModel _createBlockViewModel;
    private readonly GarageBlockStore _garageBlockStore;
    private readonly GarageMapInfoStore _garageMapInfoStore;
    private readonly INavigationService _navigation;

    public CreateBlockCommand(CreateBlockViewModel createBlockViewModel, GarageBlockStore garageBlockStore, GarageMapInfoStore garageMapInfoStore, INavigationService navigation)
    {
        _createBlockViewModel = createBlockViewModel;
        _garageBlockStore = garageBlockStore;
        _garageMapInfoStore = garageMapInfoStore;
        _navigation = navigation;
    }

    protected override async Task ExecuteAsync(object? parameter)
    {
        var garageBlock = _createBlockViewModel.CreateBlockMapViewModel.CreatedGarageBlock;
        await _garageMapInfoStore.Add(garageBlock.MapInfo);
        await _garageBlockStore.Add(garageBlock);
        _navigation.NavigateTo<GarageMapViewModel>();
    }
}