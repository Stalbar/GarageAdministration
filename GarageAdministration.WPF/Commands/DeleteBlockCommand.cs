using GarageAdministration.Domain.Models;
using GarageAdministration.WPF.Commons;
using GarageAdministration.WPF.Commons.Stores;
using GarageAdministration.WPF.ViewModels.CreateBlock;
using GarageAdministration.WPF.ViewModels.GarageMap;

namespace GarageAdministration.WPF.Commands;

public class DeleteBlockCommand: AsyncCommandBase
{
    private readonly GarageMapCanvasBlockItemViewModel _garageMapCanvasBlockItemViewModel;
    private readonly GarageBlockStore _garageBlockStore;

    public DeleteBlockCommand(GarageBlockStore garageBlockStore, GarageMapCanvasBlockItemViewModel garageMapCanvasBlockItemViewModel)
    {
        _garageBlockStore = garageBlockStore;
        _garageMapCanvasBlockItemViewModel = garageMapCanvasBlockItemViewModel;
    }

    protected override async Task ExecuteAsync(object? parameter)
    {
        GarageBlock garageBlock = _garageMapCanvasBlockItemViewModel.GarageBlock;

        await _garageBlockStore.Delete(garageBlock.Id);
    }
}