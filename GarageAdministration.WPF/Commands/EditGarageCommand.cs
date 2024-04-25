using GarageAdministration.WPF.Commons;
using GarageAdministration.WPF.Commons.Stores;
using GarageAdministration.WPF.ViewModels.EditGarage;

namespace GarageAdministration.WPF.Commands;

public class EditGarageCommand: AsyncCommandBase
{
    private readonly EditGarageViewModel _editGarageViewModel;
    private readonly GaragesStore _garagesStore;
    private readonly GarageMapInfoStore _garageMapInfoStore;

    public EditGarageCommand(EditGarageViewModel editGarageViewModel, GaragesStore garagesStore, GarageMapInfoStore garageMapInfoStore)
    {
        _editGarageViewModel = editGarageViewModel;
        _garagesStore = garagesStore;
        _garageMapInfoStore = garageMapInfoStore;
    }

    protected override async Task ExecuteAsync(object? parameter)
    {
        var garage = _editGarageViewModel.CreateGarageMapViewModel.CreatedGarage;
        await _garageMapInfoStore.Update(garage.MapInfo);
        await _garagesStore.Update(garage);
    }
}