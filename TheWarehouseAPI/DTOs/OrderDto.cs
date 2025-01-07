namespace TheWarehouseAPI.DTOs;

public class OrderDto
{
    public int ProductId { get; set; }
    public int SourceWarehouseId { get; set; }
    public int DestinationWarehouseId { get; set; }
    public int Quantity { get; set; }
}