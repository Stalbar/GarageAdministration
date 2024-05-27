using System.Windows.Forms;
using GarageAdministration.Domain.Models;
using GarageAdministration.WPF.Commons;
using GarageAdministration.WPF.Commons.Stores;
using GarageAdministration.WPF.Commons.ViewModels;
using GarageAdministration.WPF.Services.Abstractions;
using GarageAdministration.WPF.ViewModels.CreateOwner;
using GarageAdministration.WPF.ViewModels.OwnersList;

namespace GarageAdministration.WPF.Commands;

public class CreateOwnerCommand: AsyncCommandBase
{
    private readonly CreateOwnerViewModel _createOwnerViewModel;
    private readonly OwnersStore _ownersStore;
    private readonly INavigationService _navigation;
    public CreateOwnerCommand(CreateOwnerViewModel createOwnerViewModel, OwnersStore ownersStore, INavigationService navigation)
    {
        _createOwnerViewModel = createOwnerViewModel;
        _ownersStore = ownersStore;
        _navigation = navigation;
    }

    protected override async Task ExecuteAsync(object? parameter)
    {
        var form = _createOwnerViewModel.OwnerFormViewModel;
        var name = form.Name;
        var surname = form.Surname;
        var patronymic = form.Patronymic;
        if (!IsValidForm(form))
        {
            return;
        }
        var id = !_ownersStore.Owners.Any() ? 0 : _ownersStore.Owners.Last().Id + 1;
        var owner = new Owner(id, name, surname, patronymic);
        await _ownersStore.Add(owner);
        _navigation.NavigateTo<OwnersListViewModel>();
    }

    private bool IsValidForm(OwnerFormViewModel form)
    {
        if (form.Name is null or "")
        {
            MessageBox.Show("Заполните поле Имя");
            return false;
        }
        if (form.Surname is null or "")
        {
            MessageBox.Show("Заполните поле Фамилия");
            return false;
        }
        if (form.Patronymic is null or "")
        {
            MessageBox.Show("Заполните поле Отчество");
            return false;
        }
        return true;
    }
}