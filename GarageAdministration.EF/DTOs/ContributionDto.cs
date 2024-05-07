namespace GarageAdministration.EF.DTOs;

public class ContributionDto
{
    public int Id { get; set; }
    public decimal MembershipFee { get; }
    public decimal WaterFee { get; }
    public int GarageId { get; set; }
    public GarageDto? Garage { get; set; }
}