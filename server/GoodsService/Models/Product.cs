namespace SparkSwim.GoodsService.Goods.Models;

public class Product
{
    public Guid ProductId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime CreationDate { get; set; }
    public int ProductCount { get; set; }
    public decimal Price { get; set; }
    public Discount? Discount { get; set; }
    public IEnumerable<ImagesProductModel> ProductImages { get; set; }
}