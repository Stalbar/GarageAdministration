using Microsoft.EntityFrameworkCore;

namespace GarageAdministration.EF;

public class GarageAdministrationDbContextFactory
{
    private readonly DbContextOptions _options;

    public GarageAdministrationDbContextFactory(DbContextOptions options)
    {
        _options = options;
    }

    public GarageAdministrationDbContext Create()
    {
        return new GarageAdministrationDbContext(_options);
    }
}

