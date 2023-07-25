using AutoMapper;
using SparkSwim.GoodsService.Common.Mapping;
using SparkSwim.GoodsService.Goods.Commands.CreateGood;

namespace SparkSwim.GoodsService.Goods.Models;

public class CreateProductDto : IMapWith<CreateProductCommand>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int ProductCount { get; set; }
    public int ProductTypeId { get; set; }
    public decimal Price { get; set; }
    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateProductDto, CreateProductCommand>();
    }
}