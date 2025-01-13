using TheWarehouseAPI.DTOs;
using TheWarehouseAPI.Models;
using TheWarehouseAPI.Repositories;

namespace TheWarehouseAPI.Services;

public class ProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<IEnumerable<ProductDTO>> GetAllProductsAsync()
    {
        var products = await _productRepository.GetAllAsync();
        return products.Select(p => new ProductDTO
        {
            Code = p.Code,
            Description = p.Description
        });
    }

    public async Task CreateProductAsync(ProductDTO productDto)
    {
        var product = new Product
        {
            Code = productDto.Code,
            Description = productDto.Description
        };
        await _productRepository.CreateAsync(product);
    }
}