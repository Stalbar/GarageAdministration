using System.Windows;
using System.Windows.Input;
using GarageAdministration.Domain.Models;
using GarageAdministration.Infrastracture.Enums;
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
    private double _angle;
    private decimal _electricityFee;
    private PaymentStatus _electricityFeePaymentStatus;
    private decimal _membershipFee;
    private PaymentStatus _membershipFeePaymentStatus;

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

    public double Angle
    {
        get => _angle;
        set
        {
            _angle = value;
            OnPropertyChanged(nameof(Angle));
            MapUpdateCommand.Execute(null);
        }
    }

    public decimal ElectricityFee
    {
        get => _electricityFee;
        set
        {
            _electricityFee = value;
            OnPropertyChanged(nameof(ElectricityFee));
        }
    }
    
    public PaymentStatus ElectricityFeePaymentStatus
    {
        get => _electricityFeePaymentStatus;
        set
        {
            if (_electricityFeePaymentStatus == value) return;
            _electricityFeePaymentStatus = value;
            OnPropertyChanged(nameof(ElectricityFeePaymentStatus));
        }
    }

    public decimal MembershipFee
    {
        get => _membershipFee;
        set
        {
            _membershipFee = value;
            OnPropertyChanged(nameof(MembershipFee));
        }
    }

    public PaymentStatus MembershipFeePaymentStatus
    {
        get => _membershipFeePaymentStatus;
        set
        {
            _membershipFeePaymentStatus = value;
            OnPropertyChanged(nameof(MembershipFeePaymentStatus));
        }
    }

    public Visibility CanDelete => DeleteCommand != null ? Visibility.Visible : Visibility.Collapsed;
    
    public ICommand SubmitCommand { get; }
    public ICommand CancelCommand { get; }

    public ICommand? DeleteCommand { get; }
    public ICommand MapUpdateCommand { get;  }
    
    public GarageFormViewModel(INavigationService navigation, OwnersStore ownersStore, ICommand submitCommand, ICommand cancelCommand, ICommand mapUpdateCommand, Owner owner, ICommand? deleteCommand = null)
    {
        MapUpdateCommand = mapUpdateCommand;
        _width = 10;
        _height = 10;
        Navigation = navigation;
        SubmitCommand = submitCommand;
        CancelCommand = cancelCommand;
        Owners = ownersStore.Owners;
        SelectedOwner = owner == null ? null : Owners.First(o => o.Id == owner.Id);
        DeleteCommand = deleteCommand;
    }
}