using GarageAdministration.Domain.Models;
using GarageAdministration.WPF.Commons;
using GarageAdministration.WPF.Commons.Stores;
using GarageAdministration.WPF.Services.Abstractions;
using GarageAdministration.WPF.ViewModels.EditOwner;
using GarageAdministration.WPF.ViewModels.OwnersList;

namespace GarageAdministration.WPF.Commands;

public class NavigateToEditOwnerViewCommand: CommandBase
{
    private readonly OwnersStore _ownersStore;
    private readonly INavigationService _navigation;

    public NavigateToEditOwnerViewCommand(OwnersStore ownersStore, INavigationService navigation)
    {
        _ownersStore = ownersStore;
        _navigation = navigation;
    }

    public override void Execute(object? parameter)
    {
        if (parameter is null)
        {
            return;
        }
        var owner = (parameter as OwnersListItemViewModel)!.Owner;  
        EditOwnerViewModel editOwnerViewModel = new EditOwnerViewModel(owner, _ownersStore, _navigation);
        _navigation.NavigateTo(editOwnerViewModel);
    }
}