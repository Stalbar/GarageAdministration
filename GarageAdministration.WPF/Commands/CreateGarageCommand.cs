using GarageAdministration.Domain.Models;
using GarageAdministration.WPF.Commons;
using GarageAdministration.WPF.Commons.Stores;
using GarageAdministration.WPF.ViewModels.CreateGarage;

namespace GarageAdministration.WPF.Commands;

public class CreateGarageCommand: AsyncCommandBase
{
    private readonly CreateGarageViewModel _createGarageViewModel;
    private readonly GaragesStore _garagesStore;
    private readonly GarageMapInfoStore _garageMapInfoStore;

    public CreateGarageCommand(CreateGarageViewModel createGarageViewModel, GaragesStore garagesStore, GarageMapInfoStore garageMapInfoStore)
    {
        _createGarageViewModel = createGarageViewModel;
        _garagesStore = garagesStore;
        _garageMapInfoStore = garageMapInfoStore;
    }

    protected override async Task ExecuteAsync(object? parameter)
    {
        var garage = _createGarageViewModel.CreateGarageMapViewModel.CreatedGarage;
        await _garageMapInfoStore.Add(garage.MapInfo);
        await _garagesStore.Add(garage);
    }
}