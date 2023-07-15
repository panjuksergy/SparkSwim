using MediatR;
using SparkSwim.GoodsService.Goods.Models;

namespace SparkSwim.GoodsService.Discounts.Queries.GetDiscountsList;

public class GetDiscountListQuery : IRequest<DiscountListVm>
{
    public ProductType? ProductType { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
    public decimal DiscountValue { get; set; }
}