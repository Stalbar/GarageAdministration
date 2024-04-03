using GarageAdministration.WPF.Commons;
using GarageAdministration.WPF.Services.Abstractions;
using GarageAdministration.WPF.ViewModels.CreateOwner;

namespace GarageAdministration.WPF.Commands;

public class NavigateToCreateOwnerViewCommand: CommandBase
{
    private INavigationService _navigation;

    public NavigateToCreateOwnerViewCommand(INavigationService navigation)
    {
        _navigation = navigation;
    }

    public override void Execute(object? parameter)
    {
        _navigation.NavigateTo<CreateOwnerViewModel>();
    }
}