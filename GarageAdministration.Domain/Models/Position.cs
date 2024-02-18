namespace GarageAdministration.Domain.Models;

public class Position
{
    public int Id { get; }
    public double XPosition { get; }
    public double YPosition { get; }
    
    public Position(int id, double xPosition, double yPosition)
    {
        Id = id;
        XPosition = xPosition;
        YPosition = yPosition;
    }
}