using SparkSwim.GoodsService.Goods.Models;

namespace SparkSwim.GoodsService.Goods.Commands.CreateGood;
using MediatR;
public class CreateProductCommand : IRequest<Guid>
{
    public Guid ProductId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int ProductCount { get; set; }
    public ICollection<ImagesProductModel> Images { get; set; }
    public decimal Price { get; set; }
    public Discount? Discount { get; set; }
}