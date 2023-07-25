using System.Reflection;
using Microsoft.EntityFrameworkCore;
using SparkSwim.Core.Mapping;
using SparkSwim.GoodsService;
using SparkSwim.GoodsService.Interfaces;
using SparkSwim.Core.Identity;

var builder = WebApplication.CreateBuilder(args);
RegisterServices(builder.Services);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    try
    {
        var context = serviceProvider.GetRequiredService<ProductDbContext>();
        DbInitializer.Initialize(context);
    }
    catch (Exception ex)
    {
    }
}

Configure(app);

app.Run();

void RegisterServices(IServiceCollection services)
{    
    services.AddDbContext<IProductDbContext, ProductDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
    );
    
    services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
    
    services.AddControllers();

    services.AddAutoMapper(config =>
    {
        config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
        config.AddProfile(new AssemblyMappingProfile(typeof(IProductDbContext).Assembly));
    });
    services.AddApplication();
    services.AddControllers();

    services.AddJwtAuth(builder.Configuration);
}

void Configure(IApplicationBuilder app)
{
    app.UseRouting();
    app.UseHttpsRedirection();
    app.UseCors("AllowAll");

    app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
}