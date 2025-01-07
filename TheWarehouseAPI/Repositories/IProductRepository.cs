using TheWarehouseAPI.Models;

namespace TheWarehouseAPI.Repositories;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllAsync();
    Task<Product> GetByCodeAsync(string code);
    Task<Product> CreateAsync(Product product);
}
