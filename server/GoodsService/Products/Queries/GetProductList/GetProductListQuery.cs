using MediatR;
using SparkSwim.GoodsService.Goods.Models;

namespace SparkSwim.GoodsService.Products.Queries.GetProductList;

public class GetProductListQuery : IRequest<ProductListVm>
{
    public int CountToGet { get; set; }
    public int NumberFromToSkip { get; set; }
    public decimal? PriceFrom { get; set; }
    public decimal? PriceTo { get; set; }
    public ProductType? ProductType { get; set; }
}