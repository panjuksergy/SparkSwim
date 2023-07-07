using Microsoft.EntityFrameworkCore;
using SparkSwim.GoodsService.Goods.Models;

namespace SparkSwim.GoodsService.Interfaces;

public interface IProductDbContext
{
    DbSet<Product> Products { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}