using System.Windows;
using System.Windows.Input;
using GarageAdministration.Domain.Models;
using GarageAdministration.WPF.Commons;
using GarageAdministration.WPF.Commons.Stores;
using GarageAdministration.WPF.Commons.ViewModels;
using GarageAdministration.WPF.ViewModels.CreateGarage;

namespace GarageAdministration.WPF.Commands;

public class CreateGarageUpdateMapCommand: CommandBase
{
    private readonly CreateGarageViewModel _createGarageViewModel;
    private readonly GaragesStore _garagesStore;

    public CreateGarageUpdateMapCommand(GaragesStore garagesStore, CreateGarageViewModel createGarageViewModel)
    {
        _garagesStore = garagesStore;
        _createGarageViewModel = createGarageViewModel;
    }

    public override void Execute(object? parameter)
    {
        var mousePos = Mouse.GetPosition((IInputElement)parameter);
        var id = !_garagesStore.Garages.Any() ? 0 : _garagesStore.Garages.Last().Id + 1;
        var owner = _createGarageViewModel.GarageFormViewModel.SelectedOwner;
        var mapInfo = new GarageMapInfo(0, mousePos.Y, mousePos.X, _createGarageViewModel.GarageFormViewModel.Width, _createGarageViewModel.GarageFormViewModel.Height);
        _createGarageViewModel.CreateGarageMapViewModel.CreatedGarage = new Garage(id, owner, mapInfo);
    }
}