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
        profile.CreateMap<CreateProductCommand, CreateProductDto>()
            .ForMember(_ => _.Title,
                opt => opt.MapFrom(product => product.Title))
            .ForMember(_ => _.Description,
                opt => opt.MapFrom(product => product.Description))
            .ForMember(_ => _.Price,
                opt => opt.MapFrom(product => product.Price))
            .ForMember(_ => _.ProductTypeId,
                opt => opt.MapFrom(product => product.ProductTypeId))
            .ForMember(_ => _.ProductCount,
                opt => opt.MapFrom(product => product.ProductCount));
    }
}