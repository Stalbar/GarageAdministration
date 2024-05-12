using GarageAdministration.Domain.Models;
using GarageAdministration.WPF.Commons;
using GarageAdministration.WPF.Commons.ViewModels;
using GarageAdministration.WPF.ViewModels.CreateGarage;

namespace GarageAdministration.WPF.Commands;

public class UpdateMapFromFormCommand: CommandBase
{
    private readonly CreateGarageViewModel _createGarageViewModel;
    public UpdateMapFromFormCommand(CreateGarageViewModel createGarageViewModel)
    {
        _createGarageViewModel = createGarageViewModel;
    }

    public override void Execute(object? parameter)
    {
        var garage = _createGarageViewModel.CreateGarageMapViewModel.CreatedGarage;
        var width = _createGarageViewModel.GarageFormViewModel.Width;
        var height = _createGarageViewModel.GarageFormViewModel.Height;
        var angle = _createGarageViewModel.GarageFormViewModel.Angle;
        var newMapInfo = new MapInfo(garage.MapInfo.Id, garage.MapInfo.Top, garage.MapInfo.Left, width, height, angle, 1);
        var map = new Map(1, "");
        _createGarageViewModel.CreateGarageMapViewModel.CreatedGarage = new Garage(garage.Id, garage.Owner, newMapInfo, garage.Map);
    }
}