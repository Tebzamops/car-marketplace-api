using Microsoft.EntityFrameworkCore;
using CarMarketplaceApi.Models;

namespace CarMarketplaceApi.Data;

public class CarMarketplaceDbContext : DbContext
{
    public CarMarketplaceDbContext(
        DbContextOptions<CarMarketplaceDbContext> options)
        : base(options)
    {
    }

    public DbSet<Car> Cars => Set<Car>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Condition> Conditions => Set<Condition>();
    public DbSet<Brand> Brands => Set<Brand>();
    public DbSet<BrandModel> BrandModels => Set<BrandModel>();
    public DbSet<BodyType> BodyTypes => Set<BodyType>();
    public DbSet<FuelType> FuelTypes => Set<FuelType>();
    public DbSet<TransmissionType> TransmissionTypes => Set<TransmissionType>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // CATEGORY
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.IsActive)
                .IsRequired()
                .HasDefaultValue(true);

            entity.HasIndex(e => e.Name)
                .IsUnique();
        });

        // CONDITION
        modelBuilder.Entity<Condition>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.IsActive)
                .IsRequired()
                .HasDefaultValue(true);

            entity.HasIndex(e => e.Name)
                .IsUnique();
        });

        // BRAND
        modelBuilder.Entity<Brand>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(500);

            entity.Property(e => e.IsActive)
                .IsRequired()
                .HasDefaultValue(true);

            entity.HasIndex(e => e.Name)
                .IsUnique();

            entity.HasMany(e => e.Models)
                .WithOne(e => e.Brand)
                .HasForeignKey(e => e.BrandId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        });

        // BRAND MODEL
        modelBuilder.Entity<BrandModel>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.IsActive)
                .IsRequired()
                .HasDefaultValue(true);

            entity.HasIndex(e => new { e.BrandId, e.Name })
                .IsUnique();

            entity.HasMany(e => e.Cars)
                .WithOne(e => e.BrandModel)
                .HasForeignKey(e => e.BrandModelId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
        });

        // BODY TYPE
        modelBuilder.Entity<BodyType>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.IsActive)
                .IsRequired()
                .HasDefaultValue(true);

            entity.HasIndex(e => e.Name)
                .IsUnique();
        });

        // FUEL TYPE
        modelBuilder.Entity<FuelType>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.IsActive)
                .IsRequired()
                .HasDefaultValue(true);

            entity.HasIndex(e => e.Name)
                .IsUnique();
        });

        // TRANSMISSION TYPE
        modelBuilder.Entity<TransmissionType>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.IsActive)
                .IsRequired()
                .HasDefaultValue(true);

            entity.HasIndex(e => e.Name)
                .IsUnique();
        });

        // CAR
        modelBuilder.Entity<Car>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(150);

            entity.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(2000);

            entity.Property(e => e.Year)
                .IsRequired();

            entity.Property(e => e.Mileage)
                .IsRequired();

            entity.Property(e => e.RegularPrice)
                .HasPrecision(18, 2);

            entity.Property(e => e.SalePrice)
                .HasPrecision(18, 2);

            entity.Property(e => e.IsActive)
                .IsRequired()
                .HasDefaultValue(false);

            // Optional lookup relationships
            entity.HasOne(e => e.Category)
                .WithMany(e => e.Cars)
                .HasForeignKey(e => e.CategoryId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Condition)
                .WithMany(e => e.Cars)
                .HasForeignKey(e => e.ConditionId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.TransmissionType)
                .WithMany(e => e.Cars)
                .HasForeignKey(e => e.TransmissionTypeId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.FuelType)
                .WithMany(e => e.Cars)
                .HasForeignKey(e => e.FuelTypeId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.BodyType)
                .WithMany(e => e.Cars)
                .HasForeignKey(e => e.BodyTypeId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            // Year and mileage validation
            entity.ToTable(table =>
            {
                table.HasCheckConstraint(
                    "CK_Cars_Mileage",
                    "[Mileage] >= 0");

                table.HasCheckConstraint(
                    "CK_Cars_Year",
                    "[Year] >= 1886");
            });
        });
    }
}
