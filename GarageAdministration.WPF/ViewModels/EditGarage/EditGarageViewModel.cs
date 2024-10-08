﻿using System.Windows.Input;
using GarageAdministration.Domain.Models;
using GarageAdministration.WPF.Commands;
using GarageAdministration.WPF.Commons.Stores;
using GarageAdministration.WPF.Commons.ViewModels;
using GarageAdministration.WPF.Services.Abstractions;
using GarageAdministration.WPF.ViewModels.CreateGarage;

namespace GarageAdministration.WPF.ViewModels.EditGarage;

public class EditGarageViewModel : ViewModelBase
{
    public int GarageId { get; }
    public CreateGarageMapViewModel CreateGarageMapViewModel { get; }
    public GarageFormViewModel GarageFormViewModel { get; }

    public EditGarageViewModel(Garage garage, GaragesStore garagesStore, GarageMapInfoStore garageMapInfoStore,
        OwnersStore ownersStore, INavigationService navigation, GarageBlockStore garageBlockStore,
        ICommand deleteCommand, ContributionsStore contributionsStore, SelectedMapStore selectedMapStore)
    {
        GarageId = garage.Id;
        ICommand mapClickCommand = new EditGarageUpdateMapCommand(this, garagesStore, garageMapInfoStore);
        CreateGarageMapViewModel =
            new CreateGarageMapViewModel(garagesStore, garageBlockStore, navigation, mapClickCommand, selectedMapStore)
            {
                IsGarageCreated = true,
                CreatedGarage = garage,
            };
        ICommand submitCommand = new EditGarageCommand(this, garagesStore, garageMapInfoStore, navigation, contributionsStore);
        ICommand cancelCommand = new NavigateToGarageMapViewCommand(navigation);
        ICommand updateMapFromFormCommand = new UpdateMapFromEditFormCommand(this, selectedMapStore);
        GarageFormViewModel = new GarageFormViewModel(navigation, ownersStore, submitCommand, cancelCommand,
            updateMapFromFormCommand, garage.Owner, deleteCommand: deleteCommand)
        {
            Width = garage.MapInfo.Width,
            Height = garage.MapInfo.Height,
            Angle = garage.MapInfo.Angle,
            ElectricityFee = garage.Contribution.ElectricityFee,
            ElectricityFeePaymentStatus = garage.Contribution.ElectricityFeePaymentStatus,
            MembershipFee = garage.Contribution.MembershipFee,
            MembershipFeePaymentStatus = garage.Contribution.MembershipFeePaymentStatus
        };
    }
}