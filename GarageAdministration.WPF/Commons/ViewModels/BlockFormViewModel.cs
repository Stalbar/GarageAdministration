using System.Windows;
using System.Windows.Input;
using GarageAdministration.WPF.Services.Abstractions;

namespace GarageAdministration.WPF.Commons.ViewModels;

public class BlockFormViewModel: ViewModelBase
{
    private INavigationService _navigation;
    private double _height;
    private double _width;
    private double _angle;

    public INavigationService Navigation
    {
        get => _navigation;
        set
        {
            _navigation = value;
            OnPropertyChanged(nameof(Navigation));
        }
    }

    public double Width
    {
        get => _width;
        set
        {
            _width = value;
            OnPropertyChanged(nameof(Width));
            MapUpdateCommand?.Execute(null);
        }
    }

    public double Height
    {
        get => _height;
        set
        {
            _height = value;
            OnPropertyChanged(nameof(Height));
            MapUpdateCommand?.Execute(null);
        }
    }

    public double Angle
    {
        get => _angle;
        set
        {
            _angle = value;
            OnPropertyChanged(nameof(Angle));
            MapUpdateCommand?.Execute(null);
        }
    }

    public Visibility CanDelete => DeleteCommand != null ? Visibility.Visible : Visibility.Collapsed;
    
    public ICommand SubmitCommand { get; }
    public ICommand CancelCommand { get; }
    
    public ICommand? DeleteCommand { get; }
    public ICommand? MapUpdateCommand { get; }

    public BlockFormViewModel(INavigationService navigation, ICommand submitCommand, ICommand cancelCommand,
        ICommand? mapUpdateCommand = null, ICommand? deleteCommand = null)
    {
        MapUpdateCommand = mapUpdateCommand;
        _width = 10;
        _height = 10;
        Navigation = navigation;
        SubmitCommand = submitCommand;
        CancelCommand = cancelCommand;
        DeleteCommand = deleteCommand;
    }
}