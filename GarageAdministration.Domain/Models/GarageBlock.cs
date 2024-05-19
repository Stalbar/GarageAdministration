namespace GarageAdministration.Domain.Models;

public class GarageBlock
{
    public int Id { get; set; }
    public int MapInfoId { get; set; }
    public MapInfo MapInfo { get; set; }

    public GarageBlock(int id, MapInfo mapInfo)
    {
        Id = id;
        MapInfo = mapInfo;
    }

    public GarageBlock()
    {
        
    }
}