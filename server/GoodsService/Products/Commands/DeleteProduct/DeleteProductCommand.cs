using MediatR;

namespace SparkSwim.GoodsService.Products.Commands.DeleteProduct;

public class DeleteProductCommand : IRequest
{
    public Guid Id { get; set; }
}