namespace SparkSwim.GoodsService.Goods.Models;

public class Product
{
    public Guid ProductId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime CreationDate { get; set; }
    public int GoodsCount { get; set; }
    public decimal Price { get; set; }
    public Discount? Discount { get; set; }
    public IEnumerable<ImagesProductModel> GoodImages { get; set; }
}