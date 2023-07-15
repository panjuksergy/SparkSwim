using SparkSwim.GoodsService.CustomAttributes;

namespace SparkSwim.GoodsService.Goods.Models;

public class Product
{
    public Guid ProductId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime CreationDate { get; set; }
    public int ProductCount { get; set; }
    [DecimalPrecision(18, 2)]
    public decimal Price { get; set; }
    public Discount? Discount { get; set; }
    public ICollection<ImagesProductModel> ProductImages { get; set; }
    public int ProductTypeId { get; set; }
    public ProductType ProductType { get; set; }
}