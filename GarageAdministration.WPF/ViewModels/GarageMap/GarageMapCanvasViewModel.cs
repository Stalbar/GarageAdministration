using System.Collections;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Shapes;
using GarageAdministration.Domain.Models;
using GarageAdministration.WPF.Commands;
using GarageAdministration.WPF.Commons.Stores;
using GarageAdministration.WPF.Commons.ViewModels;
using GarageAdministration.WPF.Services.Abstractions;

namespace GarageAdministration.WPF.ViewModels.GarageMap;

public class GarageMapCanvasViewModel: ViewModelBase
{
    private readonly GaragesStore _garagesStore;
    private readonly ObservableCollection<GarageMapCanvasItemViewModel> _garageMapCanvasItemViewModels;
    private readonly INavigationService _navigation;

    public IEnumerable<GarageMapCanvasItemViewModel> GarageMapCanvasItemViewModels => _garageMapCanvasItemViewModels;

    public GarageMapCanvasViewModel(GaragesStore garagesStore, INavigationService navigation)
    {
        _garagesStore = garagesStore;
        _navigation = navigation;
        _garageMapCanvasItemViewModels = new ObservableCollection<GarageMapCanvasItemViewModel>();
        _garagesStore.GarageAdded += GaragesStore_GarageAdded;
        _garagesStore.GarageDeleted += GaragesStore_GarageDeleted;
        _garagesStore.GarageUpdated += GaragesStore_GarageUpdated;
        _garagesStore.GaragesLoaded += GaragesStore_GaragesLoaded;
        GaragesStore_GaragesLoaded();
    }

    private void GaragesStore_GaragesLoaded()
    {
        _garageMapCanvasItemViewModels.Clear();
        foreach (var garage in _garagesStore.Garages)
        {
            AddGarage(garage);
        }
    }

    private void GaragesStore_GarageUpdated(Garage garage)
    {
        var garageViewModel = _garageMapCanvasItemViewModels.FirstOrDefault(g => g.Garage.Id == garage.Id);

        garageViewModel?.Update(garage);
    }

    private void GaragesStore_GarageDeleted(int id)
    {
        var garageViewModel = _garageMapCanvasItemViewModels.FirstOrDefault(g => g.Garage.Id == id);

        if (garageViewModel != null)
        {
            _garageMapCanvasItemViewModels.Remove(garageViewModel);
        }
    }

    private void GaragesStore_GarageAdded(Garage garage)
    {
        AddGarage(garage);
    }

    public override void Dispose()
    {
        _garagesStore.GarageAdded -= GaragesStore_GarageAdded;
        _garagesStore.GarageDeleted -= GaragesStore_GarageDeleted;
        _garagesStore.GarageUpdated -= GaragesStore_GarageUpdated;
        _garagesStore.GaragesLoaded -= GaragesStore_GaragesLoaded;
    }

    private void AddGarage(Garage garage)
    {
        _garageMapCanvasItemViewModels.Add(new GarageMapCanvasItemViewModel(garage, _garagesStore, _navigation));
    }
}