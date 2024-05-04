using GarageAdministration.Domain.Models;
using GarageAdministration.WPF.Commons;
using GarageAdministration.WPF.Commons.Stores;
using GarageAdministration.WPF.Services.Abstractions;
using GarageAdministration.WPF.ViewModels.EditOwner;
using GarageAdministration.WPF.ViewModels.OwnersList;

namespace GarageAdministration.WPF.Commands;

public class EditOwnerCommand: AsyncCommandBase
{
    private readonly EditOwnerViewModel _editOwnerViewModel;
    private readonly OwnersStore _ownersStore;
    private readonly INavigationService _navigation;

    public EditOwnerCommand(EditOwnerViewModel editOwnerViewModel, OwnersStore ownersStore, INavigationService navigation)
    {
        _editOwnerViewModel = editOwnerViewModel;
        _ownersStore = ownersStore;
        _navigation = navigation;
    }

    protected override async Task ExecuteAsync(object? parameter)
    {
        var form = _editOwnerViewModel.OwnerFormViewModel;
        var name = form.Name;
        var surname = form.Surname;
        var patronymic = form.Patronymic;
        var id = _editOwnerViewModel.OwnerId;

        Owner owner = new Owner(id, name, surname, patronymic);

        await _ownersStore.Update(owner);

        _navigation.NavigateTo<OwnersListViewModel>();
    }
}