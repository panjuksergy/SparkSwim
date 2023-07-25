using SparkSwim.GoodsService.Goods.Models;

namespace SparkSwim.GoodsService.Goods.Commands.CreateGood;
using MediatR;
public class CreateProductCommand : IRequest<Guid>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int ProductCount { get; set; }
    public int ProductTypeId { get; set; }
    public decimal Price { get; set; }
}