using Microsoft.EntityFrameworkCore;
using SparkSwim.Core.Identity;
using SparkSwim.Core.Mapping;
using SparkSwim.OrderService.Data;
using SparkSwim.OrderService.Interfaces;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
RegisterServices(builder.Services);

var app = builder.Build();
Configure(app);

app.Run();

void RegisterServices(IServiceCollection services)
{
    services.AddAutoMapper(config =>
    {
        config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
        config.AddProfile(new AssemblyMappingProfile(typeof(IOrderDbContext).Assembly));
    });

    services.AddDbContext<IOrderDbContext, OrdersDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("OrdersDbConnection"))
    );

    services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

    services.AddControllers();

    services.AddJwtAuth(builder.Configuration);
}

void Configure(IApplicationBuilder app)
{
    app.UseRouting();

    app.UseAuthentication();
    app.UseAuthorization();

    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });
}
