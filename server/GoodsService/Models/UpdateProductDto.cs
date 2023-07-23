using AutoMapper;
using SparkSwim.GoodsService.Common.Mapping;
using SparkSwim.GoodsService.Goods.Commands.CreateGood;
using SparkSwim.GoodsService.Products.Commands.UpdateProduct;

namespace SparkSwim.GoodsService.Goods.Models;

public class UpdateProductDto : IMapWith<UpdateProductCommand>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int ProductCount { get; set; }
    public ImagesProductModel Images { get; set; }
    public decimal Price { get; set; }
    public ProductType ProductType { get; set; }
    public Guid? DiscountId { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateProductDto, UpdateProductCommand>();
    }
}