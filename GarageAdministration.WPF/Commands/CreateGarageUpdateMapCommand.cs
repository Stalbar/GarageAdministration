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
    private readonly GarageMapInfoStore _garageMapInfoStore;
    private readonly ContributionsStore _contributionsStore;
    private readonly SelectedMapStore _selectedMapStore;

    public CreateGarageUpdateMapCommand(GaragesStore garagesStore, CreateGarageViewModel createGarageViewModel, GarageMapInfoStore garageMapInfoStore, ContributionsStore contributionsStore, SelectedMapStore selectedMapStore)
    {
        _garagesStore = garagesStore;
        _createGarageViewModel = createGarageViewModel;
        _garageMapInfoStore = garageMapInfoStore;
        _contributionsStore = contributionsStore;
        _selectedMapStore = selectedMapStore;
    }

    public override void Execute(object? parameter)
    {
        var mousePos = Mouse.GetPosition((IInputElement)parameter);
        var id = !_garagesStore.Garages.Any() ? 1 : _garagesStore.Garages.Last().Id + 1;
        var owner = _createGarageViewModel.GarageFormViewModel.SelectedOwner;
        var mapInfoId = !_garageMapInfoStore.MapInfos.Any() ? 1 : _garageMapInfoStore.MapInfos.Last().Id + 1;   
        var mapInfo = new MapInfo(mapInfoId, mousePos.Y, mousePos.X, _createGarageViewModel.GarageFormViewModel.Width, _createGarageViewModel.GarageFormViewModel.Height, _createGarageViewModel.GarageFormViewModel.Angle, 1);
        var map = _selectedMapStore.Map!;
        var form = _createGarageViewModel.GarageFormViewModel;
        var contributionId = !_contributionsStore.Contributions.Any()
            ? 1
            : _contributionsStore.Contributions.Last().Id + 1;
        var contribution = new Contribution(contributionId, form.ElectricityFee, form.MembershipFee,
            form.MembershipFeePaymentStatus, form.ElectricityFeePaymentStatus);
        _createGarageViewModel.CreateGarageMapViewModel.CreatedGarage = new Garage(id, owner, mapInfo, map, contribution);
    }
}