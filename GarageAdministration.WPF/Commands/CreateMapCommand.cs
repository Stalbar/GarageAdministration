using GarageAdministration.Domain.Models;
using GarageAdministration.WPF.Commons;
using GarageAdministration.WPF.Commons.Stores;
using GarageAdministration.WPF.Services.Abstractions;
using GarageAdministration.WPF.ViewModels.CreateMap;
using GarageAdministration.WPF.ViewModels.GarageMap;

namespace GarageAdministration.WPF.Commands;

public class CreateMapCommand: AsyncCommandBase
{
    private readonly MapsStore _mapsStore;
    private readonly INavigationService _navigation;

    public CreateMapCommand(MapsStore mapsStore, INavigationService navigation)
    {
        _mapsStore = mapsStore;
        _navigation = navigation;
    }

    protected override async Task ExecuteAsync(object? parameter)
    {
        var mapId = !_mapsStore.Maps.Any() ? 1 : _mapsStore.Maps.Last().Id + 1;
        var fileName = (string)parameter!;
        var map = new Map(mapId, fileName);
        await _mapsStore.Add(map);
        _navigation.NavigateTo<GarageMapViewModel>();
    }
}