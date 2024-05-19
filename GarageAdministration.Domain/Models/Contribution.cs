using GarageAdministration.Infrastracture.Enums;

namespace GarageAdministration.Domain.Models;

public class Contribution
{
    public int Id { get; set; }
    public decimal ElectricityFee { get; set; }
    public PaymentStatus ElectricityFeePaymentStatus { get; set; }
    public decimal MembershipFee { get; set; }
    public PaymentStatus MembershipFeePaymentStatus { get; set; }

    public Contribution(int id, decimal electricityFee, decimal membershipFee, PaymentStatus membershipFeePaymentStatus, PaymentStatus electricityFeePaymentStatus)
    {
        Id = id;
        ElectricityFee = electricityFee;
        MembershipFee = membershipFee;
        MembershipFeePaymentStatus = membershipFeePaymentStatus;
        ElectricityFeePaymentStatus = electricityFeePaymentStatus;
    }

    public Contribution()
    {
        
    }
}