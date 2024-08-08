using _07_08.Task1.Context;
using _07_08.Task1.Exceptions;
using _07_08.Task1.Models;
using _07_08.Task1.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace _07_08.Task1.Services.Implementations;

public class CategoryService : ICategoryService
{
    private readonly AppDbContext _context;
    public CategoryService()
    {
        _context = new AppDbContext();
    }
    public async Task AddCategory(Category categoty)
    {
        var isExist = await _context.Categories.FirstOrDefaultAsync();
        if (isExist is not null)
            throw new AlreadyExistException("Category with this name already exist");
        categoty.Id = 0;
        await _context.Categories.AddAsync(categoty);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Category>> GetAllCategories()
    {
        return _context.Categories.Include(x => x.Products).AsNoTracking().ToList();
    }

    public async Task<Category> GetCategoryById(int id)
    {
        var category = await _context.Categories.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        if (category is null)
            throw new NotFoundException();
        return category;
    }

    public async Task RemoveCategory(int id)
    {
        var category = await GetCategoryById(id);
        _context.Categories.Remove(category);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateCategory(Category category)
    {
        var foundCategory = await GetCategoryById(category.Id);
        var isExist = _context.Categories.FirstOrDefaultAsync(x => x.Name == category.Name);
        if (isExist is not null)
            throw new AlreadyExistException("Category with this name already exist");
        foundCategory.Name = category.Name;
        await _context.SaveChangesAsync();
    }
}
