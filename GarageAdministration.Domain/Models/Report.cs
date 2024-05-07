namespace GarageAdministration.Domain.Models;

public class Report
{
    public int Id { get; }
    public string PathToFile { get; }
    public DateTime CreationDate { get; }
    
    public Report(int id, string pathToFile, DateTime creationDate)
    {
        Id = id;
        PathToFile = pathToFile;
        CreationDate = creationDate;
    }
}