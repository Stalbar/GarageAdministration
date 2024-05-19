namespace GarageAdministration.Domain.Models;

public class Map
{
    public int Id { get; set; }
    public string PathToImage { get; set; }
    public string Name { get; set; }
    public List<Garage> Garages { get; set; } = new List<Garage>();
    public Map(int id, string pathToImage, string name)
    {
        Id = id;
        PathToImage = pathToImage;
        Name = name;
    }

    public Map()
    {
        
    }
    public override string ToString() => Name;
}