namespace GarageAdministration.Domain.Models;

public class Garage
{
    public int Id { get; }
    public GarageMapInfo MapInfo { get; }
    public Owner Owner { get; }
    
    public Garage(int id, Owner owner, GarageMapInfo mapInfo)
    {
        Id = id;
        Owner = owner;
        MapInfo = mapInfo;
    }
}