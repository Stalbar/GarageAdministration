using GarageAdministration.Domain.Models;
using GarageAdministration.WPF.Commons;
using GarageAdministration.WPF.Commons.Stores;
using GarageAdministration.WPF.ViewModels.EditOwner;

namespace GarageAdministration.WPF.Commands;

public class EditOwnerCommand: AsyncCommandBase
{
    private readonly EditOwnerViewModel _editOwnerViewModel;
    private readonly OwnersStore _ownersStore;

    public EditOwnerCommand(EditOwnerViewModel editOwnerViewModel, OwnersStore ownersStore)
    {
        _editOwnerViewModel = editOwnerViewModel;
        _ownersStore = ownersStore;
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
    }
}