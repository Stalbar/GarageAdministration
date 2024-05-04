using GarageAdministration.Domain.Models;
using GarageAdministration.WPF.Commons;
using GarageAdministration.WPF.Commons.Stores;
using GarageAdministration.WPF.Services.Abstractions;
using GarageAdministration.WPF.ViewModels.OwnersList;

namespace GarageAdministration.WPF.Commands;

public class DeleteOwnerCommand: AsyncCommandBase
{
    private readonly OwnersListItemViewModel _ownersListItemViewModel;
    private readonly OwnersStore _ownersStore;
    private readonly INavigationService _navigation;

    public DeleteOwnerCommand(OwnersListItemViewModel ownersListItemViewModel, OwnersStore ownersStore, INavigationService navigation)
    {
        _ownersListItemViewModel = ownersListItemViewModel;
        _ownersStore = ownersStore;
        _navigation = navigation;
    }

    protected override async Task ExecuteAsync(object? parameter)
    {
        Owner owner = _ownersListItemViewModel.Owner;

        await _ownersStore.Delete(owner.Id);
        
        _navigation.NavigateTo<OwnersListViewModel>();
    }
}