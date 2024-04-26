namespace GarageAdministration.EF.DTOs;

public class GarageBlockDTO
{
    public int Id { get; set; }
    public int MapInfoId { get; set; }
    public MapInfoDto? MapInfo { get; set; }
}