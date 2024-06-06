using GarageAdministration.Domain.Models;
using GarageAdministration.WPF.Commons;
using GarageAdministration.WPF.Commons.Stores;
using GarageAdministration.WPF.Services.Abstractions;
using GarageAdministration.WPF.ViewModels.OwnersList;

namespace GarageAdministration.WPF.Commands;

public class DeleteOwnerCommand: AsyncCommandBase
{
    private readonly Owner _owner;
    private readonly OwnersStore _ownersStore;
    private readonly INavigationService _navigation;

    public DeleteOwnerCommand(OwnersStore ownersStore, INavigationService navigation, Owner owner)
    {
        _ownersStore = ownersStore;
        _navigation = navigation;
        _owner = owner;
    }

    protected override async Task ExecuteAsync(object? parameter)
    {
        await _ownersStore.Delete(_owner.Id);
        
        _navigation.NavigateTo<OwnersListViewModel>();
    }
}