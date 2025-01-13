using TheWarehouseAPI.DTOs;
using TheWarehouseAPI.Models;
using TheWarehouseAPI.Repositories;

namespace TheWarehouseAPI.Services;

public class WarehouseService
{
    private readonly IWarehouseRepository _warehouseRepository;
    private readonly IProductRepository _productRepository;

    public WarehouseService(IWarehouseRepository warehouseRepository, IProductRepository productRepository)
    {
        _warehouseRepository = warehouseRepository;
        _productRepository = productRepository;
    }
    public async Task<IEnumerable<WarehouseDTO>> GetAllWarehousesAsync()
    {
        var warehouses = await _warehouseRepository.GetAllAsync();
        return warehouses.Select(w => new WarehouseDTO
        {
            Code = w.Code,
            Name = w.Name
        });
    }

    public async Task CreateWarehouseAsync(WarehouseDTO warehouseDto)
    {
        var warehouse = new Warehouse
        {
            Code = warehouseDto.Code,
            Name = warehouseDto.Name
        };
        await _warehouseRepository.CreateAsync(warehouse);
    }
    public async Task<IEnumerable<ProductInWarehouseDTO>> GetProductsInWarehousesAsync(ProductInWarehouseQueryDTO queryDto)
    {
        var warehouses = await _warehouseRepository.GetAllAsync();
        var products = await _productRepository.GetAllAsync();

        var result = new List<ProductInWarehouseDTO>();

        foreach (var warehouse in warehouses)
        {
            foreach (var product in products)
            {
                if (warehouse.ProductQuantities.TryGetValue(product.Id, out var quantity) && quantity > 0)
                {
                    if ((string.IsNullOrEmpty(queryDto.ProductCode) || product.Code == queryDto.ProductCode) &&
                        (string.IsNullOrEmpty(queryDto.WarehouseCode) || warehouse.Code == queryDto.WarehouseCode))
                    {
                        result.Add(new ProductInWarehouseDTO
                        {
                            ProductCode = product.Code,
                            WarehouseCode = warehouse.Code,
                            Quantity = quantity
                        });
                    }
                }
            }
        }

        return result;
    }
}