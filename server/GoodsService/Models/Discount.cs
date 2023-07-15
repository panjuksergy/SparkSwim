using SparkSwim.GoodsService.CustomAttributes;

namespace SparkSwim.GoodsService.Goods.Models;

public class Discount
{
    public Guid ProductId { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
    [DecimalPrecision(18, 2)]
    public decimal DiscountValue { get; set; }
}