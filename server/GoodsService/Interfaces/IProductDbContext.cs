using Microsoft.EntityFrameworkCore;
using SparkSwim.GoodsService.Goods.Models;

namespace SparkSwim.GoodsService.Interfaces;

public interface IProductDbContext
{
    DbSet<Product> Products { get; set; }
    DbSet<Discount> Discount { get; set; }
    DbSet<ImagesProductModel> Images { get; set; }
    DbSet<ProductType> ProductTypes { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}