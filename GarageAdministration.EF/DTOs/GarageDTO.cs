namespace GarageAdministration.EF.DTOs;

public class GarageDto
{
    public int Id { get; set; }
    public int PositionId { get; set; }
    public PositionDto? Position { get; set; }
}