namespace GarageAdministration.Domain.Models;

public class Report
{
    public int Id { get; set; }
    public string PathToFile { get; set; }
    public DateTime CreationDate { get; set; }
    
    public Report(int id, string pathToFile, DateTime creationDate)
    {
        Id = id;
        PathToFile = pathToFile;
        CreationDate = creationDate;
    }
    
    public Report(){}
}