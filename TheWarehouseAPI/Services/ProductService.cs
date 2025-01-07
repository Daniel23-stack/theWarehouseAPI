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

    public Task<IEnumerable<Product>> GetAllProductsAsync() => _productRepository.GetAllAsync();
    public Task<Product> CreateProductAsync(Product product) => _productRepository.CreateAsync(product);
}