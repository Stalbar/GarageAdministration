using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows.Media;
using GarageAdministration.Domain.Models;
using GarageAdministration.EF.Migrations;
using GarageAdministration.WPF.Commons.Stores;
using GarageAdministration.WPF.Commons.ViewModels;
using GarageAdministration.WPF.Services.Abstractions;

namespace GarageAdministration.WPF.ViewModels.CreateBlock;

public class CreateBlockMapViewModel: ViewModelBase
{
    private readonly GarageBlockStore _garageBlockStore;
    private readonly GaragesStore _garagesStore;
    private readonly ObservableCollection<GarageMapItemViewModel> _garageMapItemViewModels;
    private readonly ObservableCollection<BlockMapItemViewModel> _blockMapItemViewModels;
    private readonly INavigationService _navigation;
    private bool _isBlockCreated;
    private GarageBlock _createGarageBlock;

    public IEnumerable<GarageMapItemViewModel> GarageMapItemViewModels => _garageMapItemViewModels;
    public IEnumerable<BlockMapItemViewModel> BlockMapItemViewModels => _blockMapItemViewModels;

    public GarageBlock CreatedGarageBlock
    {
        get => _createGarageBlock;
        set
        {
            _createGarageBlock = value;
            if (!_isBlockCreated)
            {
                _isBlockCreated = true;
                AddGarageBlock(_createGarageBlock, Brushes.Green);
            }
            else
            {
                var item = _blockMapItemViewModels.First(b => b.GarageBlock.Id == _createGarageBlock.Id);
                _blockMapItemViewModels.Remove(item);
                AddGarageBlock(_createGarageBlock, Brushes.Green);
            }
        }
    }

    public bool IsBlockCreated
    {
        get => _isBlockCreated;
        set
        {
            _isBlockCreated = value;
            OnPropertyChanged(nameof(IsBlockCreated));
        }
    }
    
    public ICommand MapClickCommand { get; }

    public CreateBlockMapViewModel(GaragesStore garagesStore, GarageBlockStore garageBlockStore,
        INavigationService navigation, ICommand mapClickCommand)
    {
        _isBlockCreated = false;
        _garageBlockStore = garageBlockStore;
        _garagesStore = garagesStore;
        _navigation = navigation;
        MapClickCommand = mapClickCommand;
        _blockMapItemViewModels = new ObservableCollection<BlockMapItemViewModel>();
        _garageMapItemViewModels = new ObservableCollection<GarageMapItemViewModel>();
        
        _garagesStore.GarageAdded += GaragesStoreOnGarageAdded;
        _garagesStore.GarageDeleted += GaragesStoreOnGarageDeleted;
        _garagesStore.GarageUpdated += GaragesStoreOnGarageUpdated;
        _garagesStore.GaragesLoaded += GaragesStoreOnGaragesLoaded;
        
        _garageBlockStore.GarageBlockAdded += GarageBlockStoreOnGarageBlockAdded;
        _garageBlockStore.GarageBlockDeleted += GarageBlockStoreOnGarageBlockDeleted;
        _garageBlockStore.GarageBlockUpdated += GarageBlockStoreOnGarageBlockUpdated;
        _garageBlockStore.GarageBlocksLoaded += GarageBlockStoreOnGarageBlocksLoaded;
        
        GaragesStoreOnGaragesLoaded();
        GarageBlockStoreOnGarageBlocksLoaded();
    }

    private void GarageBlockStoreOnGarageBlocksLoaded()
    {
        _blockMapItemViewModels.Clear();
        foreach (var garageBlock in _garageBlockStore.GarageBlocks)
        {
            AddGarageBlock(garageBlock, Brushes.Gray);
        }
    }

    private void GarageBlockStoreOnGarageBlockUpdated(GarageBlock block)
    {
        var blockViewModel = _blockMapItemViewModels.FirstOrDefault(g => g.GarageBlock.Id == block.Id);

        blockViewModel?.Update(block);
    }

    private void GarageBlockStoreOnGarageBlockDeleted(int id)
    {
        var blockViewModel = _blockMapItemViewModels.FirstOrDefault(g => g.GarageBlock.Id == id);
    }

    private void GarageBlockStoreOnGarageBlockAdded(GarageBlock block)
    {
        AddGarageBlock(block, Brushes.Gray);
    }

    private void GaragesStoreOnGaragesLoaded()
    {
        _garageMapItemViewModels.Clear();
        foreach (var garage in _garagesStore.Garages)
        {
            AddGarage(garage);
        }
    }

    private void GaragesStoreOnGarageUpdated(Garage garage)
    {
        var garageViewModel = _garageMapItemViewModels.FirstOrDefault(g => g.Garage.Id == garage.Id);

        garageViewModel?.Update(garage);
    }

    private void GaragesStoreOnGarageDeleted(int id)
    {
        var garageViewModel = _garageMapItemViewModels.FirstOrDefault(g => g.Garage.Id == id);

        if (garageViewModel != null)
        {
            _garageMapItemViewModels.Remove(garageViewModel);
        }
    }

    private void GaragesStoreOnGarageAdded(Garage garage)
    {
        AddGarage(garage);
    }

    private void AddGarageBlock(GarageBlock garageBlock, Brush color)
    {
        _blockMapItemViewModels.Add(new BlockMapItemViewModel(garageBlock, color));
    }

    private void AddGarage(Garage garage)
    {
        _garageMapItemViewModels.Add(new GarageMapItemViewModel(garage));
    }
}