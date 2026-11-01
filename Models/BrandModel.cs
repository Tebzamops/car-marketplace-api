namespace CarMarketplaceApi.Models;

public class BrandModel
{
    public int Id { get; set; }

    public int BrandId { get; set; }

    public string Name { get; set; } = string.Empty;

    public bool IsActive { get; set; } = true;

    public Brand Brand { get; set; } = null!;

    public ICollection<Car> Cars { get; set; } = new List<Car>();
}