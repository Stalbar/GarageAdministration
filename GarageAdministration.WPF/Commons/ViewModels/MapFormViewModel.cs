using System.Windows.Input;
using GarageAdministration.WPF.Services.Abstractions;

namespace GarageAdministration.WPF.Commons.ViewModels;

public class MapFormViewModel: ViewModelBase
{
    private INavigationService _navigation;
    private string _selectedPath;

    public INavigationService Navigation
    {
        get => _navigation;
        set
        {
            _navigation = value;
            OnPropertyChanged(nameof(Navigation));
        }
    }

    public string SelectedPath
    {
        get => _selectedPath;
        set
        {
            _selectedPath = value;
            OnPropertyChanged(nameof(SelectedPath));
        }
    }
    
    public ICommand SubmitCommand { get; }
    public ICommand CancelCommand { get; }
    public ICommand SelectFileCommand { get; }
    
    public MapFormViewModel(INavigationService navigation, ICommand submitCommand, ICommand cancelCommand, ICommand selectFileCommand)
    {
        Navigation = navigation;
        SubmitCommand = submitCommand;
        CancelCommand = cancelCommand;
        SelectFileCommand = selectFileCommand;
    }
}