namespace GarageAdministration.Domain.Models;

public class GarageMapInfo
{
    public int Id { get; }
    public double Top { get; }
    public double Left { get; }
    public double Width { get; }
    public double Height { get; }
    
    public GarageMapInfo(int id, double top, double left, double width, double height)
    {
        Id = id;
        Top = top;
        Left = left;
        Width = width;
        Height = height;
    }
}