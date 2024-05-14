using System.Windows.Input;
using GarageAdministration.WPF.Services.Abstractions;

namespace GarageAdministration.WPF.Commons.ViewModels;

public class MapFormViewModel: ViewModelBase
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
    
    public ICommand CreateCommand { get; }
    public ICommand CancelCommand { get; }

    public MapFormViewModel(INavigationService navigation, ICommand createCommand, ICommand cancelCommand)
    {
        Navigation = navigation;
        CreateCommand = createCommand;
        CancelCommand = cancelCommand;
    }
}