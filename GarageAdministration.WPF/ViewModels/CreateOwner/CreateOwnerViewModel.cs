using System.Windows.Input;
using GarageAdministration.WPF.Commands;
using GarageAdministration.WPF.Commons;
using GarageAdministration.WPF.Commons.Stores;
using GarageAdministration.WPF.Commons.ViewModels;
using GarageAdministration.WPF.Services.Abstractions;

namespace GarageAdministration.WPF.ViewModels.CreateOwner;

public class CreateOwnerViewModel: ViewModelBase
{
    public OwnerFormViewModel OwnerFormViewModel { get; }
    public CreateOwnerViewModel(INavigationService navigation, OwnersStore ownersStore)
    {
        ICommand submitCommand = new CreateOwnerCommand(this, ownersStore, navigation);
        ICommand cancelCommand = new NavigateToOwnersListCommand(navigation);
        OwnerFormViewModel = new OwnerFormViewModel(navigation, submitCommand, cancelCommand);
    }
}