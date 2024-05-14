using GarageAdministration.Infrastracture.Enums;

namespace GarageAdministration.EF.DTOs;

public class ContributionDto
{
    public int Id { get; set; }
    public decimal MembershipFee { get; set; }
    public PaymentStatus MembershipFeePaymentStatus { get; set; }
    public decimal ElectricityFee { get; set; }
    public PaymentStatus ElectricityFeePaymentStatus { get; set; }
}