using GarageAdministration.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace GarageAdministration.EF;

public class GarageAdministrationDbContext: DbContext
{
    public DbSet<Garage> Garages { get; set; } = null!;
    public DbSet<MapInfo> MapInfos { get; set; } = null!;
    public DbSet<Owner> Owners { get; set; } = null!;
    public DbSet<GarageBlock> GarageBlock { get; set; } = null!;
    public DbSet<Map> Maps { get; set; } = null!;
    public DbSet<Contribution> Contributions { get; set; } = null!;
    public DbSet<Report> Reports { get; set; } = null!;
    public GarageAdministrationDbContext(DbContextOptions options) : base(options)
    {
        
    }
}