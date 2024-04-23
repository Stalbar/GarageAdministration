using System.Windows.Input;
using GarageAdministration.Domain.Models;
using GarageAdministration.WPF.Commons.Stores;
using GarageAdministration.WPF.Services.Abstractions;

namespace GarageAdministration.WPF.Commons.ViewModels;

public class GarageFormViewModel: ViewModelBase
{
    private INavigationService _navigation;
    private Owner _selectedOwner;
    private GarageMapInfo _mapInfo;
    private List<Owner> _owners;

    public Owner SelectedOwner
    {
        get => _selectedOwner;
        set
        {
            _selectedOwner = value;
            OnPropertyChanged(nameof(SelectedOwner));
        }
    }

    public GarageMapInfo MapInfo
    {
        get => _mapInfo;
        set
        {
            _mapInfo = value;
            OnPropertyChanged(nameof(MapInfo));
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
    
    public ICommand SubmitCommand { get; }
    public ICommand CancelCommand { get; }

    public GarageFormViewModel(INavigationService navigation, OwnersStore ownersStore, ICommand submitCommand, ICommand cancelCommand)
    {
        Navigation = navigation;
        SubmitCommand = submitCommand;
        CancelCommand = cancelCommand;
        Owners = ownersStore.Owners;
    }
}