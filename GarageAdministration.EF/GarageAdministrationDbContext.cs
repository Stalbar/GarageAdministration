using GarageAdministration.EF.DTOs;
using Microsoft.EntityFrameworkCore;

namespace GarageAdministration.EF;

public class GarageAdministrationDbContext: DbContext
{
    public DbSet<GarageDto> Garages { get; set; } = null!;
    public DbSet<MapInfoDto> MapInfos { get; set; } = null!;
    public DbSet<OwnerDto> Owners { get; set; } = null!;
    public DbSet<GarageBlockDTO> GarageBlock { get; set; } = null!;
    public DbSet<MapDto> Maps { get; set; } = null!;

    public GarageAdministrationDbContext(DbContextOptions options) : base(options)
    {
        
    }
}