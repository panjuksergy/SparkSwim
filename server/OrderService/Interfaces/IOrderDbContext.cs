using Microsoft.EntityFrameworkCore;
using SparkSwim.OrderService.Models;

namespace SparkSwim.OrderService.Interfaces
{
    public interface IOrderDbContext
    {
        DbSet<Order> Orders { get; set; }
        DbSet<OrderArticle> OrderArticles { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
