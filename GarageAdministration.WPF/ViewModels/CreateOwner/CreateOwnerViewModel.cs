using System.Windows.Input;
using GarageAdministration.WPF.Commands;
using GarageAdministration.WPF.Commons;
using GarageAdministration.WPF.Commons.Stores;
using GarageAdministration.WPF.Services.Abstractions;

namespace GarageAdministration.WPF.ViewModels.CreateOwner;

public class CreateOwnerViewModel: ViewModelBase
{
    public CreateOwnerFormViewModel CreateOwnerFormViewModel { get; }
    public CreateOwnerViewModel(INavigationService navigation, OwnersStore ownersStore)
    {
        ICommand submitCommand = new CreateOwnerCommand(this, ownersStore);
        ICommand cancelCommand = new NavigateToOwnersListCommand(navigation);
        CreateOwnerFormViewModel = new CreateOwnerFormViewModel(navigation, submitCommand, cancelCommand);
    }
}