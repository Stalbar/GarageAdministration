using GarageAdministration.Domain.Models;
using GarageAdministration.WPF.Commons;
using GarageAdministration.WPF.Commons.Stores;
using GarageAdministration.WPF.Services.Abstractions;
using GarageAdministration.WPF.ViewModels.CreateGarage;
using GarageAdministration.WPF.ViewModels.GarageMap;

namespace GarageAdministration.WPF.Commands;

public class CreateGarageCommand: AsyncCommandBase
{
    private readonly CreateGarageViewModel _createGarageViewModel;
    private readonly GaragesStore _garagesStore;
    private readonly GarageMapInfoStore _garageMapInfoStore;
    private readonly INavigationService _navigation;
    private readonly ContributionsStore _contributionsStore;
    public CreateGarageCommand(CreateGarageViewModel createGarageViewModel, GaragesStore garagesStore, GarageMapInfoStore garageMapInfoStore, INavigationService navigation, ContributionsStore contributionsStore)
    {
        _createGarageViewModel = createGarageViewModel;
        _garagesStore = garagesStore;
        _garageMapInfoStore = garageMapInfoStore;
        _navigation = navigation;
        _contributionsStore = contributionsStore;
    }

    protected override async Task ExecuteAsync(object? parameter)
    {
        var garage = _createGarageViewModel.CreateGarageMapViewModel.CreatedGarage;
        await _garageMapInfoStore.Add(garage.MapInfo);
        await _contributionsStore.Add(garage.Contribution);
        await _garagesStore.Add(garage);
        _navigation.NavigateTo<GarageMapViewModel>();
    }
}