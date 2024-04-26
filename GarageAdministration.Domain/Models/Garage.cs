namespace GarageAdministration.Domain.Models;

public class Garage
{
    public int Id { get; }
    public MapInfo MapInfo { get; }
    public Owner Owner { get; }
    
    public Garage(int id, Owner owner, MapInfo mapInfo)
    {
        Id = id;
        Owner = owner;
        MapInfo = mapInfo;
    }
}