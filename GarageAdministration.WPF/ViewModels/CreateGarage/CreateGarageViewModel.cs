using System.Windows.Input;
using GarageAdministration.WPF.Commands;
using GarageAdministration.WPF.Commons.Stores;
using GarageAdministration.WPF.Commons.ViewModels;
using GarageAdministration.WPF.Services.Abstractions;

namespace GarageAdministration.WPF.ViewModels.CreateGarage;

public class CreateGarageViewModel: ViewModelBase
{
    public GarageFormViewModel GarageFormViewModel { get; }

    public CreateGarageViewModel(INavigationService navigation, GaragesStore garagesStore, OwnersStore ownersStore)
    {
        ICommand submitCommand = new CreateGarageCommand(this, garagesStore);
        ICommand cancelCommand = new NavigateToGarageMapViewCommand(navigation);
        GarageFormViewModel = new GarageFormViewModel(navigation, ownersStore, submitCommand, cancelCommand);
    }
}