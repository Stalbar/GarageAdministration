using GarageAdministration.WPF.Commons;
using GarageAdministration.WPF.Services.Abstractions;
using GarageAdministration.WPF.ViewModels.CreateGarage;

namespace GarageAdministration.WPF.Commands;

public class NavigateToCreateGarageViewCommand: CommandBase
{
    private readonly INavigationService _navigation;

    public NavigateToCreateGarageViewCommand(INavigationService navigation)
    {
        _navigation = navigation;
    }

    public override void Execute(object? parameter)
    {
        _navigation.NavigateTo<CreateGarageViewModel>();
    }
}