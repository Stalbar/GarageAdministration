using GarageAdministration.Domain.Models;
using GarageAdministration.WPF.Commons;
using GarageAdministration.WPF.Commons.Stores;
using GarageAdministration.WPF.Services.Abstractions;
using GarageAdministration.WPF.ViewModels.CreateBlock;
using GarageAdministration.WPF.ViewModels.GarageMap;

namespace GarageAdministration.WPF.Commands;

public class DeleteBlockCommand: AsyncCommandBase
{
    private readonly GarageMapCanvasBlockItemViewModel _garageMapCanvasBlockItemViewModel;
    private readonly GarageBlockStore _garageBlockStore;
    private readonly INavigationService _navigation;

    public DeleteBlockCommand(GarageBlockStore garageBlockStore, GarageMapCanvasBlockItemViewModel garageMapCanvasBlockItemViewModel, INavigationService navigation)
    {
        _garageBlockStore = garageBlockStore;
        _garageMapCanvasBlockItemViewModel = garageMapCanvasBlockItemViewModel;
        _navigation = navigation;
    }

    protected override async Task ExecuteAsync(object? parameter)
    {
        GarageBlock garageBlock = _garageMapCanvasBlockItemViewModel.GarageBlock;

        await _garageBlockStore.Delete(garageBlock.Id);
        
        _navigation.NavigateTo<GarageMapViewModel>();
    }
}