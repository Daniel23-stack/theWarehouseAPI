namespace TheWarehouseAPI.Models;

public class Product
{
    public int Id { get; set; }
    public string Code { get; set; } // Unique
    public string Description { get; set; }
}