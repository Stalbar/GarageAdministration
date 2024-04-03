using System.Windows.Input;
using GarageAdministration.WPF.Commands;
using GarageAdministration.WPF.Commons;
using GarageAdministration.WPF.Services.Abstractions;

namespace GarageAdministration.WPF.ViewModels.CreateOwner;

public class CreateOwnerViewModel: ViewModelBase
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
    
    public string Text => "world!";
    
    public ICommand NavigateToHomeViewCommand { get; }
    
    public CreateOwnerViewModel(INavigationService navigation)
    {
        Navigation = navigation;
        NavigateToHomeViewCommand = new NavigateToHomeViewCommand(Navigation);
    }
}