namespace GarageAdministration.Domain.Models;

public class Owner
{
    public int Id { get; }
    public string Name { get; }
    public string Surname { get; }
    public string Patronymic { get; }

    public Owner(int id, string name, string surname, string patronymic)
    {
        Id = id;
        Name = name;
        Surname = surname;
        Patronymic = patronymic;
    }

    public override string ToString() => $"{Surname} {Name} {Patronymic}";
}