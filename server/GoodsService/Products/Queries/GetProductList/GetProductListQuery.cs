using MediatR;

namespace SparkSwim.GoodsService.Products.Queries.GetProductList;

public class GetProductListQuery : IRequest<ProductListVm>
{
    public int CountToGet { get; set; }
    public int NumberFromToSkip { get; set; }
}