using GarageAdministration.Infrastracture.Enums;

namespace GarageAdministration.Domain.Models;

public class Contribution
{
    public int Id { get; }
    public decimal ElectricityFee { get; }
    
    public PaymentStatus ElectricityFeePaymentStatus { get; }
    public decimal MembershipFee { get; }
    
    public PaymentStatus MembershipFeePaymentStatus { get; }
    public Garage Garage { get; }

    public Contribution(int id, decimal electricityFee, decimal membershipFee, Garage garage, PaymentStatus membershipFeePaymentStatus, PaymentStatus electricityFeePaymentStatus)
    {
        Id = id;
        ElectricityFee = electricityFee;
        MembershipFee = membershipFee;
        Garage = garage;
        MembershipFeePaymentStatus = membershipFeePaymentStatus;
        ElectricityFeePaymentStatus = electricityFeePaymentStatus;
    }
}