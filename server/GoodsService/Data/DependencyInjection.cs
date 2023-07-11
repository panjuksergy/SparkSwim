using Microsoft.EntityFrameworkCore;
using SparkSwim.GoodsService.Interfaces;

namespace SparkSwim.GoodsService;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistance(this IServiceCollection services, IConfiguration configuration)
    {
        var conStr = configuration["DbConnection"];
        services.AddDbContext<ProductDbContext>(_ => { _.UseSqlServer(conStr); });
        services.AddScoped<IProductDbContext>(_ => _.GetService<ProductDbContext>());
        return services;
    }   

    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        return services;
    }
}
