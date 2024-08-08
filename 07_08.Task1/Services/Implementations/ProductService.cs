using _07_08.Task1.Context;
using _07_08.Task1.Exceptions;
using _07_08.Task1.Models;
using _07_08.Task1.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace _07_08.Task1.Services.Implementations;

public class ProductService : IProductService
{
    private readonly AppDbContext _context;
    public ProductService()
    {
         _context = new AppDbContext();
    }
    public async Task AddAsync(Product product)
    {
        var isExist = await _context.Products.AnyAsync(x => x.Name == product.Name);
        if (isExist)
            throw new AlreadyExistException("Product with give name already exist");
        if (product.Price < 0)
            throw new Exception("Price cannot be negative");

        var isCategoryExist = await _context.Categories.FirstOrDefaultAsync(x => x.Id ==  product.CategoryId);
        if (isCategoryExist is null)
            throw new NotFoundException("Category with given Id is not found");

        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
    }

    public async Task<Product> GetByIdAsync(int id)
    {
        var product = await _context.Products.Include(x => x.Category).AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        if (product is null)
            throw new NotFoundException();
        return product;
    }

    public async Task<List<Product>> GetAllAsync()
    {
        return await _context.Products.Include(x => x.Category).AsNoTracking().ToListAsync();    
    }

    public async Task RemoveAsync(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product is null)
            throw new NotFoundException();
        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Product product)
    {
        var foundProduct = await _context.Products.FindAsync(product.Id);
        if (foundProduct is null)
            throw new NotFoundException("Product with given Id is not found");

        if (product.Price < 0)
            throw new Exception("Price cannot be negative");

        var isCategoryExist = await _context.Categories.FirstOrDefaultAsync(x => x.Id == product.CategoryId);
        if (isCategoryExist is null)
            throw new NotFoundException("Category with given Id is not found");

        foundProduct.Name = product.Name;
        foundProduct.Description = product.Description;
        foundProduct.Price = product.Price;
        foundProduct.CategoryId = product.CategoryId;
        await _context.SaveChangesAsync();
    }
}
