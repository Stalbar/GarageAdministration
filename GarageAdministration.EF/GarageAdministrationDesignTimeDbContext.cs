using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace GarageAdministration.EF;

public class GarageAdministrationDesignTimeDbContext: IDesignTimeDbContextFactory<GarageAdministrationDbContext>
{
    public GarageAdministrationDbContext CreateDbContext(string[] args)
    {
        return new GarageAdministrationDbContext(new DbContextOptionsBuilder().UseSqlite("Data Source=db.db;").Options);
    }
}