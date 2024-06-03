using System.Windows;
using GarageAdministration.Domain.Models;
using GarageAdministration.WPF.Commons;
using GarageAdministration.WPF.Commons.Stores;
using GarageAdministration.WPF.ViewModels.EditGarage;
using Microsoft.VisualBasic.Devices;
using Mouse = System.Windows.Input.Mouse;

namespace GarageAdministration.WPF.Commands;

public class EditGarageUpdateMapCommand: CommandBase
{
    private readonly EditGarageViewModel _editGarageViewModel;
    private readonly GaragesStore _garagesStore;
    private readonly GarageMapInfoStore _garageMapInfoStore;

    public EditGarageUpdateMapCommand(EditGarageViewModel editGarageViewModel, GaragesStore garagesStore, GarageMapInfoStore garageMapInfoStore)
    {
        _editGarageViewModel = editGarageViewModel;
        _garagesStore = garagesStore;
        _garageMapInfoStore = garageMapInfoStore;
    }


    public override void Execute(object? parameter)
    {
        var mousePos = Mouse.GetPosition((IInputElement)parameter);
        var garage = _garagesStore.Garages.First(g => g.Id == _editGarageViewModel.GarageId);
        var mapInfo = new MapInfo(garage.MapInfo.Id, mousePos.Y, mousePos.X,
            _editGarageViewModel.GarageFormViewModel.Width, _editGarageViewModel.GarageFormViewModel.Height, 0, 1);
        _editGarageViewModel.CreateGarageMapViewModel.CreatedGarage = new Garage(garage.Id, garage.Owner, mapInfo, garage.Map, garage.Contribution);
    }
}