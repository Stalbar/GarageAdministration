namespace GarageAdministration.Domain.Models;

public class Garage
{
    public int Id { get; set; }
    public int MapInfoId { get; set; }
    public MapInfo MapInfo { get; set; }
    public int OwnerId { get; set; }
    public Owner Owner { get; set; }
    public int MapId { get; set; }
    public Map? Map { get; set; }
    public int ContributionId { get; set; }
    public Contribution Contribution { get; set; }
    public Garage(int id, Owner owner, MapInfo mapInfo, Map map, Contribution contribution)
    {
        Id = id;
        Owner = owner;
        MapInfo = mapInfo;
        Map = map;
        Contribution = contribution;
    }
    
    public Garage()
    {}
}