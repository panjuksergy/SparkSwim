namespace SparkSwim.GoodsService;

public class DbInitializer
{
    public static void Initialize(ProductDbContext context)
    {
        context.Database.EnsureCreated();       
    }
}