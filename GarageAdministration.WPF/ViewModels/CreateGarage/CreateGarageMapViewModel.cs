using System.Collections.ObjectModel;
using System.Windows.Input;
using GarageAdministration.Domain.Models;
using GarageAdministration.WPF.Commons.Stores;
using GarageAdministration.WPF.Commons.ViewModels;
using GarageAdministration.WPF.Services.Abstractions;

namespace GarageAdministration.WPF.ViewModels.CreateGarage;

public class CreateGarageMapViewModel : ViewModelBase
{
    private readonly GaragesStore _garagesStore;
    private readonly GarageBlockStore _garageBlockStore;
    private readonly ObservableCollection<CreateGarageMapItemViewModel> _createGarageMapItemViewModels;
    private readonly ObservableCollection<CreateGarageBlockItemViewModel> _createGarageBlockItemViewModels;
    private readonly INavigationService _navigation;
    private bool _isGarageCreated;
    private Garage _createdGarage;
    
    public string BGImage => "map1.png";
    public double Width => System.Windows.SystemParameters.PrimaryScreenWidth;
    public double Height => System.Windows.SystemParameters.PrimaryScreenHeight;

    public IEnumerable<CreateGarageMapItemViewModel> CreateGarageMapItemViewModels => _createGarageMapItemViewModels;

    public IEnumerable<CreateGarageBlockItemViewModel> CreateGarageBlockItemViewModels =>
        _createGarageBlockItemViewModels;
    
    public Garage CreatedGarage
    {
        get => _createdGarage;
        set
        {
            _createdGarage = value;
            if (!_isGarageCreated)
            {
                _isGarageCreated = true;
                AddGarage(_createdGarage, System.Windows.Media.Brushes.Green);
            }
            else
            {
                var item = _createGarageMapItemViewModels.First(g => g.Garage.Id == _createdGarage.Id);
                _createGarageMapItemViewModels.Remove(item);
                AddGarage(_createdGarage, System.Windows.Media.Brushes.Green);
            }
        }
    }

    public bool IsGarageCreated
    {
        get => _isGarageCreated;
        set
        {
            _isGarageCreated = value;
            OnPropertyChanged(nameof(IsGarageCreated));
        }
    }
    
    public ICommand MapClickCommand { get; }

    public CreateGarageMapViewModel(GaragesStore garagesStore, GarageBlockStore garageBlockStore, INavigationService navigation,
        ICommand mapClickCommand)
    {
        _isGarageCreated = false;
        
        _garagesStore = garagesStore;
        _navigation = navigation;
        MapClickCommand = mapClickCommand;
        _garageBlockStore = garageBlockStore;
        
        _createGarageMapItemViewModels = new ObservableCollection<CreateGarageMapItemViewModel>();
        _createGarageBlockItemViewModels = new ObservableCollection<CreateGarageBlockItemViewModel>();
        
        _garagesStore.GarageAdded += GaragesStore_GarageAdded;
        _garagesStore.GarageDeleted += GaragesStore_GarageDeleted;
        _garagesStore.GarageUpdated += GaragesStore_GarageUpdated;
        _garagesStore.GaragesLoaded += GaragesStore_GaragesLoaded;
        
        _garageBlockStore.GarageBlockAdded += GarageBlockStoreOnGarageBlockAdded;
        _garageBlockStore.GarageBlockDeleted += GarageBlockStoreOnGarageBlockDeleted;
        _garageBlockStore.GarageBlockUpdated += GarageBlockStoreOnGarageBlockUpdated;
        _garageBlockStore.GarageBlocksLoaded += GarageBlockStoreOnGarageBlocksLoaded;
        
        GaragesStore_GaragesLoaded();
        GarageBlockStoreOnGarageBlocksLoaded();
    }

    private void GarageBlockStoreOnGarageBlocksLoaded()
    {
        _createGarageBlockItemViewModels.Clear();
        foreach (var garageBlock in _garageBlockStore.GarageBlocks)
        {
            AddGarageBlock(garageBlock);
        }
    }

    private void GarageBlockStoreOnGarageBlockUpdated(GarageBlock garageBlock)
    {
        var garageBlockViewModel =
            _createGarageBlockItemViewModels.FirstOrDefault(g => g.GarageBlock.Id == garageBlock.Id);
        garageBlockViewModel?.Update(garageBlock);
    }

    private void GarageBlockStoreOnGarageBlockDeleted(int id)
    {
        var garageBlockViewModel = _createGarageBlockItemViewModels.FirstOrDefault(g => g.GarageBlock.Id == id);
        if (garageBlockViewModel != null)
        {
            _createGarageBlockItemViewModels.Remove(garageBlockViewModel);
        }
    }

    private void GarageBlockStoreOnGarageBlockAdded(GarageBlock garageBlock)
    {
        AddGarageBlock(garageBlock);
    }

    private void GaragesStore_GaragesLoaded()
    {
        _createGarageMapItemViewModels.Clear();
        foreach (var garage in _garagesStore.Garages)
        {
            AddGarage(garage, System.Windows.Media.Brushes.Red);
        }
    }

    private void GaragesStore_GarageUpdated(Garage garage)
    {
        var garageViewModel = _createGarageMapItemViewModels.FirstOrDefault(g => g.Garage.Id == garage.Id);

        garageViewModel?.Update(garage);
    }

    private void GaragesStore_GarageDeleted(int id)
    {
        var garageViewModel = _createGarageMapItemViewModels.FirstOrDefault(g => g.Garage.Id == id);

        if (garageViewModel != null)
        {
            _createGarageMapItemViewModels.Remove(garageViewModel);
        }
    }

    private void GaragesStore_GarageAdded(Garage garage)
    {
        AddGarage(garage, System.Windows.Media.Brushes.Red);
    }

    public override void Dispose()
    {
        _garagesStore.GarageAdded -= GaragesStore_GarageAdded;
        _garagesStore.GarageDeleted -= GaragesStore_GarageDeleted;
        _garagesStore.GarageUpdated -= GaragesStore_GarageUpdated;
        _garagesStore.GaragesLoaded -= GaragesStore_GaragesLoaded;

        _garageBlockStore.GarageBlockAdded -= GarageBlockStoreOnGarageBlockAdded;
        _garageBlockStore.GarageBlockDeleted -= GarageBlockStoreOnGarageBlockDeleted;
        _garageBlockStore.GarageBlockUpdated -= GarageBlockStoreOnGarageBlockUpdated;
        _garageBlockStore.GarageBlocksLoaded -= GarageBlockStoreOnGarageBlocksLoaded;
    }

    private void AddGarage(Garage garage, System.Windows.Media.Brush color)
    {
        _createGarageMapItemViewModels.Add(new CreateGarageMapItemViewModel(garage, color));
    }

    private void AddGarageBlock(GarageBlock garageBlock)
    {
        _createGarageBlockItemViewModels.Add(new CreateGarageBlockItemViewModel(garageBlock));
    }
}