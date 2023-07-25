using AutoMapper;
using SparkSwim.GoodsService.Common.Mapping;
using SparkSwim.GoodsService.Discounts.Commands.UpdateDiscount;

namespace SparkSwim.GoodsService.Goods.Models;

public class UpdateDiscountDto : IMapWith<UpdateDiscountCommand>
{
    public Guid DiscountId { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
    public decimal DiscountValue { get; set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateDiscountDto, UpdateDiscountCommand>();
    }
}