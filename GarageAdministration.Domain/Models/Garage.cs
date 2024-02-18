namespace GarageAdministration.Domain.Models;

public class Garage
{
    public int Id { get; }
    public Position Position { get; }
    
    public Garage(int id, Position position)
    {
        Id = id;
        Position = position;
    }
}