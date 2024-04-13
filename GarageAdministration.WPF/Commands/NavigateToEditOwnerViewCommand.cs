using GarageAdministration.Domain.Models;
using GarageAdministration.WPF.Commons;
using GarageAdministration.WPF.Commons.Stores;
using GarageAdministration.WPF.Services.Abstractions;
using GarageAdministration.WPF.ViewModels.EditOwner;
using GarageAdministration.WPF.ViewModels.OwnersList;

namespace GarageAdministration.WPF.Commands;

public class NavigateToEditOwnerViewCommand: CommandBase
{
    private readonly OwnersListItemViewModel _ownersListItemViewModel;
    private readonly OwnersStore _ownersStore;
    private readonly INavigationService _navigation;

    public NavigateToEditOwnerViewCommand(OwnersStore ownersStore, OwnersListItemViewModel ownersListItemViewModel, INavigationService navigation)
    {
        _ownersStore = ownersStore;
        _ownersListItemViewModel = ownersListItemViewModel;
        _navigation = navigation;
    }

    public override void Execute(object? parameter)
    {
        Owner owner = _ownersListItemViewModel.Owner;
        EditOwnerViewModel editOwnerViewModel = new EditOwnerViewModel(owner, _ownersStore, _navigation);
        _navigation.NavigateTo(editOwnerViewModel);
    }
}