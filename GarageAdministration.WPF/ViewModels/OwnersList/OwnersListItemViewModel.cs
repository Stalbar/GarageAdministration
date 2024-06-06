using System.Windows.Input;
using GarageAdministration.Domain.Models;
using GarageAdministration.Infrastracture.Enums;
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
    public string Name => Owner.Name;
    public string Surname => Owner.Surname;
    public string Patronymic => Owner.Patronymic;
    public int GarageCount => Owner.Garages.Count;
    public string HasElectricityDebt =>
        Owner.Garages.Any(g => g.Contribution.ElectricityFeePaymentStatus == PaymentStatus.NotPaid)
            ? "Не выплачен"
            : "Выплачен";

    public string HasMembershipDebt =>
        Owner.Garages.Any(g => g.Contribution.MembershipFeePaymentStatus == PaymentStatus.NotPaid)
            ? "Не выплачен"
            : "Выплачен";

    public decimal ElectricityDebt => Owner.Garages.Sum(g => g.Contribution.ElectricityFee);
    public decimal MembershipDebt => Owner.Garages.Sum(g => g.Contribution.MembershipFee);
    public OwnersListItemViewModel(Owner owner, OwnersStore ownersStore, INavigationService navigationService)
    {
        Owner = owner;
        _navigation = navigationService;
    }

    public void Update(Owner owner)
    {
        Owner = owner;
        OnPropertyChanged(nameof(Name));
        OnPropertyChanged(nameof(Surname));
        OnPropertyChanged(nameof(Patronymic));
    }
}