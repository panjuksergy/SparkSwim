using System.Reflection;
using Microsoft.EntityFrameworkCore;
using SparkSwim.GoodsService.Goods.EntityTypeConfiguration;
using SparkSwim.GoodsService.Goods.Models;
using SparkSwim.GoodsService.Interfaces;

namespace SparkSwim.GoodsService;

public class ProductDbContext : DbContext, IProductDbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Discount> Discount { get; set; }
    public DbSet<ImagesProductModel> Images { get; set; }
    public DbSet<ProductType> ProductTypes { get; set; }

    public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}