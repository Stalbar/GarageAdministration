using GarageAdministration.EF.DTOs;
using Microsoft.EntityFrameworkCore;

namespace GarageAdministration.EF;

public class GarageAdministrationDbContext: DbContext
{
    public DbSet<GarageDto> Garages { get; set; } = null!;
    public DbSet<PositionDto> Positions { get; set; } = null!;

    public GarageAdministrationDbContext(DbContextOptions options) : base(options)
    {
        
    }
}