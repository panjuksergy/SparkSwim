using MediatR;
using SparkSwim.GoodsService.Goods.Models;

namespace SparkSwim.GoodsService.Products.Commands.UpdateProduct;

public class UpdateProductCommand : IRequest
{
    public Guid ProductId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public ProductType ProductType { get; set; }
    public ICollection<ImagesProductModel> ProductImages { get; set; }
}