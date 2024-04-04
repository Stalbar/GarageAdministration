using GarageAdministration.WPF.Commons;
using GarageAdministration.WPF.Services.Abstractions;
using GarageAdministration.WPF.ViewModels.OwnersList;

namespace GarageAdministration.WPF.Commands;

public class NavigateToOwnersListCommand: CommandBase
{
    private INavigationService _navigation;

    public NavigateToOwnersListCommand(INavigationService navigation)
    {
        _navigation = navigation;
    }

    public override void Execute(object? parameter)
    {
        _navigation.NavigateTo<OwnersListViewModel>();
    }
}