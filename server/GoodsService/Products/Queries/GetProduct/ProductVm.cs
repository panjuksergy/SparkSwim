using AutoMapper;
using SparkSwim.GoodsService.Common.Mapping;
using SparkSwim.GoodsService.Goods.Models;

namespace SparkSwim.GoodsService.Products.Queries.GetProduct;

public class ProductVm : IMapWith<Product>
{
    public Guid ProductId { get; set; }
    public string Title { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public ImagesProductModel Images { get; set; }
    public Discount Discount { get; set; }
    public DateTime CreationDate { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Product, ProductVm>()
            .ForMember(_ => _.ProductId,
                opt => opt.MapFrom(product => product.ProductId))
            .ForMember(_ => _.Title,
                opt => opt.MapFrom(product => product.Title))
            .ForMember(_ => _.Description,
                opt => opt.MapFrom(product => product.Description))
            .ForMember(_ => _.Price,
                opt => opt.MapFrom(product => product.Price))
            .ForMember(_ => _.Images,
                opt => opt.MapFrom(product => product.ProductImages))
            .ForMember(_ => _.CreationDate,
                opt => opt.MapFrom(product => product.CreationDate))
            .ForMember(_ => _.Discount,
                opt => opt.MapFrom(product => product.Discount));
    }
}