using MediatR;
using SparkSwim.GoodsService.Goods.Models;

namespace SparkSwim.GoodsService.Products.Queries.GetProduct;

public class GetProductDetailsQuery : IRequest<ProductDetailsVm>
{
    public Guid ProductId { get; set; }
}