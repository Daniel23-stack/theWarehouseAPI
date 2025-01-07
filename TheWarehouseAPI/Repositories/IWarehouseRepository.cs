using TheWarehouseAPI.Models;

namespace TheWarehouseAPI.Repositories;

public interface IWarehouseRepository
{
    Task<IEnumerable<Warehouse>> GetAllAsync();
    Task<Warehouse> GetByCodeAsync(string code);
    Task<Warehouse> CreateAsync(Warehouse warehouse);
}