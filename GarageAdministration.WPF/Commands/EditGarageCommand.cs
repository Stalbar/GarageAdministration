using GarageAdministration.WPF.Commons;
using GarageAdministration.WPF.Commons.Stores;
using GarageAdministration.WPF.Services.Abstractions;
using GarageAdministration.WPF.ViewModels.EditGarage;
using GarageAdministration.WPF.ViewModels.GarageMap;

namespace GarageAdministration.WPF.Commands;

public class EditGarageCommand: AsyncCommandBase
{
    private readonly EditGarageViewModel _editGarageViewModel;
    private readonly GaragesStore _garagesStore;
    private readonly GarageMapInfoStore _garageMapInfoStore;
    private readonly INavigationService _navigation;
    
    public EditGarageCommand(EditGarageViewModel editGarageViewModel, GaragesStore garagesStore, GarageMapInfoStore garageMapInfoStore, INavigationService navigation)
    {
        _editGarageViewModel = editGarageViewModel;
        _garagesStore = garagesStore;
        _garageMapInfoStore = garageMapInfoStore;
        _navigation = navigation;
    }

    protected override async Task ExecuteAsync(object? parameter)
    {
        var garage = _editGarageViewModel.CreateGarageMapViewModel.CreatedGarage;
        await _garageMapInfoStore.Update(garage.MapInfo);
        await _garagesStore.Update(garage);
        _navigation.NavigateTo<GarageMapViewModel>();
    }
}