using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _07_08.Task1.Models;

public class Product
{
    [Required]
    public int Id { get; set; }
    [Required]
    [StringLength(100)]
    public string Name { get; set; }  = null!;
    public string Description { get; set; }
    [Precision(18, 2)]
    public decimal Price { get; set; }
    public Category Category { get; set; } = null!;
    public int CategoryId { get; set; }
}
