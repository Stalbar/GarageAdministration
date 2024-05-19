namespace GarageAdministration.Domain.Models;

public class Owner
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Patronymic { get; set; }
    public List<Garage> Garages { get; set; } = new List<Garage>();

    public Owner(int id, string name, string surname, string patronymic)
    {
        Id = id;
        Name = name;
        Surname = surname;
        Patronymic = patronymic;
    }

    public Owner()
    {
        
    }
    
    public override string ToString() => $"{Surname} {Name} {Patronymic}";
}