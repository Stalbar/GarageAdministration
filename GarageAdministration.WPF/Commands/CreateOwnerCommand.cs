﻿using GarageAdministration.Domain.Models;
using GarageAdministration.WPF.Commons;
using GarageAdministration.WPF.Commons.Stores;
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
        var id = !_ownersStore.Owners.Any() ? 0 : _ownersStore.Owners.Last().Id + 1;
        var owner = new Owner(id, name, surname, patronymic);
        await _ownersStore.Add(owner);
        _navigation.NavigateTo<OwnersListViewModel>();
    }
}