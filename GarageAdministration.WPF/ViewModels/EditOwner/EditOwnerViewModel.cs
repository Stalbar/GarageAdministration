using System.Windows.Input;
using GarageAdministration.Domain.Models;
using GarageAdministration.WPF.Commands;
using GarageAdministration.WPF.Commons.Stores;
using GarageAdministration.WPF.Commons.ViewModels;
using GarageAdministration.WPF.Services.Abstractions;
using GarageAdministration.WPF.ViewModels.CreateOwner;

namespace GarageAdministration.WPF.ViewModels.EditOwner;

public class EditOwnerViewModel: ViewModelBase
{
    public int OwnerId { get; }
    public OwnerFormViewModel OwnerFormViewModel { get; }

    public EditOwnerViewModel(Owner owner, OwnersStore ownersStore, INavigationService navigation)
    {
        OwnerId = owner.Id;
        ICommand cancelCommand = new NavigateToOwnersListCommand(navigation);
        ICommand submitCommand = new EditOwnerCommand(this, ownersStore, navigation);
        ICommand deleteCommand = new DeleteOwnerCommand(ownersStore, navigation, owner);
        OwnerFormViewModel = new OwnerFormViewModel(navigation, submitCommand, cancelCommand, deleteCommand)
        {
            Name = owner.Name,
            Surname = owner.Surname,
            Patronymic = owner.Patronymic,
        };
    }
}