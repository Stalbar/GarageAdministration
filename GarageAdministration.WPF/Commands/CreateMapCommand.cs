using System.Windows.Forms;
using GarageAdministration.Domain.Models;
using GarageAdministration.WPF.Commons;
using GarageAdministration.WPF.Commons.Stores;
using GarageAdministration.WPF.Commons.ViewModels;
using GarageAdministration.WPF.Services.Abstractions;
using GarageAdministration.WPF.ViewModels.CreateMap;
using GarageAdministration.WPF.ViewModels.GarageMap;
using MessageBox = System.Windows.MessageBox;

namespace GarageAdministration.WPF.Commands;

public class CreateMapCommand: AsyncCommandBase
{
    private readonly MapsStore _mapsStore;
    private readonly INavigationService _navigation;
    private readonly CreateMapViewModel _createMapViewModel;

    public CreateMapCommand(MapsStore mapsStore, INavigationService navigation, CreateMapViewModel createMapViewModel)
    {
        _mapsStore = mapsStore;
        _navigation = navigation;
        _createMapViewModel = createMapViewModel;
    }

    protected override async Task ExecuteAsync(object? parameter)
    {
        if (parameter is null or "")
        {
            MessageBox.Show("Выберите файл с изображением");
            return;
        }
        var mapId = !_mapsStore.Maps.Any() ? 1 : _mapsStore.Maps.Last().Id + 1;
        var fileName = (string)parameter!;
        var form = _createMapViewModel.MapFormViewModel;
        if (!IsValidForm(form))
        {
            return;
        }
        var mapName = form.MapName;
        var map = new Map(mapId, fileName, mapName);
        await _mapsStore.Add(map);
        _navigation.NavigateTo<GarageMapViewModel>();
    }

    private bool IsValidForm(MapFormViewModel form)
    {
        if (form.MapName is null or "")
        {
            MessageBox.Show("Заполните поле Название");
            return false;
        }

        if (form.SelectedPath is null or "")
        {
            MessageBox.Show("Выберите файл с изображением");
            return false;
        }

        return true;
    }
}