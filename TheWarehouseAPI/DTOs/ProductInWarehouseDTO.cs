namespace TheWarehouseAPI.DTOs;

public class ProductInWarehouseDTO
{
    public string ProductCode { get; set; }
    public string WarehouseCode { get; set; }
    public int Quantity { get; set; }
}