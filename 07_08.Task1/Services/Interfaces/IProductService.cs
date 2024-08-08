using _07_08.Task1.Models;

namespace _07_08.Task1.Services.Interfaces;

public interface IProductService
{
    public  Task AddAsync(Product product);
    public Task RemoveAsync(int id);
    public Task UpdateAsync(Product product);
    public Task<Product> GetByIdAsync(int id);
    public Task<List<Product>> GetAllAsync();
}
