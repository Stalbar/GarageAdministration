namespace GarageAdministration.Domain.Models;

public class Garage
{
    public Position Position { get; }
    
    public Garage(Position position)
    {
        Position = position;
    }
}