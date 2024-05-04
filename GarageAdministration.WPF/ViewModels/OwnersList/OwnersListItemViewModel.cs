using System.Windows.Input;
using GarageAdministration.Domain.Models;
using GarageAdministration.WPF.Commands;
using GarageAdministration.WPF.Commons;
using GarageAdministration.WPF.Commons.Stores;
using GarageAdministration.WPF.Commons.ViewModels;
using GarageAdministration.WPF.Services.Abstractions;

namespace GarageAdministration.WPF.ViewModels.OwnersList;

public class OwnersListItemViewModel: ViewModelBase
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
    
    public Owner Owner { get; private set; }
    public string FullName => Owner.Name + " " + Owner.Surname + " " + Owner.Patronymic;

    public ICommand EditCommand { get; }
    public ICommand DeleteCommand { get; }
    
    public OwnersListItemViewModel(Owner owner, OwnersStore ownersStore, INavigationService navigationService)
    {
        Owner = owner;
        _navigation = navigationService;
        EditCommand = new NavigateToEditOwnerViewCommand(ownersStore, this, _navigation);
        DeleteCommand = new DeleteOwnerCommand(this, ownersStore, _navigation);
    }

    public void Update(Owner owner)
    {
        Owner = owner;
        OnPropertyChanged(nameof(FullName));
    }
}