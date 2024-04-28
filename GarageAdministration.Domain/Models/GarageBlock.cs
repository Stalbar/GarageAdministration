namespace GarageAdministration.Domain.Models;

public class GarageBlock
{
    public int Id { get; }
    public MapInfo MapInfo { get; }

    public GarageBlock(int id, MapInfo mapInfo)
    {
        Id = id;
        MapInfo = mapInfo;
    }
}