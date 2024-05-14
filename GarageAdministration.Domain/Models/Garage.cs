namespace GarageAdministration.Domain.Models;

public class Garage
{
    public int Id { get; }
    public MapInfo MapInfo { get; }
    public Owner Owner { get; }
    
    public Map? Map { get; }
    public Contribution Contribution { get; }
    public Garage(int id, Owner owner, MapInfo mapInfo, Map map, Contribution contribution)
    {
        Id = id;
        Owner = owner;
        MapInfo = mapInfo;
        Map = map;
        Contribution = contribution;
    }
}