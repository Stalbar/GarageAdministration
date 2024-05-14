using System.Windows;
using System.Windows.Input;
using GarageAdministration.WPF.Services.Abstractions;

namespace GarageAdministration.WPF.Commons.ViewModels;

public class OwnerFormViewModel: ViewModelBase
{
    private INavigationService _navigation;
    private string _name;
    private string _surname;
    private string _patronymic;

    public INavigationService Navigation
    {
        get => _navigation;
        set
        {
            _navigation = value;
            OnPropertyChanged(nameof(Navigation));
        }
    }

    public string Name
    {
        get => _name;
        set
        {
            _name = value;
            OnPropertyChanged(nameof(Name));
        }
    }

    public string Surname
    {
        get => _surname;
        set
        {
            _surname = value;
            OnPropertyChanged(nameof(Surname));
        }
    }

    public string Patronymic
    {
        get => _patronymic;
        set
        {
            _patronymic = value;
            OnPropertyChanged(nameof(Patronymic));
        }
    }

    public Visibility CanDelete => DeleteCommand != null ? Visibility.Visible : Visibility.Collapsed;
    
    public ICommand SubmitCommand { get; }
    public ICommand CancelCommand { get; }
    
    public ICommand? DeleteCommand { get; }
    
    public OwnerFormViewModel(INavigationService navigation, ICommand submitCommand, ICommand cancelCommand, ICommand? deleteCommand = null)
    {
        Navigation = navigation;
        SubmitCommand = submitCommand;
        CancelCommand = cancelCommand;
        DeleteCommand = deleteCommand;
    }
}