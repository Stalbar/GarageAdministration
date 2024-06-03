using GarageAdministration.Domain.Models;
using GarageAdministration.WPF.Commons;
using GarageAdministration.WPF.Commons.Stores;
using GarageAdministration.WPF.Commons.ViewModels;
using GarageAdministration.WPF.Services.Abstractions;
using GarageAdministration.WPF.ViewModels.EditGarage;
using GarageAdministration.WPF.ViewModels.GarageMap;
using Xceed.Wpf.Toolkit;

namespace GarageAdministration.WPF.Commands;

public class EditGarageCommand: AsyncCommandBase
{
    private readonly EditGarageViewModel _editGarageViewModel;
    private readonly GaragesStore _garagesStore;
    private readonly GarageMapInfoStore _garageMapInfoStore;
    private readonly INavigationService _navigation;
    private readonly ContributionsStore _contributionsStore;
    
    public EditGarageCommand(EditGarageViewModel editGarageViewModel, GaragesStore garagesStore, GarageMapInfoStore garageMapInfoStore, INavigationService navigation, ContributionsStore contributionsStore)
    {
        _editGarageViewModel = editGarageViewModel;
        _garagesStore = garagesStore;
        _garageMapInfoStore = garageMapInfoStore;
        _navigation = navigation;
        _contributionsStore = contributionsStore;
    }

    protected override async Task ExecuteAsync(object? parameter)
    {
        var garage = _editGarageViewModel.CreateGarageMapViewModel.CreatedGarage;
        var form = _editGarageViewModel.GarageFormViewModel;
        var oldContribution = garage.Contribution;
        var contribution = new Contribution(oldContribution.Id, form.ElectricityFee, form.MembershipFee,
            form.MembershipFeePaymentStatus, form.ElectricityFeePaymentStatus);
        garage = new Garage(garage.Id, garage.Owner, garage.MapInfo, garage.Map, contribution);
        await _garageMapInfoStore.Update(garage.MapInfo);
        await _contributionsStore.Update(contribution);
        await _garagesStore.Update(garage);
        _navigation.NavigateTo<GarageMapViewModel>();
    }

    private bool ValidateForm(GarageFormViewModel form)
    {
        if (form.ElectricityFee < 0)
        {
            MessageBox.Show("Неправльная сумма в поле Взнос за электричество");
            return false;
        }

        if (form.MembershipFee < 0)
        {
            MessageBox.Show("Неправильная сумма в поле Членский взнос");
            return false;
        }

        if (form.SelectedOwner is null)
        {
            MessageBox.Show("Заполните поле владелец");
            return false;
        }

        return true;
    }
}