using GarageAdministration.Infrastracture.Enums;

namespace GarageAdministration.Domain.Models;

public class Contribution
{
    public int Id { get; }
    public decimal ElectricityFee { get; }
    
    public PaymentStatus ElectricityFeePaymentStatus { get; }
    public decimal MembershipFee { get; }
    
    public PaymentStatus MembershipFeePaymentStatus { get; }

    public Contribution(int id, decimal electricityFee, decimal membershipFee, PaymentStatus membershipFeePaymentStatus, PaymentStatus electricityFeePaymentStatus)
    {
        Id = id;
        ElectricityFee = electricityFee;
        MembershipFee = membershipFee;
        MembershipFeePaymentStatus = membershipFeePaymentStatus;
        ElectricityFeePaymentStatus = electricityFeePaymentStatus;
    }
}