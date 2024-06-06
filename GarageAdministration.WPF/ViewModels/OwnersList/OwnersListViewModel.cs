using System.Collections;
using System.Collections.ObjectModel;
using System.Windows.Input;
using GarageAdministration.Domain.Models;
using GarageAdministration.WPF.Commands;
using GarageAdministration.WPF.Commons;
using GarageAdministration.WPF.Commons.Stores;
using GarageAdministration.WPF.Commons.ViewModels;
using GarageAdministration.WPF.Services.Abstractions;

namespace GarageAdministration.WPF.ViewModels.OwnersList;

public class OwnersListViewModel: ViewModelBase
{
    private readonly OwnersStore _ownersStore;
    private readonly ObservableCollection<OwnersListItemViewModel> _ownersListItemViewModels;
    private INavigationService _navigation;

    public INavigationService Navigation
    {
        get => _navigation;
        set
        {
            _navigation = value;
            OnPropertyChanged(nameof(Navigation));
        }
    }
    public IEnumerable<OwnersListItemViewModel> OwnersListItemViewModels => _ownersListItemViewModels;
    
    public ICommand NavigateToCreateOwnerViewCommand { get; }
    public ICommand ClickCommand { get; }

    public OwnersListViewModel(OwnersStore ownersStore, INavigationService navigation)
    {
        _ownersStore = ownersStore;
        Navigation = navigation;
        NavigateToCreateOwnerViewCommand = new NavigateToCreateOwnerViewCommand(Navigation);
        ClickCommand = new NavigateToEditOwnerViewCommand(ownersStore, navigation);
        _ownersListItemViewModels = new ObservableCollection<OwnersListItemViewModel>();
        _ownersStore.OwnerAdded += OwnersStore_OwnerAdded;
        _ownersStore.OwnerDeleted += OwnersStore_OwnerDeleted;
        _ownersStore.OwnerUpdated += OwnersStore_OwnerUpdated;
        _ownersStore.OwnersLoaded += OwnersStore_OwnersLoaded;
        OwnersStore_OwnersLoaded();
    }

    public override void Dispose()
    {
        _ownersStore.OwnerAdded -= OwnersStore_OwnerAdded;
        _ownersStore.OwnerDeleted -= OwnersStore_OwnerDeleted;
        _ownersStore.OwnerUpdated -= OwnersStore_OwnerUpdated;
        _ownersStore.OwnersLoaded -= OwnersStore_OwnersLoaded;
    }

    private void OwnersStore_OwnersLoaded()
    {
        _ownersListItemViewModels.Clear();
        foreach (var owner in _ownersStore.Owners)
        {
            AddOwner(owner);
        }
    }

    private void OwnersStore_OwnerUpdated(Owner owner)
    {
        var ownerViewModel = _ownersListItemViewModels.FirstOrDefault(o => o.Owner.Id == owner.Id);

        ownerViewModel?.Update(owner);
    }

    private void OwnersStore_OwnerDeleted(int id)
    {
        var ownerViewModel = _ownersListItemViewModels.FirstOrDefault(o => o.Owner.Id == id);

        if (ownerViewModel != null)
        {
            _ownersListItemViewModels.Remove(ownerViewModel);
        }
    }

    private void OwnersStore_OwnerAdded(Owner owner)
    {
        AddOwner(owner);
    }

    private void AddOwner(Owner owner)
    {
        _ownersListItemViewModels.Add(new OwnersListItemViewModel(owner, _ownersStore, _navigation));        
    }
}