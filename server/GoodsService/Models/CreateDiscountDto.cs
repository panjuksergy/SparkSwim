using AutoMapper;
using SparkSwim.GoodsService.Common.Mapping;
using SparkSwim.GoodsService.Discounts.Commands.CreateDiscount;
using SparkSwim.GoodsService.Goods.Commands.CreateGood;

namespace SparkSwim.GoodsService.Goods.Models;

public class CreateDiscountDto : IMapWith<CreateDiscountCommand>
{
    public Guid DiscountId { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
    public decimal DiscountValue { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateProductDto, CreateProductCommand>();
    }
}