using MediatR;
using SparkSwim.GoodsService.Goods.Models;

namespace SparkSwim.GoodsService.Products.Queries.GetProduct;

public class GetProductQuery : IRequest<ProductVm>
{
    public Guid ProductId { get; set; }
}