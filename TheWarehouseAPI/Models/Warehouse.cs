using System.ComponentModel.DataAnnotations.Schema;

namespace TheWarehouseAPI.Models;

public class Warehouse
{
    public int Id { get; set; }
    public string Code { get; set; } // Unique
    public string Name { get; set; }

    public ICollection<WarehouseProduct> WarehouseProducts { get; set; } = new List<WarehouseProduct>();
    
    [NotMapped]
    public Dictionary<int, int> ProductQuantities { get; set; } = new Dictionary<int, int>();
    
}