using System.Collections.ObjectModel;
using System.Windows.Input;
using GarageAdministration.Domain.Models;
using GarageAdministration.WPF.Commands;
using GarageAdministration.WPF.Commons.Stores;
using GarageAdministration.WPF.Commons.ViewModels;
using GarageAdministration.WPF.Services.Abstractions;

namespace GarageAdministration.WPF.ViewModels.CreateGarage;

public class CreateGarageMapViewModel : ViewModelBase
{
    private readonly GaragesStore _garagesStore;
    private readonly ObservableCollection<CreateGarageMapItemViewModel> _createGarageMapItemViewModels;
    private readonly INavigationService _navigation;
    private bool _isGarageCreated;
    private Garage _createdGarage;

    public IEnumerable<CreateGarageMapItemViewModel> CreateGarageMapItemViewModels => _createGarageMapItemViewModels;

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

    public CreateGarageMapViewModel(GaragesStore garagesStore, INavigationService navigation,
        ICommand mapClickCommand)
    {
        _isGarageCreated = false;
        _garagesStore = garagesStore;
        _navigation = navigation;
        MapClickCommand = mapClickCommand;
        _createGarageMapItemViewModels = new ObservableCollection<CreateGarageMapItemViewModel>();
        _garagesStore.GarageAdded += GaragesStore_GarageAdded;
        _garagesStore.GarageDeleted += GaragesStore_GarageDeleted;
        _garagesStore.GarageUpdated += GaragesStore_GarageUpdated;
        _garagesStore.GaragesLoaded += GaragesStore_GaragesLoaded;
        GaragesStore_GaragesLoaded();
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
    }

    private void AddGarage(Garage garage, System.Windows.Media.Brush color)
    {
        _createGarageMapItemViewModels.Add(new CreateGarageMapItemViewModel(garage, color));
    }
}