// var builder = WebApplication.CreateBuilder(args);
// var app = builder.Build();
// 
// app.MapGet("/", () => "Hello World!");
// 
// app.Run();

using SparkSwim.GoodsService;

namespace MyNamespace;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
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
        app.Run();
    }
}