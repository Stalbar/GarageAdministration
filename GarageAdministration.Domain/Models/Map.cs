namespace GarageAdministration.Domain.Models;

public class Map
{
    public int Id { get; }
    public string PathToImage { get; }
    public string Name { get; }
    public Map(int id, string pathToImage, string name)
    {
        Id = id;
        PathToImage = pathToImage;
        Name = name;
    }

    public override string ToString() => Name;
}