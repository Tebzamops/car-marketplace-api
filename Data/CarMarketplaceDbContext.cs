using Microsoft.EntityFrameworkCore;
using CarMarketplaceApi.Models;

namespace CarMarketplaceApi.Data;

public class CarMarketplaceDbContext : DbContext
{
    public CarMarketplaceDbContext(DbContextOptions<CarMarketplaceDbContext> options)
        : base(options)
    {
    }

    public DbSet<Car> Cars { get; set; } = null!;
    public DbSet<Brand> Brands { get; set; } = null!;
    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<BrandModel> BrandModels { get; set; } = null!;
    public DbSet<Condition> Conditions { get; set; } = null!;
    public DbSet<BodyType> BodyTypes { get; set; } = null!;
    public DbSet<FuelType> FuelTypes { get; set; } = null!;
    public DbSet<TransmissionType> TransmissionTypes { get; set; } = null!;

}
