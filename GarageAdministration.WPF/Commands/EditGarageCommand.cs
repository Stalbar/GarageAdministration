using GarageAdministration.Domain.Models;
using GarageAdministration.WPF.Commons;
using GarageAdministration.WPF.Commons.Stores;
using GarageAdministration.WPF.Services.Abstractions;
using GarageAdministration.WPF.ViewModels.EditGarage;
using GarageAdministration.WPF.ViewModels.GarageMap;

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
        var oldContribution = _contributionsStore.Contributions.First(c => c.Garage.Id == garage.Id);
        var contribution = new Contribution(oldContribution.Id, form.ElectricityFee, form.MembershipFee, garage,
            form.MembershipFeePaymentStatus, form.ElectricityFeePaymentStatus);
        await _garageMapInfoStore.Update(garage.MapInfo);
        await _garagesStore.Update(garage);
        await _contributionsStore.Update(contribution);
        _navigation.NavigateTo<GarageMapViewModel>();
    }
}