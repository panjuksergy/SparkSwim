using MediatR;

namespace SparkSwim.GoodsService.Products.Queries.GetProductList;

public class GetProductListQuery : IRequest<ProductListVm>
{
    public Guid ProductId { get; set; }
}