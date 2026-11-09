namespace CarMarketplaceApi.Models;

public class Car
{
    public long Id { get; set; }

    //Foreign Keys
    public int? CategoryId { get; set; }
    public int? BrandModelId { get; set; }
    public int? TransmissionTypeId { get; set; }
    public int? FuelTypeId { get; set; }
    public int? BodyTypeId { get; set; }
    public int? ConditionId { get; set; }


    public string Name { get; set; } = string.Empty;
    public int Year { get; set; }
    public string Description { get; set; } = string.Empty;
    public int Mileage { get; set; }
    public decimal? RegularPrice { get; set; }
    public decimal? SalePrice { get; set; }
    public bool IsActive { get; set; } = false;


    // Navigation properties
    public Category? Category { get; set; }
    public Condition? Condition { get; set; }
    public BrandModel? BrandModel { get; set; }
    public TransmissionType? TransmissionType { get; set; }
    public FuelType? FuelType { get; set; }
    public BodyType? BodyType { get; set; }

}