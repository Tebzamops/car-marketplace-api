namespace CarMarketplaceApi.Models;

public class Condition
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public bool IsActive { get; set; } = true;

    public ICollection<Car> Cars { get; set; }
        = new List<Car>();
}