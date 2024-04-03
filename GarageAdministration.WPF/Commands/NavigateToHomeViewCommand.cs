using GarageAdministration.WPF.Commons;
using GarageAdministration.WPF.Services.Abstractions;
using GarageAdministration.WPF.ViewModels.Home;

namespace GarageAdministration.WPF.Commands;

public class NavigateToHomeViewCommand: CommandBase
{
    private INavigationService _navigation;

    public NavigateToHomeViewCommand(INavigationService navigation)
    {
        _navigation = navigation;
    }

    public override void Execute(object? parameter)
    {
        _navigation.NavigateTo<HomeViewModel>();
    }
}