using GarageAdministration.Domain.Models;
using GarageAdministration.WPF.Commons;
using GarageAdministration.WPF.Commons.Stores;
using GarageAdministration.WPF.ViewModels.EditGarage;

namespace GarageAdministration.WPF.Commands;

public class UpdateMapFromEditFormCommand : CommandBase
{
    private readonly EditGarageViewModel _editGarageViewModel;
    private readonly SelectedMapStore _selectedMapStore;

    public UpdateMapFromEditFormCommand(EditGarageViewModel editGarageViewModel, SelectedMapStore selectedMapStore)
    {
        _editGarageViewModel = editGarageViewModel;
        _selectedMapStore = selectedMapStore;
    }

    public override void Execute(object? parameter)
    {
        if (_editGarageViewModel.GarageFormViewModel != null)
        {
            var garage = _editGarageViewModel.CreateGarageMapViewModel.CreatedGarage;
            var width = _editGarageViewModel.GarageFormViewModel.Width;
            var height = _editGarageViewModel.GarageFormViewModel.Height;
            var angle = _editGarageViewModel.GarageFormViewModel.Angle;
             var newMapInfo =
                new MapInfo(garage.MapInfo.Id, garage.MapInfo.Top, garage.MapInfo.Left, width, height, angle, 1);
            var map = _selectedMapStore.Map;
            _editGarageViewModel.CreateGarageMapViewModel.CreatedGarage =
                new Garage(garage.Id, garage.Owner, newMapInfo, map!, garage.Contribution);
        }
    }
}