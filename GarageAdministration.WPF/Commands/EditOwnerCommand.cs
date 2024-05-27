using System.Windows;
using GarageAdministration.Domain.Models;
using GarageAdministration.WPF.Commons;
using GarageAdministration.WPF.Commons.Stores;
using GarageAdministration.WPF.Commons.ViewModels;
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
        if (!IsValidForm(form))
        {
            return;
        }
        var name = form.Name;
        var surname = form.Surname;
        var patronymic = form.Patronymic;
        var id = _editOwnerViewModel.OwnerId;
        var owner = new Owner(id, name, surname, patronymic);

        await _ownersStore.Update(owner);

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