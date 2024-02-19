namespace GarageAdministration.Domain.Models;

public class Garage
{
    public int Id { get; }
    public Position Position { get; }
    public Owner Owner { get; }
    
    public Garage(int id, Position position, Owner owner)
    {
        Id = id;
        Position = position;
        Owner = owner;
    }
}