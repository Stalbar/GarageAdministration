using GarageAdministration.WPF.Commons;
using GarageAdministration.WPF.Services.Abstractions;
using GarageAdministration.WPF.ViewModels.CreateBlock;

namespace GarageAdministration.WPF.Commands;

public class NavigateToCreateBlockViewCommand: CommandBase
{
    private readonly INavigationService _navigation;

    public NavigateToCreateBlockViewCommand(INavigationService navigation)
    {
        _navigation = navigation;
    }

    public override void Execute(object? parameter)
    {
        _navigation.NavigateTo<CreateBlockViewModel>();
    }
}