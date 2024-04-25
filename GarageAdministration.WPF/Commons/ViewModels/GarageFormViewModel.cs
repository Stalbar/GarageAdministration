using System.Windows.Input;
using GarageAdministration.Domain.Models;
using GarageAdministration.WPF.Commons.Stores;
using GarageAdministration.WPF.Services.Abstractions;

namespace GarageAdministration.WPF.Commons.ViewModels;

public class GarageFormViewModel: ViewModelBase
{
    private INavigationService _navigation;
    private Owner _selectedOwner;
    private List<Owner> _owners;
    private double _height;
    private double _width;

    public Owner SelectedOwner
    {
        get => _selectedOwner;
        set
        {
            _selectedOwner = value;
            OnPropertyChanged(nameof(SelectedOwner));
        }
    }

    public INavigationService Navigation
    {
        get => _navigation;
        set
        {
            _navigation = value;
            OnPropertyChanged(nameof(Navigation));
        }
    }

    public IEnumerable<Owner> Owners
    {
        get => _owners;
        set
        {
            _owners = value.ToList();
            OnPropertyChanged(nameof(Owners));
        }
    }

    public double Width
    {
        get => _width;
        set
        {
            _width = value;
            OnPropertyChanged(nameof(Width));
            MapUpdateCommand.Execute(null);
        }
    }

    public double Height
    {
        get => _height;
        set
        {
            _height = value;
            OnPropertyChanged(nameof(Height));
            MapUpdateCommand.Execute(null);
        }
    }
    
    public ICommand SubmitCommand { get; }
    public ICommand CancelCommand { get; }

    public ICommand MapUpdateCommand { get;  }
    
    public GarageFormViewModel(INavigationService navigation, OwnersStore ownersStore, ICommand submitCommand, ICommand cancelCommand, ICommand mapUpdateCommand, Owner owner)
    {
        MapUpdateCommand = mapUpdateCommand;
        _width = 10;
        _height = 10;
        Navigation = navigation;
        SubmitCommand = submitCommand;
        CancelCommand = cancelCommand;
        Owners = ownersStore.Owners;
        SelectedOwner = owner;
    }
}