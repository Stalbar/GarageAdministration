using System.Windows.Input;
using GarageAdministration.WPF.Commands;
using GarageAdministration.WPF.Commons.Stores;
using GarageAdministration.WPF.Commons.ViewModels;
using GarageAdministration.WPF.Services.Abstractions;

namespace GarageAdministration.WPF.ViewModels.CreateGarage;

public class CreateGarageViewModel: ViewModelBase
{
    public GarageFormViewModel GarageFormViewModel { get; }
    public CreateGarageMapViewModel CreateGarageMapViewModel { get; }

    public CreateGarageViewModel(INavigationService navigation, GaragesStore garagesStore, OwnersStore ownersStore, GarageMapInfoStore garageMapInfoStore, GarageBlockStore garageBlockStore)
    {
        ICommand submitCommand = new CreateGarageCommand(this, garagesStore, garageMapInfoStore);
        ICommand cancelCommand = new NavigateToGarageMapViewCommand(navigation);
        ICommand mapUpdateCommand = new UpdateMapFromFormCommand(this);
        ICommand mapClickCommand = new CreateGarageUpdateMapCommand(garagesStore, this, garageMapInfoStore);
        GarageFormViewModel = new GarageFormViewModel(navigation, ownersStore, submitCommand, cancelCommand, mapUpdateCommand, null);
        CreateGarageMapViewModel = new CreateGarageMapViewModel(garagesStore, garageBlockStore, navigation, mapClickCommand);
    }
}