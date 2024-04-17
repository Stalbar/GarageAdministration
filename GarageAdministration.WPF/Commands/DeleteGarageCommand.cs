using GarageAdministration.Domain.Models;
using GarageAdministration.WPF.Commons;
using GarageAdministration.WPF.Commons.Stores;
using GarageAdministration.WPF.ViewModels.GarageMap;

namespace GarageAdministration.WPF.Commands;

public class DeleteGarageCommand: AsyncCommandBase
{
    private readonly GarageMapCanvasItemViewModel _garageMapCanvasItemViewModel;
    private readonly GaragesStore _garagesStore;

    public DeleteGarageCommand(GarageMapCanvasItemViewModel garageMapCanvasItemViewModel, GaragesStore garagesStore)
    {
        _garageMapCanvasItemViewModel = garageMapCanvasItemViewModel;
        _garagesStore = garagesStore;
    }


    protected override async Task ExecuteAsync(object? parameter)
    {
        Garage garage = _garageMapCanvasItemViewModel.Garage;

        await _garagesStore.Delete(garage.Id);
    }
}