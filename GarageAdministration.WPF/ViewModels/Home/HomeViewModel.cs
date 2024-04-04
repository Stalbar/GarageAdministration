using System.Windows.Input;
using GarageAdministration.WPF.Commands;
using GarageAdministration.WPF.Commons;
using GarageAdministration.WPF.Services.Abstractions;

namespace GarageAdministration.WPF.ViewModels.Home;

public class HomeViewModel: ViewModelBase
{
    private INavigationService _navigation;

    public INavigationService Navigation
    {
        get => _navigation;
        set
        {
            _navigation = value;
            OnPropertyChanged(nameof(Navigation));
        }
    }
    
    public string RandomText => "hello";

    public ICommand NavigateToOwnersListCommand { get; }
    
    public HomeViewModel(INavigationService navigation)
    {
        Navigation = navigation;
        NavigateToOwnersListCommand = new NavigateToOwnersListCommand(Navigation);
    }
}