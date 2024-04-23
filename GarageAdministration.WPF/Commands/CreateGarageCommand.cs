using GarageAdministration.Domain.Models;
using GarageAdministration.WPF.Commons;
using GarageAdministration.WPF.Commons.Stores;
using GarageAdministration.WPF.ViewModels.CreateGarage;

namespace GarageAdministration.WPF.Commands;

public class CreateGarageCommand: AsyncCommandBase
{
    private readonly CreateGarageViewModel _createGarageViewModel;
    private readonly GaragesStore _garagesStore;


    public CreateGarageCommand(CreateGarageViewModel createGarageViewModel, GaragesStore garagesStore)
    {
        _createGarageViewModel = createGarageViewModel;
        _garagesStore = garagesStore;
    }

    protected override async Task ExecuteAsync(object? parameter)
    {
        var form = _createGarageViewModel.GarageFormViewModel;
        var owner = form.SelectedOwner;
        var id = !_garagesStore.Garages.Any() ? 0 : _garagesStore.Garages.Last().Id + 1;
        var mapInfo = new GarageMapInfo(id, 200, 200, 25, 25);
        var garage = new Garage(id, owner, mapInfo);
        await _garagesStore.Add(garage);
    }
}