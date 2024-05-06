namespace GarageAdministration.Domain.Models;

public class Map
{
    public int Id { get; }
    public string PathToImage { get; }

    public Map(int id, string pathToImage)
    {
        Id = id;
        PathToImage = pathToImage;
    }
}