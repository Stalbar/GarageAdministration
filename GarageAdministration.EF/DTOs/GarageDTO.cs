namespace GarageAdministration.EF.DTOs;

public class GarageDto
{
    public int Id { get; set; }
    public int MapInfoId { get; set; }
    public GarageMapInfoDto? MapInfo { get; set; }
    public int OwnerId { get; set; }
    public OwnerDto? Owner { get; set; }
}