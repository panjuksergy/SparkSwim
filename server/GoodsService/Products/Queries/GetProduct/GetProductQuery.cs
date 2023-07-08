using MediatR;
using SparkSwim.GoodsService.Goods.Models;

namespace SparkSwim.GoodsService.Products.Queries.GetProduct;

public class GetProductQuery : IRequest<ProductVm>
{
    public Guid ProductId { get; set; }
    // public string Title { get; set; }
    // public string Description { get; set; }
    // public decimal Price { get; set; }
    // public ImagesProductModel Images { get; set; }
}