using GarageAdministration.Domain.Models;
using GarageAdministration.WPF.Commons;
using GarageAdministration.WPF.ViewModels.EditGarage;

namespace GarageAdministration.WPF.Commands;

public class UpdateMapFromEditFormCommand : CommandBase
{
    private readonly EditGarageViewModel _editGarageViewModel;
    private bool flag = true;

    public UpdateMapFromEditFormCommand(EditGarageViewModel editGarageViewModel)
    {
        _editGarageViewModel = editGarageViewModel;
    }

    public override void Execute(object? parameter)
    {
        if (_editGarageViewModel.GarageFormViewModel != null)
        {
            var garage = _editGarageViewModel.CreateGarageMapViewModel.CreatedGarage;
            var width = _editGarageViewModel.GarageFormViewModel.Width;
            var height = _editGarageViewModel.GarageFormViewModel.Height;
            var newMapInfo =
                new MapInfo(garage.MapInfo.Id, garage.MapInfo.Top, garage.MapInfo.Left, width, height, 0, 1);
            _editGarageViewModel.CreateGarageMapViewModel.CreatedGarage =
                new Garage(garage.Id, garage.Owner, newMapInfo);
        }
    }
}