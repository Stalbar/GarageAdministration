namespace GarageAdministration.Domain.Models;

public class MapInfo
{
    public int Id { get; }
    public double Top { get; }
    public double Left { get; }
    public double Width { get; }
    public double Height { get; }
    
    public double Angle { get; }
    public double ZIndex { get; }
    
    public MapInfo(int id, double top, double left, double width, double height, double angle, double zIndex)
    {
        Id = id;
        Top = top;
        Left = left;
        Width = width;
        Height = height;
        Angle = angle;
        ZIndex = zIndex;
    }
}