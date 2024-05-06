using System.Collections;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Shapes;
using GarageAdministration.Domain.Models;
using GarageAdministration.EF.Migrations;
using GarageAdministration.WPF.Commands;
using GarageAdministration.WPF.Commons.Stores;
using GarageAdministration.WPF.Commons.ViewModels;
using GarageAdministration.WPF.Services.Abstractions;

namespace GarageAdministration.WPF.ViewModels.GarageMap;

public class GarageMapCanvasViewModel: ViewModelBase
{
    private readonly GaragesStore _garagesStore;
    private readonly GarageBlockStore _garageBlockStore;
    private readonly ObservableCollection<GarageMapCanvasItemViewModel> _garageMapCanvasItemViewModels;
    private readonly ObservableCollection<GarageMapCanvasBlockItemViewModel> _garageMapCanvasBlockItemViewModels;
    private readonly INavigationService _navigation;
    private readonly GarageMapInfoStore _garageMapInfoStore;
    private readonly OwnersStore _ownersStore;
    public string BGImage => "map1.png";
    public double Width => System.Windows.SystemParameters.PrimaryScreenWidth;
    public double Height => System.Windows.SystemParameters.PrimaryScreenHeight;
    
    public IEnumerable<GarageMapCanvasItemViewModel> GarageMapCanvasItemViewModels => _garageMapCanvasItemViewModels;
    public IEnumerable<GarageMapCanvasBlockItemViewModel> GarageMapCanvasBlockItemViewModels =>
        _garageMapCanvasBlockItemViewModels;

    public GarageMapCanvasViewModel(GaragesStore garagesStore, INavigationService navigation, GarageMapInfoStore garageMapInfoStore, OwnersStore ownersStore, GarageBlockStore garageBlockStore)
    {
        _garageBlockStore = garageBlockStore;
        _garagesStore = garagesStore;
        _navigation = navigation;
        _garageMapInfoStore = garageMapInfoStore;
        _ownersStore = ownersStore;
        
        _garageMapCanvasItemViewModels = new ObservableCollection<GarageMapCanvasItemViewModel>();
        _garageMapCanvasBlockItemViewModels = new ObservableCollection<GarageMapCanvasBlockItemViewModel>();
        
        _garagesStore.GarageAdded += GaragesStore_GarageAdded;
        _garagesStore.GarageDeleted += GaragesStore_GarageDeleted;
        _garagesStore.GarageUpdated += GaragesStore_GarageUpdated;
        _garagesStore.GaragesLoaded += GaragesStore_GaragesLoaded;

        _garageBlockStore.GarageBlockAdded += GarageBlockStore_GarageBlockAdded;
        _garageBlockStore.GarageBlockDeleted += GarageBlockStore_GarageBlockDeleted;
        _garageBlockStore.GarageBlockUpdated += GarageBlockStore_GarageBlockUpdated;
        _garageBlockStore.GarageBlocksLoaded += GarageBlockStore_GarageBlocksLoaded;
        
        GaragesStore_GaragesLoaded();
        GarageBlockStore_GarageBlocksLoaded();
    }

    private void GarageBlockStore_GarageBlocksLoaded()
    {
        _garageMapCanvasBlockItemViewModels.Clear();
        foreach (var garageBlock in _garageBlockStore.GarageBlocks)
        {
            AddGarageBlock(garageBlock);
        }
    }

    private void GarageBlockStore_GarageBlockUpdated(GarageBlock garageBlock)
    {
        var garageBlockViewModel =
            _garageMapCanvasBlockItemViewModels.FirstOrDefault(g => g.GarageBlock.Id == garageBlock.Id);
        
        garageBlockViewModel?.Update(garageBlock);
    }

    private void GarageBlockStore_GarageBlockDeleted(int id)
    {
        var garageBlockViewModel = _garageMapCanvasBlockItemViewModels.FirstOrDefault(g => g.GarageBlock.Id == id);
        if (garageBlockViewModel != null)
        {
            _garageMapCanvasBlockItemViewModels.Remove(garageBlockViewModel);
        }
    }

    private void GarageBlockStore_GarageBlockAdded(GarageBlock garageBlock)
    {
        AddGarageBlock(garageBlock);
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

        _garageBlockStore.GarageBlockAdded -= GarageBlockStore_GarageBlockAdded;
        _garageBlockStore.GarageBlockDeleted -= GarageBlockStore_GarageBlockDeleted;
        _garageBlockStore.GarageBlockUpdated -= GarageBlockStore_GarageBlockUpdated;
        _garageBlockStore.GarageBlocksLoaded -= GarageBlockStore_GarageBlocksLoaded;
    }

    private void AddGarage(Garage garage)
    {
        _garageMapCanvasItemViewModels.Add(new GarageMapCanvasItemViewModel(garage, _garagesStore, _navigation, _garageMapInfoStore, _ownersStore, _garageBlockStore));
    }

    private void AddGarageBlock(GarageBlock garageBlock)
    {
        _garageMapCanvasBlockItemViewModels.Add(new GarageMapCanvasBlockItemViewModel(garageBlock, _garageBlockStore, _navigation, _garagesStore, _garageMapInfoStore));
    }
}