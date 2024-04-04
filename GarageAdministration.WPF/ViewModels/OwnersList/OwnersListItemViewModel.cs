using GarageAdministration.Domain.Models;
using GarageAdministration.WPF.Commons;
using GarageAdministration.WPF.Commons.Stores;

namespace GarageAdministration.WPF.ViewModels.OwnersList;

public class OwnersListItemViewModel: ViewModelBase
{
    public Owner Owner { get; private set; }

    public OwnersListItemViewModel(Owner owner)
    {
        Owner = owner;
    }

    public void Update(Owner owner)
    {
        Owner = owner;
        
        OnPropertyChanged(nameof(Owner));
    }
}