namespace GarageAdministration.Domain.Models;

public class MapInfo
{
    public int Id { get; set; }
    public double Top { get; set; }
    public double Left { get; set; }
    public double Width { get; set; }
    public double Height { get; set; }
    public double Angle { get; set; }
    public double ZIndex { get; set; }
    
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

    public MapInfo()
    {
        
    }
}