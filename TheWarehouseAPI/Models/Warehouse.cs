namespace TheWarehouseAPI.Models;

public class Warehouse
{
    public int Id { get; set; }
    public string Code { get; set; } // Unique
    public string Name { get; set; }
}