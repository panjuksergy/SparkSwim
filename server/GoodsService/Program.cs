// var builder = WebApplication.CreateBuilder(args);
// var app = builder.Build();
// 
// app.MapGet("/", () => "Hello World!");
// 
// app.Run();

using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SparkSwim.GoodsService;
using SparkSwim.GoodsService.Common.Mapping;
using SparkSwim.GoodsService.Interfaces;

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
    services.AddControllers();

    services.AddAutoMapper(config =>
    {
        config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
        config.AddProfile(new AssemblyMappingProfile(typeof(IProductDbContext).Assembly));
    });
    services.AddApplication();
    services.AddApplication();
    services.AddControllers();

    services.AddDbContext<ProductDbContext>(options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("UsersDbConnection"));
    });
}

void Configure(IApplicationBuilder app)
{
    app.UseRouting();
    app.UseHttpsRedirection();
    app.UseCors("AllowAll");

    app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
}