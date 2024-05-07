﻿namespace GarageAdministration.EF.DTOs;

public class ContributionDto
{
    public int Id { get; set; }
    public decimal MembershipFee { get; set; }
    public decimal ElectricityFee { get; set; }
    public int GarageId { get; set; }
    public GarageDto? Garage { get; set; }
}