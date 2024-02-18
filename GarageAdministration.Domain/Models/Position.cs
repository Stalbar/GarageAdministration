namespace GarageAdministration.Domain.Models;

public class Position
{
    public double XPosition { get; }
    public double YPosition { get; }
    
    public Position(double xPosition, double yPosition)
    {
        XPosition = xPosition;
        YPosition = yPosition;
    }
}