using SparkSwim.GoodsService.CustomAttributes;

namespace SparkSwim.GoodsService.Goods.Models;

public class Discount
{
    public Guid DiscountId { get; set; }
    public ICollection<Product> Products { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
    [DecimalPrecision(18, 2)]
    public decimal DiscountValue { get; set; }
}