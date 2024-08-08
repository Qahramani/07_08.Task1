using _07_08.Task1.Models;

namespace _07_08.Task1.Services.Interfaces;

public interface ICategoryService
{
    public Task AddCategory(Category categoty);
    public Task RemoveCategory(int id);
    public Task UpdateCategory(Category category);
    public Task<Category> GetCategoryById(int id);
    public Task<List<Category>> GetAllCategories();
}
