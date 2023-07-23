using Microsoft.EntityFrameworkCore;
using SparkSwim.OrderService.Interfaces;
using SparkSwim.OrderService.Models;
using System.Reflection;

namespace SparkSwim.OrderService.Data
{
    public class OrdersDbContext : DbContext, IOrderDbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderArticle> OrderArticles { get; set; }

        public OrdersDbContext(DbContextOptions<OrdersDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
