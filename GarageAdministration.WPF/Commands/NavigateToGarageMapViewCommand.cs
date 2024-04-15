using GarageAdministration.WPF.Commons;
using GarageAdministration.WPF.Services.Abstractions;
using GarageAdministration.WPF.ViewModels.GarageMap;

namespace GarageAdministration.WPF.Commands;

public class NavigateToGarageMapViewCommand: CommandBase
{
    private readonly INavigationService _navigation;

    public NavigateToGarageMapViewCommand(INavigationService navigation)
    {
        _navigation = navigation;
    }

    public override void Execute(object? parameter)
    {
        _navigation.NavigateTo<GarageMapViewModel>();
    }
}