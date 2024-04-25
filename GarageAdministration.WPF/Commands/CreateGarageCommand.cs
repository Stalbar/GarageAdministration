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
        var garage = _createGarageViewModel.CreateGarageMapViewModel.CreatedGarage;
        await _garagesStore.Add(garage);
    }
}