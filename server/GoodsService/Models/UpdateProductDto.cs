using AutoMapper;
using SparkSwim.Core.Mapping;
using SparkSwim.GoodsService.Products.Commands.UpdateProduct;

namespace SparkSwim.GoodsService.Goods.Models;

public class UpdateProductDto : IMapWith<UpdateProductCommand>
{
    public Guid ProductId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int ProductCount { get; set; }
    // public ImagesProductModel Images { get; set; }
    public decimal Price { get; set; }
    public int ProductTypeId { get; set; }
    public Guid? DiscountId { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateProductDto, UpdateProductCommand>();
    }
}