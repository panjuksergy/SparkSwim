namespace SparkSwim.GoodsService.Goods.Models;

public class Discount
{
    public Guid ProductId { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
    public decimal DiscountValue { get; set; }
}