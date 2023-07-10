namespace SparkSwim.GoodsService.Goods.Models;

public class ProductType
{
    public int ProductTypeId { get; set; }
    public string ProductTypeTitle { get; set; }
    public ICollection<Product> Products { get; set; }
}